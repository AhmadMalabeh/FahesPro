using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using CarTestLogicalLayer;
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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR_SYNCFUSION_LICENSE_KEY_HERE");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

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
    }
}
