using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBobby1
{
    public class DeliveryTruck
    {
        public int weightcapacity;
        public int currentweight;

        public Queue<Item> deliveryitems = new Queue<Item>();

        public Robot loadingrobot = new Robot();

        public WarehouseComputer whcomp = new WarehouseComputer();


        //fill the deliveryitems field of the deliverytruck with the robots carried items, 

        //call if robot is at row 4, column 1 or 2, and dtruck_parked = true, and restockingrobot.carrieditems.count== 1 (for robot can only carry 1 item at a time)

        public void robot_loaddelivery(Robot loadingrobot, WarehouseComputer whcomp)
        {
            if (loadingrobot.carrieditems.Count > 0)
            {
                //if whcomp.dtruck_parked = true
                deliveryitems.Enqueue((loadingrobot.carrieditems.Dequeue()));//take item out of robots carriedtems queue and place on delivery trucks deliveryitems queue
                loadingrobot.donetask = true;//'set done task flag to true
                loadingrobot.isloading = true;//this should probably be somewhere else
                                              //if loading is done, set isloading to false
                if (deliveryitems.Count == whcomp.deliveryorder.Count)
                {
                    loadingrobot.isloading = false;
                    whcomp.dtruck_parked = false;
                }

            }
        }







    }
}
