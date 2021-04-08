using System;
using System.Collections.Generic;
using System.Text;

namespace ParksGamification.Models
{
    public class Park
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Dimention Size { get; set; }

        public Location Address { get; set; } = new Location();

        public List<Amenity> Amenities { get; set; } = new List<Amenity>();

        public class Dimention
        {
            public int Width { get; set; }
            public int Length { get; set; }
            public int Height { get; set; }
        }


        public class Amenity
        {
            public Types Type { get; set; }
            public int Quantity { get; set; }
            public string Description { get; set; }
            public enum Types
            {
                Swing
                , Slide
                , MonkeyBar
                , Bathroom
                , Pool
                , SkatePark
                , IceRink
                , SplashPad
            }
        }

        public class Location
        {
            public int Number { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string Province { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
        }
    }
}
