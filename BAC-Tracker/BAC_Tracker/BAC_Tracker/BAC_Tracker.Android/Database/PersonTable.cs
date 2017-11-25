using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using SQLite;

namespace BAC_Tracker.Droid.Fragments
{
    //Had to recreate the Person class in Android to get the SQLite working properly.
    [Table("Person")]
    class Person
    {
        public bool IsMale { get; set; }
        public double Weight { get; set; }

        //Will put list of drinks in the Event class.
        public Person()
        {

        }
        public Person(bool isMale, double weight)
        {
            IsMale = isMale;
            Weight = weight;

        }
    }
}