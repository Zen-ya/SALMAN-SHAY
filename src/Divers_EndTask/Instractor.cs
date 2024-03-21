namespace Divers_EndTask
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    internal class Instractor : Diver
    {
        private Dictionary<string, DateTime[]> WorkHistroy;

        public Instractor(Diver d) : base(d)
        {
            this.WorkHistroy = new Dictionary<string, DateTime[]>();
        }

        public Instractor(string name, string last_name, int diver_ID, DateTime DOB, string password, string Email) : base(name, last_name, diver_ID, DOB, password, Email)
        {
            this.WorkHistroy = new Dictionary<string, DateTime[]>();
        }

        public bool ConfirmDive(DateTime dive_date, DIveClub d)
        {
            if (!this.WorkHistroy.ContainsKey(d.licence) || (((DateTime) this.WorkHistroy[d.licence].GetValue(0)).CompareTo(dive_date) != -1))
            {
                return false;
            }
            DateTime time = (DateTime) this.WorkHistroy[d.licence].GetValue(1);
            if (time.CompareTo(dive_date) == 1)
            {
                return true;
            }
            time = new DateTime();
            return (((DateTime) this.WorkHistroy[d.licence].GetValue(1)) == time);
        }

        public void EndWork(DIveClub club, DateTime end)
        {
            if (!this.WorkHistroy.ContainsKey(club.licence))
            {
                Console.WriteLine("Not registerd");
            }
            else
            {
                this.WorkHistroy[club.licence].SetValue(end, 1);
            }
        }

        public string GetWorkHistory()
        {
            string str = "Work History:\n";
            int num = 1;
            foreach (KeyValuePair<string, DateTime[]> pair in this.WorkHistroy)
            {
                str = str + $"{num++}Club ID: {pair.Key},Start Date: {((DateTime) pair.Value[0])} End Date: {((DateTime) pair.Value[1])}
";
            }
            return str;
        }

        public string GetWorkHistoryInClub(DIveClub c) => 
            !this.WorkHistroy.ContainsKey(c.licence) ? "No History" : $"Club: {c.club_name},Start Date: {this.WorkHistroy[c.licence].GetValue(0)} End Date: {this.WorkHistroy[c.licence].GetValue(1)}";

        public void StartWork(DIveClub club, DateTime start)
        {
            this.WorkHistroy.Add(club.licence, new DateTime[2]);
            this.WorkHistroy[club.licence].SetValue(start, 0);
        }

        private DateTime start_work { get; set; }

        private DateTime end_work { get; set; }
    }
}

