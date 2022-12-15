using System;
using System.ComponentModel;

namespace Birdz
{
    /**
     * Entry object that handles input
     */
    [Serializable()]
    public class Entry : IEquatable<Entry>
    {
        String title;
        String name;
        String date;
        String location;
        String notes;

        public String Title { get { return title; } set { title = value;} }
        public String Name { get { return name; } set { name = value; } }
        public String Date { get { return date; } set { date = value; } }
        public String Location { get { return location; } set { location = value; } }
        public String Notes { get { return notes; } set { notes = value; } }

        public Entry(String title, String name, String date, String location, String notes)
        {
            this.title = title;
            this.name = name;
            this.date = date;
            this.location = location;
            this.notes = notes;
        }

        /**
         * Checks if sent object's id is equal to this object's id
         */
        public bool Equals(Entry other)
        {
            return Title == other.Title;
        }
    }
}
