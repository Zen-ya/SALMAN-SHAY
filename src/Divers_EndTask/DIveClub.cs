namespace Divers_EndTask
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    internal class DIveClub : IComparable<DIveClub>, IEquatable<Countries>
    {
        private List<Site> sites;

        public DIveClub(string club_name, string contact_name, string address, Countries country, int phone, string Email, byte licence_NUM)
        {
            this.sites = new List<Site>();
            this.club_name = club_name;
            this.contact_name = contact_name;
            this.address = address;
            this.country = country;
            this.phone = phone;
            this.Email = Email;
            this.setLicence(licence_NUM);
        }

        public DIveClub(string club_name, string contact_name, string address, Countries country, int phone, string Email, byte licence_NUM, string web_address) : this(club_name, contact_name, address, country, phone, Email, licence_NUM)
        {
            this.web_address = web_address;
        }

        public void AddMultipleSites(List<Site> s)
        {
            for (int i = 0; i < s.Count; i++)
            {
                this.sites.Add(s[i]);
            }
        }

        public void AddSite(Site s)
        {
            this.sites.Add(s);
        }

        public Site ChooseSite(int i) => 
            this.sites[i];

        public int CompareTo(DIveClub DC) => 
            (DC != null) ? this.country.ToString().CompareTo(DC.country.ToString()) : 0;

        public bool Equals(Countries c) => 
            c == this.country;

        public List<Site> GetSiteList() => 
            this.sites;

        private void setLicence(byte licence_num)
        {
            this.licence = ((Coun_Short_names) this.country).ToString() + licence_num.ToString();
        }

        public void ViewSitesInClub()
        {
            for (int i = 0; i < this.sites.Count; i++)
            {
                Console.WriteLine(i.ToString() + ")" + this.sites[i].name);
            }
        }

        public string club_name { get; private set; }

        public string licence { get; private set; }

        public string contact_name { get; private set; }

        public string address { get; private set; }

        public Countries country { get; private set; }

        public int phone { get; private set; }

        public string Email { get; private set; }

        public string web_address { get; set; }
    }
}

