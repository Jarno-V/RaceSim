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
        public LinkedList<Section> Sections;

        public Track(String Name, SectionTypes[] sections) {
            this.Name = Name;
            this.Sections = ConvertSections(sections);
        }

        public LinkedList<Section> ConvertSections(SectionTypes[] sections)
        {
            LinkedList<Section> Sections = new LinkedList<Section>();
            foreach (SectionTypes s in sections) {
                Section section = new Section();
                section.SectionType = s;
                Sections.AddLast(section);
            }
            return Sections;
        }
    }
}
