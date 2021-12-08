using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBobby1
{
    public class Robot
    {
        //data fields

        WarehouseComputer whcomp = new WarehouseComputer();

        //public Item[] carrieditems; //array of items to store the items the robot is carrying

        public Queue<Item> carrieditems = new Queue<Item>();

        public Item itemtofind = new Item();

        public Item empty = new Item("empty", 0);



        public int carryingcapacity;
        public int currentweight;

        public int robo_colnum;//start at this location for testing unloading
        public int robo_rownum;

        public bool isunloading; //true if unloading from restockingtruck, false if not
        public bool isloading; //true if fetching items for deliverytruck, false if not

        public int unloadaisle;
        public int loadaisle;

        public string itemtofind_coord;

        public bool donetask;


        public bool nextmoveup;
        public bool nextmovedown;
        public bool nextmoveright;
        public bool nextmoveleft;


        public Robot()
        {


        }



        //constructor for robot class
        public Robot(int spawnrownum, int spawncolnum)
        {
            carryingcapacity = 20;
            currentweight = 0;
            robo_colnum = spawncolnum;//spawn at left unloading bay for testing, could spawn an array along the bottom row starting from right end of row 4 
            robo_rownum = spawnrownum;
            isunloading = false;
            isloading = false;
            nextmoveleft = false;
            nextmoveright = false;
            nextmovedown = false;
            nextmoveup = false;
            donetask = false;
        }







        //main program will have an if statement that will increment/decrement the row or column coord data fields of the robot depending on if nextmove was "left" "right" "up" or "down"

        //methods


        //move robot function needs to update the robot position as well as the bool in the grid that says if theres a robot occupying that spot
        //need to pass in rownum and colnum by reference?
        //just pass in the robot object and use the . to change the data fields?
        //the moverobots function is what changes the rownum and colnum values of the robots


        //public void Moverobots()
        //{
        //    if (nextmoveup)
        //    {
        //        robo_rownum--;
        //        //update warehouselayout isroboccupied at the current and new spot indices
               
        //    }
               
        //    else if (nextmovedown)
        //        robo_rownum++;
        //    else if (nextmoveleft)
        //        robo_colnum--;
        //    else if (nextmoveright)
        //        robo_colnum++;

        //}


        public void Resetnextmoves()
        {
            nextmoveup = false;
            nextmovedown = false;
            nextmoveleft = false;
            nextmoveright = false;
        }

        

        //the array being passed into this will be 
        public void Chooseunloadaisle(Shelf[,] warehouselayout, Item empty)
        {
            int rightshelves_firstempty;
            int leftshelves_firstempty;

            if (robo_rownum == 4 && isunloading == true)
            {
                //iterate through the 1D left and right shelf arrays stored at each element of the 2D array to find the first occurence of 0, aka an empty shelf
                for (int i = 1;i<4; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        rightshelves_firstempty = Array.IndexOf(warehouselayout[i, j].rightShelves, empty);
                        leftshelves_firstempty = Array.IndexOf(warehouselayout[i, j].leftShelves, empty);
                        if (leftshelves_firstempty != -1 || rightshelves_firstempty != -1)//Array.Indexof returns -1 when it doesn't find element 0 anywhere (0 meaning empty shelf)
                        {
                            unloadaisle = j;
                            return;
                        }
                    }
                }
               // return -2;
            }

           // return -2;
        }



        //--------------------------------------------------------- PATHFINDING FUNCTIONS FOR UNLOADING TO AISLES 0,1,2, and 3 --------------------------------------




        //will be some if statements in program before i call this function, or do i have all the if statements inside and call all the functions each time?
        //need to pass the robot object in too?
        public void movetounloadaisle(Shelf[,] warehouselayout)
        {
            nextmoveleft = true;
        }

        public void moveupunloadaisle(Shelf[,] warehouselayout)
        {
            nextmoveup = true;
            //check if theres shelf space in the square to unload, if there is then call the restock method from shelf class


        }


        //pass in the 2D array of the warehouse layout
        public void Checktraffictop(Shelf[,] warehouselayout)
        {
            if (robo_rownum == 1 && warehouselayout[robo_rownum - 1, robo_colnum - 1].isOccupied_Rob && robo_colnum != 7 && robo_colnum != 0)
                nextmoveup = false;
            else if (robo_rownum == 1 && !warehouselayout[robo_rownum - 1, robo_colnum - 1].isOccupied_Rob && robo_colnum != 7 && robo_colnum != 0)
                nextmoveup = true;
        }




        public void robodonejob_sendbacktotrucks1()
        {
            nextmoveright = true;

        }

        public void robodonejob_sendbacktotrucks2()
        {
            nextmovedown = true;
        }

        public void robodonejob_sendbacktounloadingtrucks()
        {
            nextmoveleft = true;
            //if (robo_rownum == 4 && (robo_colnum == 3 || robo_colnum == 4))
               // return;
                //call robot_restock from restockinng truck ? or do that outside probably

        }



        //--------------------------------------------------------- PATHFINDING FUNCTIONS FOR UNLOADING TO AISLES 4,5,6, and 7 --------------------------------------


        //if unload aisle was 4,5,6,7

        public void movetoaisle3()
        {
            nextmoveleft = true;
            //if already in aisle 3 then next moveleft=false
        }

        public void moveupaisle3()
        {
            nextmoveup = true;


        }

        //use checktraffictop again here

        public void movetounloadaislefromtop()
        {
            nextmoveright = true;

        }

        public void movedownunloadaislefromtop()
        {
            nextmovedown = true;
            //check if theres shelf space in the square to unload, if there is then call the restock method from shelf class


        }

        //used for the robots travelling down 4 5 and 6 to check traffic before exiting the aisle
        public void checkbottomtraffic(Shelf[,] warehouselayout)
        {
            if (robo_rownum == 3 && warehouselayout[robo_rownum + 1, robo_colnum + 1].isOccupied_Rob && robo_colnum != 7)
                nextmovedown = false;
            else if (robo_rownum == 3 && robo_colnum > 3 && !warehouselayout[robo_rownum + 1, robo_colnum + 1].isOccupied_Rob && robo_colnum != 7)
                nextmovedown = true;
        }


        //will continue from robodonejob_sendbacktounloadingtrucks






        //------------PATHFINDING FUNCTIONS FOR TAKING ITEMS FROM AISLES------------


        //  returns the aisle number that has the item in it
        public void finditemaisle(Shelf[,] warehouselayout, WarehouseComputer whcomp)
        {
            if (robo_rownum == 4 && isloading == true)
            {
                //int loadaisle;
                //Item itemtofind = new Item();
                //string itemtofind_coord;
                itemtofind = whcomp.deliveryorderpopping[0];
                whcomp.deliveryorderpopping.RemoveAt(0); //pop the first item off the list

                itemtofind_coord = whcomp.warehouseinventory.FirstOrDefault(x => x.Value == itemtofind).Key;

                loadaisle = (int)Char.GetNumericValue(itemtofind_coord[1]);
                donetask = false;
            }
        
        }



        //--------------------------------------------------------- PATHFINDING FUNCTIONS FOR LOADING FROM AISLES 0,1 --------------------------------------


        public void movetoloadaisle(Shelf[,] warehouselayout)
        {
            nextmoveleft = true;
        }

        public void moveuploadaisle(Shelf[,] warehouselayout)
        {
            nextmoveup = true;
            //check if theres shelf space in the square to unload, if there is then call the restock method from shelf class


        }

        //will use checktraffictop around here
        //robodonejob_sendbacktotrucks1
        //robodonejob_sendbacktotrucks2


     
        public void robodonejob_sendbacktoloadingtrucks()
        {

            nextmoveleft = true;
            // if (robo_rownum == 4 && (robo_colnum == 1 || robo_colnum == 2))
          //  if (robo_rownum == 4 && robo_colnum == 2)
            //call robot_loaddelivery from delivery truck ? or do that outside probably

        }


        //--------------------------------------------------------- PATHFINDING FUNCTIONS FOR LOADING FROM AISLES 2-7 --------------------------------------


        //if load aisle was 3-7

        public void movetoaisle0()
        {
            nextmoveleft = true;
            //if already in aisle 1 then next moveleft=false
        }

        public void moveupaisle0()
        {
            nextmoveup = true;


        }

        //use checktraffictop again here

        public void movetoloadaislefromtop()
        {
            nextmoveright = true;

        }

        public void movedownloadaislefromtop()
        {
            nextmovedown = true;
            //move to the row from the coordinate, or check each shelf call the fetchitem method from shelf class


        }


        //used for the robots travelling down 2-6 to check traffic before exiting the aisle
       //checkbottomtraffic


        //will continue from robodonejob_sendbacktoloadingtrucks








        //getter functions to return the current coordinates of the robot in the warehouse grid
        public int getrownum()
        {
            return robo_rownum;
        }

        public int getcolnum()
        {
            return robo_colnum;
        }

    }
}
