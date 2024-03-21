namespace Divers_EndTask
{
    using System;
    using System.Runtime.CompilerServices;

    internal class Site : IEquatable<Countries>
    {
        public Site(string name, string address, string description, double depth_in_meters, bool saltyWater, Countries country, DIveClub in_diveClub)
        {
            this.name = name;
            this.address = address;
            this.description = description;
            this.depth_in_meters = depth_in_meters;
            this.saltyWater = saltyWater;
            this.country = country;
            this.in_diveClub = in_diveClub;
        }

        public bool Equals(Countries other) => 
            other == this.country;

        public string name { get; private set; }

        private string address { get; set; }

        private string description { get; set; }

        private double depth_in_meters { get; set; }

        private bool saltyWater { get; set; }

        public Countries country { get; private set; }

        public DIveClub in_diveClub { get; set; }
    }
}

