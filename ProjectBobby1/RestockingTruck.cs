using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBobby1
{
    public class RestockingTruck
    {
        public int weightcapacity;
        public int currentweight;

        //  public Item[] restockingitems;
        public Queue<Item> restockingitems = new Queue<Item>();

        public Robot restockingrobot = new Robot();

        public WarehouseComputer whcomp = new WarehouseComputer();



        //a lot of these methods below are ones that the robot object will call?

        //function to fill the robots item array with some items from the restock truck
        //fill until robots array is full/robots carry weight cannot support any more items
        //will set isunloading status of robot to true at end

        //call if robot is at row 4, column 3 or 4, and rtruck_parked = true, and restockingrobot.carrieditems.count== 0 (for robot can only carry 1 item at a time)
        public void robot_restock(Robot restockingrobot, WarehouseComputer whcomp)
        {
            if (whcomp.rtruck_parked == true)
            {
                //grab first item from start of queue in truck and place in robots carried items queue
                restockingrobot.carrieditems.Enqueue(restockingitems.Dequeue());
                restockingrobot.isunloading = true;
                restockingrobot.donetask = false;
                if (restockingitems.Count == 0)
                {
                    whcomp.rtruck_parked = false;
                }
            }
        }







    }
}
