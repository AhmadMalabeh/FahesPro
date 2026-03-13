using CarTestDataAccessLayer;
using SharedObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTestLogicalLayer
{
    public static class clsAuditHelper
    {
        private const string TABLE_NAME = "Car_Rating_Testing01";

        public static void LogInsert(int recordID, int userID, string entryType)
        {
            clsTestData.AddAuditLog(new clsSharedAuditLog
            {
                TableName = TABLE_NAME,
                RecordID = recordID,
                FieldName = "ALL",
                OldValue = null,
                NewValue = "تم إنشاء التقرير",
                ActionType = "INSERT",
                ChangedByUserID = userID,
                ChangedDate = DateTime.Now,
                EntryType = entryType
            });
        }

        public static void LogFieldChange(int recordID, int userID,
                                  string fieldName,
                                  string oldValue, string newValue,
                                  string entryType)
        {
            if (oldValue == newValue) return;

            clsTestData.AddAuditLog(new clsSharedAuditLog
            {
                TableName = TABLE_NAME,
                RecordID = recordID,
                FieldName = fieldName,
                OldValue = oldValue,
                NewValue = newValue,
                ActionType = "UPDATE",
                ChangedByUserID = userID,
                ChangedDate = DateTime.Now,
                EntryType = entryType
            });
        }
        public static void LogTestChanges(clsCarTest oldData,
                                          clsCarTest newData,
                                          int userID, string EntryType = "فحص مركبة")
        {
            int id = newData.GetID();
            

            LogFieldChange(id, userID, "رقم اللوحة",
                oldData.Car.CarPlateNumber, newData.Car.CarPlateNumber, EntryType);

            LogFieldChange(id, userID, "رقم الشاصي",
                oldData.Car.CarShassiNumber, newData.Car.CarShassiNumber, EntryType);

            LogFieldChange(id, userID, "نوع السيارة",
                oldData.Car.CarMakeModel, newData.Car.CarMakeModel, EntryType);

            LogFieldChange(id, userID, "سنة الصنع",
                oldData.Car.CarMinufacuringYear, newData.Car.CarMinufacuringYear, EntryType);

            LogFieldChange(id, userID, "اللون",
                oldData.Car.CarColor, newData.Car.CarColor, EntryType);

            LogFieldChange(id, userID, "سعة المحرك",
                oldData.Car.CarEnginCapacity, newData.Car.CarEnginCapacity, EntryType);

            LogFieldChange(id, userID, "اسم الزبون",
                oldData.CustumerName, newData.CustumerName, EntryType);

            LogFieldChange(id, userID, "سعر الفحص",
                oldData.TestPrice.ToString(), newData.TestPrice.ToString(), EntryType);

            LogFieldChange(id, userID, "فحص المحرك",
                oldData.EnginTest, newData.EnginTest, EntryType);

            LogFieldChange(id, userID, "نسبة المحرك",
                oldData.EnginTestPerc, newData.EnginTestPerc, EntryType);

            LogFieldChange(id, userID, "فحص الجير",
                oldData.GearTest, newData.GearTest, EntryType);

            LogFieldChange(id, userID, "فحص البكاكس",
                oldData.BakaksTest, newData.BakaksTest, EntryType);

            LogFieldChange(id, userID, "فحص الهيكل",
                oldData.BodyTest, newData.BodyTest, EntryType);

            LogFieldChange(id, userID, "ملاحظات العامل",
                oldData.WorkerNotes, newData.WorkerNotes, EntryType);

            LogFieldChange(id, userID, "ملاحظات المركز",
                oldData.CenterNotes, newData.CenterNotes, EntryType);

            LogFieldChange(id, userID, "الدفع لاحقاً",
                oldData.PayLater.ToString(), newData.PayLater.ToString(), EntryType);
        }

        public static void LogRatingChanges(clsCarRating oldData,
                                            clsCarRating newData,
                                            int userID)
        {
            // أولاً سجّل حقول الفحص المشتركة
            string EntryType = "تخمين مركبة";
            LogTestChanges(oldData, newData, userID, EntryType);

            int id = newData.GetID();
            

            // ثم الحقول الخاصة بالتخمين
            LogFieldChange(id, userID, "رقم التسجيل",
                oldData.RegstrationNumber, newData.RegstrationNumber, EntryType);

            LogFieldChange(id, userID, "البنك",
                oldData.Bank, newData.Bank, EntryType);

            LogFieldChange(id, userID, "نوع الاستخدام",
                oldData.UseType, newData.UseType, EntryType);

            LogFieldChange(id, userID, "نوع التأمين",
                oldData.InsuranceType, newData.InsuranceType, EntryType);

            LogFieldChange(id, userID, "رقم المحرك",
                oldData.EnginNumber, newData.EnginNumber, EntryType);

            LogFieldChange(id, userID, "مالك السيارة",
                oldData.CarOwner, newData.CarOwner, EntryType);

            LogFieldChange(id, userID, "حالة السيارة",
                oldData.CarStatus, newData.CarStatus, EntryType);

            LogFieldChange(id, userID, "قيمة الهيكل",
                oldData.BodyValue.ToString(), newData.BodyValue.ToString(), EntryType);

            LogFieldChange(id, userID, "قيمة الطابع",
                oldData.StampValue.ToString(), newData.StampValue.ToString(), EntryType);

            LogFieldChange(id, userID, "القيمة الإجمالية",
                oldData.TotalValue.ToString(), newData.TotalValue.ToString(), EntryType);
        }
    }
}
