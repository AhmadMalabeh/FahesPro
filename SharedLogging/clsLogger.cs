using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
namespace SharedLogging
{
    
    

    public static class clsLogger
    {
        private static readonly object _lock = new object();

        // ========================================
        // مسار المجلد والملف
        // ========================================
        private static string LogFolder =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        private static string LogFile =>
            Path.Combine(LogFolder, $"Log_{DateTime.Now:yyyy-MM-dd}.txt");

        // ========================================
        // آخر رسالة تم تسجيلها (Property)
        // ========================================
        public static string LastMessage { get; private set; } = "";

        // ========================================
        // إنشاء المجلد إن لم يكن موجود
        // ========================================
        private static void EnsureLogDirectory()
        {
            if (!Directory.Exists(LogFolder))
                Directory.CreateDirectory(LogFolder);
        }

        // ========================================
        // تسجيل رسالة عادية
        // ========================================
        public static void LogInfo(string message)
        {
            LastMessage = message;
            WriteLog("INFO", message);
        }

        // ========================================
        // تسجيل تحذير
        // ========================================
        public static void LogWarning(string message)
        {
            LastMessage = message;
            WriteLog("WARNING", message);
        }

        // ========================================
        // تسجيل Exception
        // ========================================
        public static void LogError(Exception ex, string contextMessage = "")
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("---------- ERROR ----------");
                sb.AppendLine($"Date: {DateTime.Now}");
                if (!string.IsNullOrEmpty(contextMessage))
                    sb.AppendLine($"Context: {contextMessage}");
                sb.AppendLine($"Message: {ex.Message}");
                sb.AppendLine($"Source: {ex.Source}");
                sb.AppendLine($"StackTrace: {ex.StackTrace}");

                if (ex.InnerException != null)
                {
                    sb.AppendLine("----- Inner Exception -----");
                    sb.AppendLine(ex.InnerException.Message);
                    sb.AppendLine(ex.InnerException.StackTrace);
                }

                LastMessage = sb.ToString();
                WriteLog("ERROR", sb.ToString());
            }
            catch
            {
                // لا نسمح للـ Logger أن يكسر البرنامج
            }
        }

        // ========================================
        // الدالة الأساسية للكتابة داخل الملف
        // ========================================
        private static void WriteLog(string level, string message)
        {
            try
            {
                lock (_lock) // Thread Safe
                {
                    EnsureLogDirectory();

                    StringBuilder logEntry = new StringBuilder();
                    logEntry.AppendLine("=================================");
                    logEntry.AppendLine($"Level : {level}");
                    logEntry.AppendLine($"Time  : {DateTime.Now}");
                    logEntry.AppendLine(message);
                    logEntry.AppendLine();

                    File.AppendAllText(LogFile, logEntry.ToString(), Encoding.UTF8);
                }
            }
            catch
            {
                // تجاهل أي خطأ داخل Logger
            }
        }
    }

}
