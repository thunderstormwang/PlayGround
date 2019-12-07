using System;

namespace Enum_String_Int
{
    public class Program
    {
        public static int Main(string[] args)
        {
            //列出所有名稱
            foreach (string en in Enum.GetNames(typeof(DayofWeek)))
            {
                Console.WriteLine($"Enum Name: {en}");
            }

            DayofWeek day = DayofWeek.Monday;

            //將列舉轉為字串
            Console.WriteLine($"Enum To String: {day.ToString()}");

            //將字串轉為列舉
            day = (DayofWeek)Enum.Parse(typeof(DayofWeek), "ThursDay", true);
            Console.WriteLine($"String To Enum: {day}");

            //將字串轉為列舉(對不上)
            try
            {
                Console.WriteLine($"String To Enum(not found): {Enum.Parse(typeof(DayofWeek), "WTF")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when Enum.Parse: {ex.Message}" );
            }

            //將列舉轉為數字
            Console.WriteLine($"Enum to Int: {day} {(int)day}");

            //將數字轉回列舉
            day = (DayofWeek)9;
            Console.WriteLine($"Int to Enum: {day}");

            //小心數字轉換對不上時不會有錯誤，但會出現非列舉值
            day = (DayofWeek)100;
            Console.WriteLine($"Int(100) to Enum: {day}");

            return 0;
        }
    }

    public enum DayofWeek
    {
        Sunday = 0,
        Monday = 1,
        TuesDay = 2,
        WednesDay = 3,
        ThursDay = 4,
        Friday = 5,
        SaturDay = 6
    }
}