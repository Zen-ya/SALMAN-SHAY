namespace Divers_EndTask
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    internal class Dive
    {
        private Dictionary<Equipment, gear_amnt_comment> GearList = new Dictionary<Equipment, gear_amnt_comment>();

        public void AddGear(int i, int amnt, string comment)
        {
            gear_amnt_comment _comment = new gear_amnt_comment {
                equipment_type = (Equipment) i,
                amount = amnt,
                comment = comment
            };
            this.GearList.Add((Equipment) i, _comment);
        }

        public int GetGearAmount() => 
            this.GearList.Count;

        public string GetGearlist()
        {
            int num = 0;
            string str = "";
            foreach (gear_amnt_comment _comment in this.GearList.Values)
            {
                str = str + $"{num++}) Type: {_comment.equipment_type} Amount: {_comment.amount} Comment: {_comment.comment}";
            }
            return str;
        }

        public override string ToString()
        {
            string[] textArray1 = new string[12];
            textArray1[0] = "Dive Details:\n Dived Throgh: ";
            textArray1[1] = this.dive_club.club_name;
            textArray1[2] = " at the '";
            textArray1[3] = this.dive_site.name;
            textArray1[4] = "'\n Date ";
            textArray1[5] = this.date.ToShortDateString();
            textArray1[6] = " at: ";
            textArray1[7] = this.dive_time_start.ToShortTimeString();
            textArray1[8] = " until ";
            textArray1[9] = this.dive_time_end.ToShortTimeString();
            textArray1[10] = "\n";
            textArray1[11] = $" The Tide was: {this.tide}.
 Water Temperature: {this.temp}
The Dive was Confirmed By: {this.confirming_INST.name} ID: {this.confirming_INST.diver_ID}";
            return string.Concat(textArray1);
        }

        public DIveClub dive_club { get; set; }

        public Instractor confirming_INST { get; set; }

        public Site dive_site { get; set; }

        public DateTime date { get; set; }

        public DateTime dive_time_start { get; set; }

        public DateTime dive_time_end { get; set; }

        public double temp { get; set; }

        public Tide tide { get; set; }

        [StructLayout(LayoutKind.Sequential)]
        private struct gear_amnt_comment
        {
            public Equipment equipment_type;
            public int amount;
            public string comment;
        }
    }
}

