﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IEquipment
    {
        public int Quility { get; set; }
        public int Performance { get; set; }
        public int Speed { get; set; }
        public bool isBroken { get; set; }

    }
}
