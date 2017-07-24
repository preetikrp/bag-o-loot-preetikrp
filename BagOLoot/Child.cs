using System;

namespace BagOLoot 
{
    public class Child
    {
        public string name {get;}
        public int childId {get;}
        public bool delivered {get;}

        public Child (string childName, int kidId, bool toyDelivered) 
        {
            name = childName;
            childId = kidId;
            delivered = toyDelivered;
        }
    }
}