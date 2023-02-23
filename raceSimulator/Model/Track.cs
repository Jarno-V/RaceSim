using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class Track
    {
        public string Name;
        LinkedList<Section> Sections = new LinkedList<Section>();

        public Track(String Name, SectionTypes[] sections) {

        }
    }
}
