﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.Models
{
    public class UnitManager
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
    }
}
