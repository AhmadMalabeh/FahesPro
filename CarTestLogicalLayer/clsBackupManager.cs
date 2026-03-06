using SharedLogging;
using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using CarTestDataAccessLayer;

namespace CarTestLogicalLayer
{
    public static class clsBackupManager
    {
        // 1) مسار تشغيل البرنامج
        private static readonly string AppPath = AppDomain.CurrentDomain.BaseDirectory;

        // 2) مجلد النسخ الاحتياطي داخل مجلد البرنامج
        private static readonly string BackupFolder = Path.Combine(AppPath, "AutoBackup");

        private static string FinalBackup => Path.Combine(BackupFolder, "backup.bak");
        private static string TempBackup => Path.Combine(BackupFolder, "backup_temp.bak");
        private static string PrevBackup => Path.Combine(BackupFolder, "backup_prev.bak");

        public static void PerformSafeBackup()
        {
            try
            {
                // إنشاء المجلد إذا لم يكن موجوداً
                if (!Directory.Exists(BackupFolder))
                    Directory.CreateDirectory(BackupFolder);

                // منح صلاحيات لمحرك SQL Server (إن أمكن)
                GrantSqlAccess(BackupFolder);

                // تأكد ما في ملف temp قديم (من عملية سابقة فشلت)
                SafeDeleteIfExists(TempBackup);

                // 1) إنشاء نسخة مؤقتة
                clsTestData.CreateBackup(TempBackup);

                // 2) انتظر تحرير الملف (SQL أو Antivirus أحياناً يمسكه)
                WaitForFileRelease(TempBackup);

                // 3) Rotation (تبديل النسخ)
                if (File.Exists(FinalBackup))
                {
                    // احتياط: تأكد أن Final غير مقفول
                    WaitForFileRelease(FinalBackup);

                    SafeDeleteIfExists(PrevBackup);
                    File.Move(FinalBackup, PrevBackup);
                }

                // 4) ترقية المؤقت إلى الأساسي
                File.Move(TempBackup, FinalBackup);
            }
            catch (Exception ex)
            {
                clsLogger.LogError(ex, "BLL -> PerformSafeBackup");
            }
            finally
            {
                // تنظيف الملف المؤقت إذا بقي موجوداً
                SafeDeleteIfExists(TempBackup);
            }
        }

        // =========================================
        // Helpers
        // =========================================

        /// <summary>
        /// انتظر حتى يصبح الملف غير مقفول من أي عملية أخرى
        /// </summary>
        private static void WaitForFileRelease(string path, int retries = 30, int delayMs = 250)
        {
            // إذا الملف غير موجود أصلاً
            if (!File.Exists(path))
                throw new FileNotFoundException("Backup file not found: " + path, path);

            for (int i = 0; i < retries; i++)
            {
                try
                {
                    // حاول فتح الملف بدون مشاركة (يعني لازم يكون غير مقفول)
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    {
                        return; // صار متاح
                    }
                }
                catch
                {
                    Thread.Sleep(delayMs);
                }
            }

            throw new IOException("The file is still being used by another process: " + path);
        }

        /// <summary>
        /// حذف آمن بدون رمي استثناء إذا الملف مقفول أو لا يمكن حذفه
        /// </summary>
        private static void SafeDeleteIfExists(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    // أحياناً يكون ReadOnly
                    File.SetAttributes(path, FileAttributes.Normal);

                    // لو كان مقفول، حاول تنتظر شوي
                    try { WaitForFileRelease(path, retries: 8, delayMs: 150); } catch { }

                    File.Delete(path);
                }
            }
            catch
            {
                // نتجاهل (لأن هذا تنظيف فقط)
            }
        }

        /// <summary>
        /// تمنح هذه الدالة صلاحية التحكم الكامل لمحرك SQL Server على مجلد النسخ الاحتياطي
        /// </summary>
        private static void GrantSqlAccess(string folderPath)
        {
            try
            {
                DirectoryInfo dInfo = new DirectoryInfo(folderPath);
                DirectorySecurity dSecurity = dInfo.GetAccessControl();

                // الافتراضي لـ SQL Server (نسخة كاملة)
                // ملاحظة: لو SQL Express غالباً يكون:
                // NT SERVICE\MSSQL$SQLEXPRESS

                var sqlServiceAccount = new NTAccount(@"NT SERVICE\MSSQLSERVER");
                 //var sqlServiceAccount = new NTAccount(@"NT SERVICE\MSSQL$SQLEXPRESS");

                dSecurity.AddAccessRule(new FileSystemAccessRule(
                    sqlServiceAccount,
                    FileSystemRights.FullControl,
                    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                    PropagationFlags.None,
                    AccessControlType.Allow));

                dInfo.SetAccessControl(dSecurity);
            }
            catch
            {
                // إذا فشل (مثلاً بدون صلاحية Admin)، نتجاهل
            }
        }
    }
}

