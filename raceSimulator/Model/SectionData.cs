﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class SectionData : IParticipant
    {
        IParticipant left { get; set; }
        IParticipant right { get; set; }
        int DistanceLeft { get; set; }
        int DistanceRight { get; set; }



        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Points { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEquipment Equipment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TeamColors TeamColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }
}
