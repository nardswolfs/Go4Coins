﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPEindopdracht.GPSConnections
{
    /// <summary>
    /// GCoordinate is a base coordinate with only latitude and longitude
    /// </summary>
    class GCoordinate
    {
        /// <summary>
        /// latitude of the coordinate
        /// </summary>
        private double lati { get; set; }
        /// <summary>
        /// longitude of the coordinate
        /// </summary>
        private double longi { get; set; }

        /// <summary>
        /// Base constructor for a GCoordinate
        /// </summary>
        /// <param name="lati">latitude of coordinate<see cref="lati"/></param>
        /// <param name="longi">longitude of coordinate<see cref="longi"/></param>
        public GCoordinate(double lati, double longi)
        {
            this.lati = lati;
            this.longi = longi;
        }
    }

    /// <summary>
    /// Civil coordinate adds other components to give a coordinate more options and details
    /// </summary>
    class CivilCoordinate : GCoordinate
    {
        /// <summary>
        /// Civil address of the location in form of streetname
        /// </summary>
        private string address { get; set; }
        /// <summary>
        /// Civil address of the location in form of place like cityname
        /// </summary>
        private string place { get; set; }
        /// <summary>
        /// Civil address of the location in form of country like Netherlands and Germany
        /// </summary>
        private string country { get; set; }
        /// <summary>
        /// Civil address of the location in form of postal code like 4040EC
        /// </summary>
        private string postal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lati">Latitude of location <see cref="lati"/></param>
        /// <param name="longi">Longitude of location <see cref="longi"/></param>
        /// <param name="address">Address of location <see cref="address"/></param>
        /// <param name="place">Place of location <see cref="place"/></param>
        /// <param name="country">Country of location <see cref="country"/></param>
        /// <param name="postal">Postal of location <see cref="postal"/></param>
        public CivilCoordinate(double lati, double longi, string address, string place, string country, string postal = null) : base(lati, longi)
        {
            this.address = address;
            this.place = place;
            this.country = country;
            this.postal = postal;
        }
    }
}
