using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBobby1
{
    public class WarehouseComputer
    {

        //implement inventory list here, list of all items stored in the warehouse, strings? store them as touples w locations?
        //use a dictionary for items and their location? this would be good if there's only 1 of each item, would be better if using item1 etc.
        //rather than reusing items

        //maybe do Dictionary<string,Item> instead
        //<key,value>   note keys are considered unique, so make the coordinate the key and the item the value
        public Dictionary<string, Item> warehouseinventory = new Dictionary<string, Item>();

        //coordinate system will use a string of format <row><column><side L or R><shelf from bottom>


        //use warehouseInventory.Add when an item gets added to the shelf, ie put it in the restock function
        //ie. warehouseinventory.Add("23R5", airpods)
        //reassign the value to 0 (or empty if i have to) when an item gets removed from the shelf,
        //ie. warehouseinventory["23R5"] = 0;


        //make deliveryitems a queue as well?
        public List<Item> deliveryorderpopping = new List<Item>();//list of items in the order, will be popped
        public List<Item> deliveryorder = new List<Item>();//list of items in the order, won't be popped, just clear at the end

        public List<Item> restockitems = new List<Item>();//arrives at warehouse in the restockingtruck (aka received)

        public List<Item> outfordelivery = new List<Item>();//list of items out for delivery

        //keep track of arrival/departure of delivery/restocking trucks

        public bool dtruck_parked = false; //true if there is a delivery truck parked, false if there isn't
        public bool rtruck_parked = false; //true if there is a restocking truck parked, false if there isn't







    }
}
