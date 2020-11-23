﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolesaEndTerm.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int Engine { get; set; }
        public string Probeg { get; set; }
        public int WheelId { get; set; }
        public Wheel Wheel { get; set; }
        public string Color { get; set; }
        public int PrivodId { get; set; }
        public Privod Privod { get; set; }
        public bool Raztamojen { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }

    }
}
