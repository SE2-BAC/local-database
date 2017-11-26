using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using SQLite;

namespace BAC_Tracker.Droid.Fragments
{
    public class DataManager
    {
        //create the database 
        public string CreateDB()
        {
            var output = "";
            output += "creating database if it doesn't exist";
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Preferences.db");
            var db = new SQLiteConnection(dbPath);
            output += "\nDatabase created";
            return output;
        }

        //create Model Table
        public string CreateTable()
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Preferences.db");
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Person>();
                string result = "Created Table Successfully";
                return result;

            }
            catch (Exception ex)
            {
                return "error" + ex.Message;
            }
        }

        //Store gender and weight to Table
        public string InsertPreference(bool ismale, double weight)
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Person.db");
                var db = new SQLiteConnection(dbPath);
                Person model = new Person();
                model.IsMale = ismale;
                model.Weight = weight;
                db.Insert(model);

                return "Gender and weight saved";
            }
            catch (Exception ex)
            {
                return "error" + ex.Message;
            }
        }

       //Update settings
        public void UpdateRecord(int id, string gender, int weight)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Person.db");
            var db = new SQLiteConnection(dbPath);

            var item = db.Get<Person>(id);
            item.Gender = gender;
            item.Weight = weight;
            db.Update(item);
            
        }
        
        //Return weight
        public string RetrieveWeight()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Person.db");
            var db = new SQLiteConnection(dbPath);

            string output = "";
            output += "Retrieving the data using ORM";
            var table = db.Table<Person>();

            foreach (var item in table)
            {
                output += "\n" + item.Weight;
            }
            return output;
        }
        //Return gender
        public bool RetrieveGender()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Person.db");
            var db = new SQLiteConnection(dbPath);

            bool output = true;
            var table = db.Table<Person>();

            foreach (var item in table)
            {
                output = item.IsMale;
            }
            return output;
        }
    }

        
}
