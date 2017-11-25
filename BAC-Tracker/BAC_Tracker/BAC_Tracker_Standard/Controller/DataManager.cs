using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using SQLite;

namespace BAC_Tracker.Droid.Controller
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
                db.CreateTable<Preferences>();
                string result = "Created Table Successfully";
                return result;

            }
            catch (Exception ex)
            {
                return "error" + ex.Message;
            }
        }

        //Add Gender to Table
        public string InsertGender(bool ismale)
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Person.db");
                var db = new SQLiteConnection(dbPath);

                


                return "Gender added";
            }
            catch (Exception ex)
            {
                return "error" + ex.Message;
            }
        }
    }

        
}