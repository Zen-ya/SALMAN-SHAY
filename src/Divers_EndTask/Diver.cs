namespace Divers_EndTask
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    internal class Diver
    {
        protected int dive_stars;
        protected List<Dive> dive_log_Lt;

        public Diver(Diver d)
        {
            this.dive_log_Lt = new List<Dive>();
            this.name = d.name;
            this.last_name = d.last_name;
            this.diver_ID = d.diver_ID;
            this.dateOfBirth = d.dateOfBirth;
            this.password = d.password;
            this.Email = d.Email;
            this.dive_stars = 0;
        }

        public Diver(string name, string last_name, int diver_ID, DateTime DOB, string password, string Email)
        {
            this.dive_log_Lt = new List<Dive>();
            this.setName(name);
            this.last_name = last_name;
            this.diver_ID = diver_ID;
            this.dateOfBirth = DOB;
            this.password = password;
            this.Email = Email;
            this.dive_stars = 0;
        }

        public Diver(string name, string last_name, int diver_ID, DateTime DOB, string password, string Email, bool admin) : this(name, last_name, diver_ID, DOB, password, Email)
        {
            this.admin = admin;
            this.dive_stars = 0;
        }

        public void AddDive(Dive d)
        {
            this.dive_log_Lt.Add(d);
            if ((this.dive_log_Lt.Count > 0) && (((this.dive_log_Lt.Count % 10) == 0) && (this.dive_stars < 4)))
            {
                this.dive_stars++;
            }
        }

        public int GetDiveCount() => 
            this.dive_log_Lt.Count;

        public string GetDiverRank() => 
            this.dive_stars.ToString();

        public string GetDivesLog()
        {
            string str = "";
            foreach (Dive dive in this.dive_log_Lt)
            {
                str = str + dive.ToString() + "\n+++\nEquipment:\n" + dive.GetGearlist();
            }
            return str;
        }

        public bool IsMe(int id, string password) => 
            (this.diver_ID == id) && (this.password == password);

        protected void setName(string name)
        {
            if (name.Length < 1)
            {
                this.name = null;
            }
            else
            {
                this.name = name;
            }
        }

        public string name { get; protected set; }

        public string last_name { get; protected set; }

        public int diver_ID { get; protected set; }

        public DateTime dateOfBirth { get; protected set; }

        protected string password { get; set; }

        public string Email { get; protected set; }

        protected bool admin { get; set; }
    }
}

