namespace Divers_EndTask
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    internal class Program
    {
        private static Diver CreateDiver(ref List<Diver> diverList)
        {
            Diver item = null;
            string str = "";
            string[] strArray = new string[4];
            try
            {
                Console.WriteLine("welcome,please fill the following:");
                Console.WriteLine("name");
                strArray[0] = Console.ReadLine();
                if (strArray[0].Length <= 1)
                {
                    str = str + "*Name To Short.\n";
                }
                Console.WriteLine("Last name");
                strArray[1] = Console.ReadLine();
                Console.WriteLine("Enter ID(6 digits)");
                int num = int.Parse(Console.ReadLine());
                if (num.ToString().Length != 6)
                {
                    str = str + "*Incorrect ID\n";
                }
                else
                {
                    using (List<Diver>.Enumerator enumerator = diverList.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            if (enumerator.Current.diver_ID == num)
                            {
                                str = str + "*Incorrect ID\n";
                                break;
                            }
                        }
                    }
                }
                string[] strArray2 = new string[] { "yyyy", "mm", "dd" };
                int[] numArray = new int[3];
                Console.WriteLine("Enter Birth date:");
                int index = 0;
                while (true)
                {
                    if (index < 3)
                    {
                        Console.WriteLine(strArray2[index]);
                        numArray[index] = int.Parse(Console.ReadLine());
                        index++;
                        continue;
                    }
                    Console.WriteLine("Choose a password(8-digits or more)");
                    strArray[2] = Console.ReadLine();
                    if (strArray[2].Length < 8)
                    {
                        str = str + "*Password to short\n";
                    }
                    Console.WriteLine("Enter Email");
                    strArray[3] = Console.ReadLine();
                    char[] separator = new char[] { '@' };
                    if (strArray[3].Split(separator).Length <= 1)
                    {
                        str = str + "*Invalid Email address\n";
                    }
                    if (str.Length < 1)
                    {
                        item = new Diver(strArray[0], strArray[1], num, new DateTime(numArray[0], numArray[1], numArray[2]), strArray[2], strArray[3]);
                        diverList.Add(item);
                        Console.WriteLine(item.name + " was added Successfuly");
                        Console.ReadKey();
                        Console.Clear();
                        return item;
                    }
                    else
                    {
                        Console.WriteLine(str + "\nTry again, press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    break;
                }
            }
            catch (Exception exception1)
            {
                Console.WriteLine(exception1.Message);
                Console.WriteLine("Try again,dont give up, Press any key to continue");
                Console.ReadKey();
            }
            return null;
        }

        private static void Main(string[] args)
        {
            // Invalid method body.
        }

        private static string SetDate(DateTime date_to_check)
        {
            string str;
            string sel()
            {
                Console.WriteLine("Try again? press 1,OR 0 To send '00-00-00'");
                str = Console.ReadLine();
                string str = str;
                if (str == "1")
                {
                    return SetDate(date_to_check);
                }
                if (str == "0")
                {
                    return "0";
                }
                sel();
                return null;
            }
            DateTime time;
            Console.WriteLine("Type Year");
            Console.WriteLine("Type Month");
            Console.WriteLine("Type Day");
            if (!DateTime.TryParse(((("" + Console.ReadLine()) + "-" + Console.ReadLine()) + "-" + Console.ReadLine()) ?? "", out time))
            {
                Console.WriteLine("Invalid date");
                return sel();
            }
            if (time.CompareTo(date_to_check) < 0)
            {
                Console.WriteLine("Date added successfuly " + time.ToShortDateString() + "press enter");
                Console.ReadKey();
                return time.ToShortDateString();
            }
            Console.WriteLine("Invalid date");
            str = sel();
            return null;
        }

        private static DateTime SetTime(DateTime dive_date)
        {
            while (true)
            {
                Console.WriteLine("Hours");
                int hour = int.Parse(Console.ReadLine());
                if ((hour >= 0) && (hour <= 0x18))
                {
                    while (true)
                    {
                        Console.WriteLine("Minutes");
                        int minute = int.Parse(Console.ReadLine());
                        if ((minute >= 0) && (minute <= 0x3b))
                        {
                            return new DateTime(dive_date.Year, dive_date.Month, dive_date.Day, hour, minute, 0);
                        }
                    }
                }
            }
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly Program.<>c <>9 = new Program.<>c();
            public static Predicate<DIveClub> <>9__3_3;
            public static Predicate<DIveClub> <>9__3_4;
            public static Predicate<DIveClub> <>9__3_5;
            public static Predicate<DIveClub> <>9__3_6;
            public static Predicate<DIveClub> <>9__3_7;
            public static Predicate<DIveClub> <>9__3_8;
            public static Predicate<DIveClub> <>9__3_9;
            public static Predicate<DIveClub> <>9__3_10;
            public static Predicate<DIveClub> <>9__3_11;
            public static Predicate<Diver> <>9__3_12;
            public static Predicate<DIveClub> <>9__3_13;
            public static Predicate<DIveClub> <>9__3_14;
            public static Predicate<DIveClub> <>9__3_15;
            public static Predicate<DIveClub> <>9__3_16;
            public static Predicate<Diver> <>9__3_17;
            public static Predicate<DIveClub> <>9__3_18;
            public static Predicate<Diver> <>9__3_19;
            public static Predicate<DIveClub> <>9__3_20;
            public static Predicate<DIveClub> <>9__3_21;
            public static Predicate<DIveClub> <>9__3_22;
            public static Predicate<Diver> <>9__3_30;

            internal bool <Main>b__3_10(DIveClub x) => 
                (x != null) ? (x.club_name == "ThaiDive") : false;

            internal bool <Main>b__3_11(DIveClub x) => 
                (x != null) ? (x.club_name == "LatviaScubaz") : false;

            internal bool <Main>b__3_12(Diver x) => 
                x.diver_ID == 0x1e240;

            internal bool <Main>b__3_13(DIveClub x) => 
                (x != null) ? (x.licence == (0.ToString() + "2")) : false;

            internal bool <Main>b__3_14(DIveClub x) => 
                (x != null) ? (x.licence == (0.ToString() + "2")) : false;

            internal bool <Main>b__3_15(DIveClub x) => 
                (x != null) ? (x.licence == "ISR1") : false;

            internal bool <Main>b__3_16(DIveClub x) => 
                (x != null) ? (x.licence == "ISR1") : false;

            internal bool <Main>b__3_17(Diver x) => 
                x.diver_ID == 0xa2c2a;

            internal bool <Main>b__3_18(DIveClub x) => 
                (x != null) ? (x.licence == (3.ToString() + "1")) : false;

            internal bool <Main>b__3_19(Diver x) => 
                x.diver_ID == 0x6c81c;

            internal bool <Main>b__3_20(DIveClub x) => 
                (x != null) ? (x.licence == (7.ToString() + "1")) : false;

            internal bool <Main>b__3_21(DIveClub x) => 
                (x != null) ? (x.licence == (7.ToString() + "1")) : false;

            internal bool <Main>b__3_22(DIveClub x) => 
                (x != null) ? (x.licence == (4.ToString() + "1")) : false;

            internal bool <Main>b__3_3(DIveClub x) => 
                (x != null) ? (x.club_name == "KazakhstanDivers") : false;

            internal bool <Main>b__3_30(Diver x) => 
                x != null;

            internal bool <Main>b__3_4(DIveClub x) => 
                (x != null) ? (x.club_name == "WestMalaysiaDC") : false;

            internal bool <Main>b__3_5(DIveClub x) => 
                (x != null) ? (x.club_name == "EilatDive") : false;

            internal bool <Main>b__3_6(DIveClub x) => 
                (x != null) ? (x.club_name == "EilatDive") : false;

            internal bool <Main>b__3_7(DIveClub x) => 
                (x != null) ? (x.club_name == "AcreDiveClub") : false;

            internal bool <Main>b__3_8(DIveClub x) => 
                (x != null) ? (x.club_name == "Blue Lagoon") : false;

            internal bool <Main>b__3_9(DIveClub x) => 
                (x != null) ? (x.club_name == "BrazilDive") : false;
        }
    }
}

