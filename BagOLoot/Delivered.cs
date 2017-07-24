using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class deliverToy
    {private List<Child> _children = new List<Child>();
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public deliverToy()
        {
            _connection = new SqliteConnection(_connectionString);
        }

        public void toyDelivered (int childId) 
        {
           // int _lastId = 0; // Will store the id of the last inserted record
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Insert the new Toy
                dbcmd.CommandText = $"update child set delivered = 1 where id = {childId}" ;
                Console.WriteLine(dbcmd.CommandText);
                dbcmd.ExecuteNonQuery ();

               

                // clean up
                dbcmd.Dispose ();
                _connection.Close ();
            }

            //return _lastId != 0;
        }

        }
    }
