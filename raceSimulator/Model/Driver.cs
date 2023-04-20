using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Driver : IParticipant
    {
        private string _name;
        private int _points;
        private int[] _startposition;
        public IEquipment Equipment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TeamColors TeamColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name {
            get { return _name; }
            set { _name = value; }
        }
        public int Points {
            get { return _points; }
            set { _points = value; }
        }

        public int[] StartPosition
        {
            get { return _startposition; }
            set { _startposition = value; }
        }
    }
}
