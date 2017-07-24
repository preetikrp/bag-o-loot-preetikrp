using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class revokeToy
    {private List<Child> _children = new List<Child>();
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public revokeToy()
        {
            _connection = new SqliteConnection(_connectionString);
        }

        public bool toyRevoke (int childId, int toyId) 
        {
            int _lastId = 0; // Will store the id of the last inserted record
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Insert the new Toy
                dbcmd.CommandText = $"delete from Toy where toyID = '{toyId}' and childId =  '{childId}'";
                Console.WriteLine(dbcmd.CommandText);
                dbcmd.ExecuteNonQuery ();

                // Get the id of the new row
                dbcmd.CommandText = $"select last_insert_rowid()";
                using (SqliteDataReader dr = dbcmd.ExecuteReader()) 
                {
                    if (dr.Read()) {
                        _lastId = dr.GetInt32(0);
                    } else {
                        throw new Exception("Unable to insert value");
                    }
                }

                // clean up
                dbcmd.Dispose ();
                _connection.Close ();
            }

            return _lastId != 0;
        }

        public List<Child> GetChildren ()
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                //select the id and name of every child
                dbcmd.CommandText = "select id, name, delivered from child";

                using (SqliteDataReader dr = dbcmd.ExecuteReader())
                {
                    //Read each row in the result set
                    while (dr.Read())
                    {
                        Child newChild = new Child(dr[1].ToString(), dr.GetInt32(0), dr.GetBoolean(2));
                        _children.Add(newChild); //Add child name to list
                    }
                }

                //clean up
                dbcmd.Dispose ();
                _connection.Close ();
            }

            return _children;
            // return new List<string>();
        }

        public List<Child> GetChildrenParam(int childId){
            using(_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd2 = _connection.CreateCommand();
                //select the Id and name for the id entered

                dbcmd2.CommandText = $"select id, name, delivered from child where id = 3";//
                using(SqliteDataReader dr2 = dbcmd2.ExecuteReader())
                {
                    //Read each row in the result set
                    while(dr2.Read())
                    {

                    }


                }

                //clean up
                dbcmd2.Dispose();
                _connection.Close();
            }
            return _children;

        }
        

        public Child GetChild (int childId)
        {
            Child child = _children.SingleOrDefault(c => c.childId == childId);

            // Inevitably, two children will have the same name. Then what?

            return child;
        }
    }
}