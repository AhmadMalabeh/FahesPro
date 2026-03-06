using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTestLogicalLayer
{
    public class clsJordanianCurrencyToWords
    {
        private static readonly string[] Ones =
        {
        "", "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة",
        "ستة", "سبعة", "ثمانية", "تسعة"
        };

        private static readonly string[] Tens =
        {
        "", "عشرة", "عشرون", "ثلاثون", "أربعون",
        "خمسون", "ستون", "سبعون", "ثمانون", "تسعون"
        };

        private static readonly string[] Teens =
        {
        "عشرة", "أحد عشر", "اثنا عشر", "ثلاثة عشر",
        "أربعة عشر", "خمسة عشر", "ستة عشر",
        "سبعة عشر", "ثمانية عشر", "تسعة عشر"
        };

        private static readonly string[] Hundreds =
        {
        "", "مائة", "مائتان", "ثلاثمائة", "أربعمائة",
        "خمسمائة", "ستمائة", "سبعمائة",
        "ثمانمائة", "تسعمائة"
        };

        public static string Convert(decimal amount)
        {
            if (amount == 0)
                return "صفر دينار أردني";

            long dinars = (long)amount;
            int fils = (int)Math.Round((amount - dinars) * 1000);

            StringBuilder result = new StringBuilder();

            if (dinars > 0)
                result.Append($"{NumberToWords(dinars)} {GetDinarName(dinars)}");

            if (fils > 0)
            {
                if (dinars > 0)
                    result.Append(" و ");

                result.Append($"{NumberToWords(fils)} {GetFilsName(fils)}");
            }

            return result.ToString();
        }

        private static string NumberToWords(long number)
        {
            if (number < 10)
                return Ones[number];

            if (number < 20)
                return Teens[number - 10];

            if (number < 100)
            {
                long ones = number % 10;
                long tens = number / 10;

                if (ones == 0)
                    return Tens[tens];

                return $"{Ones[ones]} و {Tens[tens]}";
            }

            if (number < 1000)
            {
                long remainder = number % 100;
                long hundreds = number / 100;

                if (remainder == 0)
                    return Hundreds[hundreds];

                return $"{Hundreds[hundreds]} و {NumberToWords(remainder)}";
            }

            if (number < 1_000_000)
            {
                long remainder = number % 1000;
                long thousands = number / 1000;

                string thousandText =
                    thousands == 1 ? "ألف" :
                    thousands == 2 ? "ألفان" :
                    thousands <= 10 ? $"{NumberToWords(thousands)} آلاف" :
                    $"{NumberToWords(thousands)} ألف";

                if (remainder == 0)
                    return thousandText;

                return $"{thousandText} و {NumberToWords(remainder)}";
            }

            return "عدد كبير";
        }

        private static string GetDinarName(long number)
        {
            if (number == 1)
                return "دينار أردني واحد";

            if (number == 2)
                return "ديناران أردنيان";

            if (number <= 10)
                return "دنانير أردنية";

            return "دينار أردني";
        }

        private static string GetFilsName(int number)
        {
            if (number == 1)
                return "فلس واحد";

            if (number == 2)
                return "فلسان";

            if (number <= 10)
                return "فلوس";

            return "فلس";
        }
    }
}
