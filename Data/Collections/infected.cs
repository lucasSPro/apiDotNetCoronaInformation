using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace ApiDotNet.Data.Collections
{
    public class infected
    {
        public infected(DateTime bourDate, string sex, double latidude, double longitude){
            this.BourDate = bourDate;
            this.Sex =  sex;
            this.Localization = new GeoJson2DGeographicCoordinates(longitude, latidude);
        }
        public DateTime BourDate {get; set;}
        public string Sex { get; set;}

        public GeoJson2DGeographicCoordinates Localization {get; set;}
    }
}