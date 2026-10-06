using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Data.Common;
using CarTestLogicalLayer;
using SharedLogging;
namespace CarTestUserInterFace
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjGyl/VkV+XU9AclRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS3hTc0RlWXhacXdcQGJVUU91XA==");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            frmLogInScreen loginForm = new frmLogInScreen();

            // نستخدم ShowDialog ليبقى البرنامج ينتظر نتيجة هذه الشاشة
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // 2. إذا نجح الدخول، نمرر بيانات المستخدم للشاشة الرئيسية ونبدأ البرنامج بها
                Application.Run(new MainScreen(loginForm.LoggedInUser));
            }
            else
            {
                // إذا أغلق المستخدم شاشة الدخول دون دخول ناجح، ينتهي البرنامج هنا
                Application.Exit();
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            bool isDatabaseException = IsDatabaseException(e.Exception);
            clsLogger.LogError(e.Exception, isDatabaseException
                ? "Unhandled database exception on UI thread"
                : "Unhandled UI exception");

            MessageBox.Show(
                isDatabaseException
                    ? "تعذر تنفيذ العملية بسبب مشكلة في قاعدة البيانات. تحقق من توفر قاعدة البيانات ثم أعد المحاولة."
                    : "حدث خطأ غير متوقع. تم تسجيل التفاصيل.",
                isDatabaseException ? "مشكلة في قاعدة البيانات" : "خطأ غير متوقع",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception exception)
            {
                clsLogger.LogError(exception, IsDatabaseException(exception)
                    ? "Unhandled database exception in application domain"
                    : "Unhandled application-domain exception");
            }
        }

        private static bool IsDatabaseException(Exception exception)
        {
            if (exception == null)
                return false;

            if (exception is DbException)
                return true;

            if (exception is AggregateException aggregateException)
                return aggregateException.Flatten().InnerExceptions.Any(IsDatabaseException);

            return IsDatabaseException(exception.InnerException);
        }
    }
}
