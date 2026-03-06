using CarTestDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTestLogicalLayer
{
    public class clsDialyExpenses
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode;

        // الخصائص (Properties) بناءً على تصميم الشاشة وقاعدة البيانات
        public int ExpenseID { get; set; }
        public int CategoryID { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string CreatedByUserName { get; set; }



        // المشيد الافتراضي (Default Constructor) - وضعية الإضافة
        public clsDialyExpenses()
        {
            this.ExpenseID = -1;
            this.CategoryID = -1;
            this.Amount = 0;
            this.Description = "";
            this.ExpenseDate = DateTime.Now;
            this.CreatedByUserName = "";
            _Mode = enMode.AddNew;
        }

        // مشيد للاستخدام عند التحديث (Update Constructor)
        public clsDialyExpenses(int expenseID, int categoryID, decimal amount, string description, DateTime expenseDate, string createdByUserName)
        {
            this.ExpenseID = expenseID;
            this.CategoryID = categoryID;
            this.Amount = amount;
            this.Description = description;
            this.ExpenseDate = expenseDate;
            this.CreatedByUserName = createdByUserName;
            _Mode = enMode.Update;
        }

        // وظيفة الإضافة الخاصة (Private)
        private bool _AddNewExpense()
        {
            // استدعاء طبقة الـ DAL (سنفترض وجود كلاس clsExpenseData في الـ DAL)
            this.ExpenseID = clsTestData.AddNewExpense(this.CategoryID, this.Amount, this.Description, this.ExpenseDate, this.CreatedByUserName);
            return (this.ExpenseID != -1);
        }

        // وظيفة التحديث الخاصة (Private)
        private bool _UpdateExpense()
        {
            return clsTestData.UpdateExpense(this.ExpenseID, this.CategoryID, this.Amount, this.Description, this.ExpenseDate, this.CreatedByUserName);
        }

        // وظيفة الحفظ العامة (Public)
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewExpense())
                    {
                        _Mode = enMode.Update; // تحويل الحالة لتحديث بعد النجاح في الإضافة
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateExpense();
            }
            return false;
        }

        // وظيفة الحذف
        public bool Delete()
        {
            if (_Mode == enMode.Update)
            {
                return clsTestData.DeleteExpense(this.ExpenseID);
            }
            return false;
        }

        // --- الدوال الساكنة (Static Methods) لجلب البيانات ---

        public static DataTable GetAllExpenses()
        {
            return clsTestData.GetAllExpenses();
        }

        public static DataTable GetExpenseCategories()
        {
            return clsTestData.GetExpenseCategories();
        }

        public static clsDialyExpenses Find(int expenseID)
        {
            // دالة للبحث عن مصروف معين وإعادته ككائن
            int catID = -1; decimal amt = 0; string desc = ""; DateTime date = DateTime.Now; string username = "";

            if (clsTestData.GetExpenseByID(expenseID, ref catID, ref amt, ref desc, ref date, ref username))
                return new clsDialyExpenses(expenseID, catID, amt, desc, date, username);
            else
                return null;
        }

        public static int AddNewCategory(string CategoryName)
        {
            // استدعاء طبقة DAL لإضافة التصنيف للقاعدة وإرجاع الـ ID الجديد
            // سنفترض وجود دالة في clsTestData تقوم بذلك
            return clsTestData.AddNewCategory(CategoryName);
        }

        public static DataTable GetAllExpensesBettwenTowDates(DateTime fromDate, DateTime toDate)
        {
            return clsTestData.GetAllExpensesBettwenTowDates(fromDate, toDate);
        }
    }
}
