using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class SantaHelperShould
    {
        SantaHelper _helper = new SantaHelper();
        public SantaHelperShould()
        {
            _helper = new SantaHelper();
        }

        [Fact]
        public void AddToyToChildsBag()
        {
            string toyName = "Skateboard";
            int childId = 715;
            int toyId = _helper.AddToyToBag(toyName, childId);
            List <int> toys = _helper.GetChildsToys(childId);

            Assert.Contains(toyId, toys);
        }
            [Fact]
            public void RvokeToyBag(){
            int childId = 715;
            int toyId = 716;
            List<int> remaingToys = _helper.RemoveChildToys(toyId);
            Assert.DoesNotContain(toyId, remaingToys);
            }
            
        
    }
}
