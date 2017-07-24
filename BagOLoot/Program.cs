using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Collections;

namespace BagOLoot

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new DatabaseInterface();
            db.Check();

            Console.WriteLine ("WELCOME TO THE BAG O' LOOT SYSTEM");
            Console.WriteLine ("*********************************");
            Console.WriteLine ("1. Register a child");
            Console.WriteLine("2. Assign toy to a child");
            Console.WriteLine("3. Revoke toy from child");
            Console.WriteLine("4. Review childs toy list");
            Console.WriteLine("5. Child toy delivery complete");
            Console.WriteLine("6. Yuletime Delivery Report");
            
			Console.Write ("> ");

			// Read in the user's choice
			int choice;
			Int32.TryParse (Console.ReadLine(), out choice);

            if (choice == 1)
            {
                Console.WriteLine ("Enter child name");
                Console.Write ("> ");
                string childName = Console.ReadLine();
                ChildRegister registry = new ChildRegister();
                bool childId = registry.AddChild(childName);
                Console.WriteLine(childId);
            }else if (choice == 2)
            {
                Console.WriteLine("Enter child Id to  Assign toy to a child");
                ChildRegister childList2 = new ChildRegister();
                List<Child> things = childList2.GetChildren();
                foreach (var item in things)
                {
                    Console.WriteLine($"{item.childId}" + ".  " + $"{item.name}");
                }
                Console.WriteLine("Assign toy to which child");
                Console.Write("> ");
                int ChildId2 = int.Parse(Console.ReadLine());

                // Loop through the dataset to find the selected child
                foreach(var item in things.Where (item => item.childId == ChildId2)){
                    Console.WriteLine("Enter toy to add to " + item.name +"'s  Bag o'Loot");    
                }
                Console.Write("> ");
                string toyName2 = Console.ReadLine();
                Console.WriteLine();
                AddToy donatedToy = new AddToy();
                bool ToyId = donatedToy.AssignToy(ChildId2, toyName2);


            }
            else if (choice == 3){
                //Revoked
            //Displaying chilList again
             Console.WriteLine("Remove toy from which child");
                ChildRegister ChildList3 = new ChildRegister();
                List<Child> allChild = ChildList3.GetChildren();
                foreach (var child3 in allChild)
                {
                    Console.WriteLine($"{child3.childId}" + ".  " + $"{child3.name}");
                }
                Console.WriteLine("");
                Console.Write("> ");
                int ChildId3 = int.Parse(Console.ReadLine());
                  foreach(var child3 in allChild.Where (child3 => child3.childId == ChildId3)){
                    Console.WriteLine("Choose toy to revoke from " + child3.name +"'s  Bag o'Loot");    
                }

                AddToy ToyList = new AddToy();
                List<Toy> Toynew3 = ToyList.GetToy(ChildId3);
                foreach (var toy3 in Toynew3)
                {
                    Console.WriteLine($"{toy3.ToyId}" + ".  " + $"{toy3.ToyName}");
                }
                Console.Write("> ");

                int toyId3 = int.Parse(Console.ReadLine());
                Console.WriteLine();
                revokeToy RemovedToy = new revokeToy();
                bool ToyId = RemovedToy.toyRevoke(ChildId3, toyId3);

            }else if (choice == 4){

                //Review
                Console.WriteLine("View Bag o' Loot for which child?");
                ChildRegister ChildList4 = new ChildRegister();
                List<Child> allChild4 = ChildList4.GetChildren();
                foreach (var child4 in allChild4)
                {
                    Console.WriteLine($"{child4.childId}" + ".  " + $"{child4.name}");
                }
                Console.WriteLine("");
                Console.Write("> ");
                int ChildId4 = int.Parse(Console.ReadLine());
                  foreach(var child4 in allChild4.Where (child4 => child4.childId == ChildId4)){
                    Console.WriteLine(child4.name + "'s  Bag o'Loot");    
                }

                AddToy ToyList = new AddToy();
                List<Toy> Toynew4 = ToyList.GetToy(ChildId4);
                foreach (var toy4 in Toynew4)
                {
                    Console.WriteLine($"{toy4.ToyId}" + ".  " + $"{toy4.ToyName}");
                }


            }else if (choice == 5){
                //Delivery
                Console.WriteLine("Which child had all of their toys delivered?");
                ChildRegister childList2 = new ChildRegister();
                List<Child> things = childList2.GetChildren();
                foreach (var item in things)
                {
                    Console.WriteLine($"{item.childId}" + ".  " + $"{item.name}");
                        }
                Console.WriteLine("Which child had all of their toys delivered?");
                Console.Write("> ");
                int ChildId5 = int.Parse(Console.ReadLine());
                // Loop through the dataset to find the selected child
                   deliverToy deliveryMan = new deliverToy();

                   deliveryMan.toyDelivered(ChildId5);
        
                Console.Write("> ");
               
            }else if (choice == 6){
                //Report
                
                Console.WriteLine("Yuletime Delivery Report");
                Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%");

                ChildRegister childList2 = new ChildRegister();
                List<Child> things = childList2.GetChildren();
                
                AddToy toylist6 = new AddToy();
                List<Toy> toy6 = toylist6.ListToy();

                
                foreach (var item in things){
                
                    Console.WriteLine($"{item.childId}" + ".  " + $"{item.name}");
                
                    foreach (var itemtoy6 in toy6.Where (itemtoy6 => itemtoy6.childId == item.childId)){
                
                        Console.WriteLine($"             {itemtoy6.ToyName}");

                    }
                  
                }
                          
            }
        }
    }
             
}

        
    



               
 