using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBobby1
{
    public class Shelf//shelf will be analogous to a tile in the layout grid, Shelf here could be replaced with tile
    {
        public static int numofshelves = 6;// should this go here or somewhere else? this is the height of the shelves

        // public Item[] leftShelves;
        // public Item[] rightShelves;

        public Item[] leftShelves = new Item[numofshelves];
        public Item[] rightShelves = new Item[numofshelves];

        public Item empty = new Item("empty", 0);

        //instantiate warehouse computer
        public WarehouseComputer whcinstance = new WarehouseComputer();


        public Shelf()
        {

        }

        //public Shelf(Item[] aleftshelves, Item[] arightshelves)
        //{
        //    leftShelves = aleftshelves;
        //    rightShelves = arightshelves;

        //}

       // public Item[] rightShelves1 = new Item[6];

        //weight stuff
        public const int shelfcapacity = 100; //100lb total shelf capacity for each Item array
        public int leftShelvesWeight;
        public int rightShelvesWeight;

        //coordinate stuff
        public int shelf_rownum;
        public int shelf_colnum;


        public bool isShelf;//0 if square in layout has no shelves next to it, 1 if it has at least 1 shelf next to it

        public bool isOccupied_Rob;//1 if there is a robot in that spot, 0 if no robot in that spot

        public Robot robo = new Robot(); //is instantiating the robot class within shelf the right idea?

        //public Shelf()
        //{
        //    leftShelves = new Item[numofshelves];
        //    rightShelves = new Item[numofshelves];
        //    isOccupied_Rob = false;


        //}

        
        //restock method in Shelf class that the robot will call
        //use Array.IndexOf(array,empty)
        public void restock(Shelf[,] warehouselayout, Robot robo, Item empty, WarehouseComputer whcinstance)
        {
            if (robo.carrieditems.Count > 0)
            {
                int leftshelves_firstempty;
                int rightshelves_firstempty;



                //--------------------end columns situations----------
                if (robo.robo_colnum == 0 || robo.robo_colnum == 7)
                {

                    if (robo.robo_colnum == 0)
                    {
                        rightshelves_firstempty = Array.IndexOf(warehouselayout[robo.robo_rownum, robo.robo_colnum].rightShelves, empty);//check if rightshelves are full, find index of first right subshelf thats empty

                        if (rightshelves_firstempty != -1)//if rightshelves are not full
                        {
                            whcinstance.warehouseinventory.Add(String.Format("{0}{1}R{2}",robo.robo_rownum,robo.robo_colnum,rightshelves_firstempty),robo.carrieditems.Peek());
                            warehouselayout[robo.robo_rownum, robo.robo_colnum].rightShelves[rightshelves_firstempty] = robo.carrieditems.Dequeue();//copy the contents of robots carried items to the shelves array
                            robo.donetask = true;
                        }

                        return;
                    }


                    else if (robo.robo_colnum == 7)
                    {
                        leftshelves_firstempty = Array.IndexOf(warehouselayout[robo.robo_rownum, robo.robo_colnum].leftShelves, empty);//check if leftshelves are full, and find index of first left subshelf thats empty

                        if (leftshelves_firstempty != -1)//if leftshelves are not full
                        {
                            whcinstance.warehouseinventory.Add(String.Format("{0}{1}L{2}", robo.robo_rownum, robo.robo_colnum, leftshelves_firstempty), robo.carrieditems.Peek());
                            warehouselayout[robo.robo_rownum, robo.robo_colnum].leftShelves[leftshelves_firstempty] = robo.carrieditems.Dequeue();//copy the contents of robots carried items to the shelves array
                            robo.donetask = true;
                        }

                        return;
                    }

                }



                //-------------middle columns situations----------
                leftshelves_firstempty = Array.IndexOf(warehouselayout[robo.robo_rownum, robo.robo_colnum].leftShelves, empty);//check if leftshelves are full, and find index of first left subshelf thats empty
                rightshelves_firstempty = Array.IndexOf(warehouselayout[robo.robo_rownum, robo.robo_colnum].rightShelves, empty);//check if rightshelves are full, find index of first right subshelf thats empty

                if (leftshelves_firstempty != -1)//if leftshelves aren't full
                {
                    whcinstance.warehouseinventory.Add(String.Format("{0}{1}L{2}", robo.robo_rownum, robo.robo_colnum, leftshelves_firstempty), robo.carrieditems.Peek());
                    warehouselayout[robo.robo_rownum, robo.robo_colnum].leftShelves[leftshelves_firstempty] = robo.carrieditems.Dequeue();//copy the contents of robots carried items to the shelves array
                    robo.donetask = true;
                }


                else if (leftshelves_firstempty == -1)//if the left shelves are full
                {
                    if (rightshelves_firstempty != -1)//if rightshelves aren't full
                    {
                        whcinstance.warehouseinventory.Add(String.Format("{0}{1}R{2}", robo.robo_rownum, robo.robo_colnum, rightshelves_firstempty), robo.carrieditems.Peek());
                        warehouselayout[robo.robo_rownum, robo.robo_colnum].rightShelves[rightshelves_firstempty] = robo.carrieditems.Dequeue();//copy the contents of robots carried items to the shelves array
                        robo.donetask = true;
                    }
                }


            }
        }



        // if (robo.isloading == true && robo.robo_rownum == robo.itemtofind_coord[1] && robo.robo_colnum == robo.itemtofind_coord[0])
        //when robot is loading and moving up moving up load aisle, or moving down load aisle, check the coordinate, if coordinate matches then run fetchitem
        public void fetchitem( Shelf[,] warehouselayout, Robot robo, WarehouseComputer whcinstance, Item empty)
        {
            int indexofitem = (int)Char.GetNumericValue(robo.itemtofind_coord[3]);

            if (robo.isloading == true && robo.robo_rownum == (int)Char.GetNumericValue(robo.itemtofind_coord[1]) && robo.robo_colnum == (int)Char.GetNumericValue(robo.itemtofind_coord[0]))//put the condition to run inside of the fetchitem function
            {

                if (robo.itemtofind_coord[2] == 'L')
                {
                    //enque that item onto the robots carrieditems que
                    robo.carrieditems.Enqueue(warehouselayout[robo.robo_rownum, robo.robo_colnum].leftShelves[indexofitem]);

                    //set the value of the item array at that index to empty
                    warehouselayout[robo.robo_rownum, robo.robo_colnum].leftShelves[indexofitem] = empty;

                    //reassign the value of the warehousedictionary at itemtofind_coord to empty
                    whcinstance.warehouseinventory[robo.itemtofind_coord] = empty;

                }


                else if (robo.itemtofind_coord[2] == 'R')
                {
                    robo.carrieditems.Enqueue(warehouselayout[robo.robo_rownum, robo.robo_colnum].rightShelves[indexofitem]);
                    warehouselayout[robo.robo_rownum, robo.robo_colnum].rightShelves[indexofitem] = empty;
                    whcinstance.warehouseinventory[robo.itemtofind_coord] = empty;

                }


            }


        }













    }
}
