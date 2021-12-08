using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBobby1
{
    class UnitTest
    {
        static void Main()
        {
            try
            {
                Item TestItem1 = new Item("Airpod", 35);
                Item TestItem2 = new Item("Bag", 55);
                Item TestItem3 = new Item("Cool Thing", 775);

                if (TestItem1.name != "Airpod" && TestItem1.weight != 35)
                    throw new Exception("Item1 has wrong value");

                if (TestItem2.name != "Bag" && TestItem1.weight != 55)
                    throw new Exception("Item 2 has wrong value");

                if (TestItem3.name != "Cool Thing" && TestItem1.weight != 775)
                    throw new Exception("Item3 has wrong value");

                Queue<Item> testerQueue = new Queue<Item>();
                testerQueue.Enqueue(TestItem1);
                testerQueue.Enqueue(TestItem2);
                if(testerQueue == null)
                    throw new Exception("Queue(list) of items for truck is empty");

                Dictionary<string, Item> warehouseinventory = new Dictionary<string, Item>();
                warehouseinventory.Add("1", TestItem1);
                warehouseinventory.Add("2", TestItem2);
                warehouseinventory.Add("3", TestItem3);
                if (warehouseinventory == null)
                    throw new Exception("Warehouse Inventory not updated and it is empty");

                List<Item> deliveryorder = new List<Item>();
                deliveryorder.Add(TestItem1);
                deliveryorder.Add(TestItem2);
                deliveryorder.Add(TestItem3);
                if (deliveryorder == null)
                    throw new Exception("Delivery order not updated and it is empty");

                Queue<DeliveryTruck> waitingline = new Queue<DeliveryTruck>();
                waitingline.Enqueue(new DeliveryTruck());
                waitingline.Enqueue(new DeliveryTruck());
                if (waitingline == null)
                    throw new Exception("Waiting line for trucks when bay is full is not updated");

                Console.WriteLine("No errors");
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadLine();

        }

    }
}
