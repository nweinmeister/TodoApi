﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<State> States { get; set; }
    }
}
