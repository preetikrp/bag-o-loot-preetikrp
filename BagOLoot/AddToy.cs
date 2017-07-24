using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class AddToy
    {private List<Toy> _toys = new List<Toy>();
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public AddToy()
        {
            _connection = new SqliteConnection(_connectionString);
        }

        public bool AssignToy (int childId, string toyName) 
        {
            int _lastId = 0; // Will store the id of the last inserted record
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Insert the new Toy
                dbcmd.CommandText = $"insert into Toy values (null, '{toyName}', '{childId}')";
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

        public List<Toy> GetToy (int childId)
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                //select the id and name of every toy.
                dbcmd.CommandText = $"select toyId, toyname, childId from toy where childId = '{childId}'";

                using (SqliteDataReader dr = dbcmd.ExecuteReader())
                {
                    //Read each row in the result set
                    while (dr.Read())
                    {
                        Toy newToy = new Toy(dr.GetInt32(0), dr[1].ToString(), dr.GetInt32(2));
                        _toys.Add(newToy);
                         //Add toy name to list
                    }
                }

                //clean up
                dbcmd.Dispose ();
                _connection.Close ();
            }
            return _toys;
            // return new List<string>();
        }



        public List<Toy> ListToy ()
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                //select the id and name of every toy.
                dbcmd.CommandText = $"select toyId, toyname, childId from toy";

                using (SqliteDataReader dr1 = dbcmd.ExecuteReader())
                {
                    //Read each row in the result set
                    while (dr1.Read())
                    {
                        Toy newToy = new Toy(dr1.GetInt32(0), dr1[1].ToString(), dr1.GetInt32(2));
                        _toys.Add(newToy);
                         //Add toy name to list
                    }
                }

                //clean up
                dbcmd.Dispose ();
                _connection.Close ();
            }
            return _toys;
            // return new List<string>();
        }

        

        public Toy GetToys (int ToyId)
        {
            Toy toy = _toys.SingleOrDefault(t => t.ToyId == ToyId);

            
            return toy;
        }
    }
}