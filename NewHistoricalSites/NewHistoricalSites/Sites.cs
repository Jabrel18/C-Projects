using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHistoricalSites
{
    class Sites
    {
        public string SiteName { set; get; }
        public double Latitude { set; get; }
        public double Longitude { set; get; }
        public string Description { set; get; }
        public List<string> Towns { set; get; }
        public static int NumberOfSites { private set; get; }


        public Sites()
        {

        }

        public Sites(string siteName, double latitude, double longitude, 
            string description, List<string> towns)
        {
            SiteName = siteName;
            Latitude = latitude;
            Longitude = longitude;
            Description = description;
            Towns = towns;
            NumberOfSites++;
          
        }
    }
}
