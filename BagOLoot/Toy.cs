using System;

namespace BagOLoot 
{
    public class Toy
    {
        public string ToyName {get;}
        public int childId {get;}
        public int ToyId {get;}

        public Toy (int ToyIdnew, String ToyNamenew, int childIdnew) 
        {
            ToyId = ToyIdnew;
            ToyName = ToyNamenew;
            childId = childIdnew;

        }
    }
}