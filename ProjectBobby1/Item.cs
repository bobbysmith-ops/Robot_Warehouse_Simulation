using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBobby1
{
     public class Item
    {
        public int weight;
        public string name;

        public Item()
        {

        }


        //empty items will be declared as empty, name field as empty, and weight as 0
        public Item(string aname, int aweight)
        {
            name = aname;
            weight = aweight;

        }



    }
}
