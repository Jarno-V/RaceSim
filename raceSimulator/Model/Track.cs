using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Track
    {
        public string Name;
        LinkedList<Section> Sections;

        public Track(String Name, SectionTypes[] sections) {
            this.Name = Name;
        }
    }
}
