using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProjectBobby1
{
    class Testing2
    {
        static void Main(string[] args)
        {


            //Shelf gridsquare = new Shelf();

            RestockingTruck rtruck = new RestockingTruck();

            DeliveryTruck dtruck = new DeliveryTruck();

            WarehouseComputer whcomp = new WarehouseComputer();

            Robot testrobo = new Robot(4, 6);//spawn test robot at row 4 column 6

            Item empty = new Item("empty", 0);

            Item item1 = new Item("item1", 0);
            Item item2 = new Item("item2", 0);
            Item item3 = new Item("item3", 0);
            Item item4 = new Item("item4", 0);
            Item item5 = new Item("item5", 0);

            Shelf[,] warehouselayout = new Shelf[5, 8]; //declare 2d array for warehouse layout with 5 rows and 8 columns

            ////'NEEDED TO INITIALIZE THE SQUARES IN THE ARRAY WITH A SHELF OBJECT BEFORE I CAN START ALTERING THE FIELDS, BASICALLY JUST TREATED IT LIKE AN EMPTY ARRAY BEFORE,
            ////'WITH NO SHELF OBJECTS, SO NO INSTANCES, 
            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        warehouselayout[i, j] = gridsquare;
            //        warehouselayout[i, j] = gridsquare;
            //    }
            //}

            //'NEEDED TO INITIALIZE THE SQUARES IN THE ARRAY WITH A SHELF OBJECT BEFORE I CAN START ALTERING THE FIELDS, IT BASICALLY JUST TREATED IT LIKE AN EMPTY ARRAY BEFORE,
            //'WITH NO SHELF OBJECTS, SO NO INSTANCES, YOU NEED TO FILL THE ARRAY WITH SHELF OBJECTS (AKA INITIALIZE IT WITH SHELF OBJECTS) BEFORE I CAN USE THE ELEMENTS OF
            //'THE ARRAY AND THE . TO ACCESS MEMBERS LIKE WITH warehouselayout[0, 0].isOccupied_Rob = false;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    warehouselayout[i, j] = new Shelf();
                    warehouselayout[i, j] = new Shelf();
                }
            }


            //far left and far right columns of warehouse
            //for loop to initialize the leftShelves and rightShelves 1D arrays
            //these arrays have already been declared and had their size set in the shelf class, so just need to initialize them aka fill with Item objects

            for (int i = 1; i < 4; i++)
            {
                // warehouselayout[i, 0].rightShelves = new Item[Shelf.numofshelves];//declare the rightShelves array with size 6 for the spots on left side of warehouse layout
                for (int k = 0; k < Shelf.numofshelves; k++)
                    warehouselayout[i, 0].rightShelves[k] = empty; //'same thing as before we need to initialize the rightshelves object array and fill it with objects, we'll set everything to an empty object at the start
            }

            for (int i = 1; i < 4; i++)
            {
                // warehouselayout[i, 7].leftShelves = new Item[Shelf.numofshelves];//declare the leftShelves array with size 6 for the spots on right side of warehouse layout
                for (int k = 0; k < Shelf.numofshelves; k++)
                    warehouselayout[i, 7].leftShelves[k] = empty;
            }




            //for loop to initialize the leftShelves and rightShelves 1D arrays for the columns in the middle of the warehouse layout

            for (int i = 1; i < 4; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    // warehouselayout[i, j].rightShelves = new Item[Shelf.numofshelves];
                    //  warehouselayout[i, j].leftShelves = new Item[Shelf.numofshelves];
                    for (int k = 0; k < Shelf.numofshelves; k++)
                    {
                        warehouselayout[i, j].rightShelves[k] = empty;
                        warehouselayout[i, j].leftShelves[k] = empty;
                    }

                }
            }



            //figure out way to initialize some values and test this


            //initialize the shelf_colnum and shelf_rownum data fields for each element in the layout matrix
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    warehouselayout[i, j].shelf_rownum = i;
                    warehouselayout[i, j].shelf_colnum = j;
                }
            }



            //printwarehousegrid();
            // printrobotlayout();


            //add loop, moverobot, simulation code here

            //while loop for while there is loading or unloading to be done?
            //could also just run for a set number of steps

            //the if statements for the robot movement functions and the functions themselves will go in the loop, there will be a bunch at the very start before calling Moverobots, possibly use case?

            //dtruck.deliveryitems.Enqueue(item1);




            // testrobo.carrieditems.Enqueue(item1);




            //'testing loading
            //testrobo.isloading = true;
            //whcomp.dtruck_parked = true;
            //whcomp.deliveryorderpopping.Add(item1);
            //whcomp.deliveryorder.Add(item1);
            //whcomp.warehouseinventory.Add("11R2", item1);


            //'testing unloading
            testrobo.isunloading = true;
            whcomp.rtruck_parked = true;
            rtruck.restockingitems.Enqueue(item1);
            rtruck.restockingitems.Enqueue(item2);
            rtruck.restockingitems.Enqueue(item3);
            rtruck.restockingitems.Enqueue(item4);
            rtruck.restockingitems.Enqueue(item5);


            //if truck has left and donetask flag is true, then stop the loop
            // while ( whcomp.rtruck_parked || testrobo.donetask = false) the loop keeps running, when neither condition is met the loop breaks and robots freeze in place
            //robot has donetask set to true when it unloads its item in the shelf succesfully, or loads its item into the truck succesfully, if the loading truck has more
            //stuff needed to be put on it then it sets donetask back to false for the loading robot
            //robot has donetask set to false when it grabs another item from the restocking truck, or just as long as its isunload =true and its carrieditems length is above 0 its donetask is set to false?? this part maybe not good method

            //while (whcomp.dtruck_parked || testrobo.donetask == false)
            while (whcomp.rtruck_parked || testrobo.donetask == false)//truck must be gone and robot must be done task for the loop to stop, can add other truck to this as well
            //while (testrobo.isunloading)
            // for (int t=0; t<10; t++)
            {
                testrobo.Resetnextmoves();// start by setting all moves to false

                //'-------------------------------------conditionals for fetching item/loading------------------------------

                if (testrobo.robo_rownum == 4 && testrobo.robo_colnum >= 3) //'TEST CHANGE 
                    testrobo.robodonejob_sendbacktoloadingtrucks();

                if (testrobo.robo_rownum == 4 && testrobo.robo_colnum == 2 && whcomp.dtruck_parked && testrobo.isloading == true)//only loading from right loading dock for now
                    dtruck.robot_loaddelivery(testrobo, whcomp);//' LOAD IN TO DELIVERY TRUCK, this will change dtruck_parked to false if loading is done

                if (testrobo.robo_rownum == 4 && testrobo.robo_colnum == 2 && whcomp.dtruck_parked && testrobo.isloading == true)// so if dtruck_parked is still true, then loading isn't done, must find more items
                    testrobo.finditemaisle(warehouselayout, whcomp);


                //'/////START OF AISLE 0,1,2 LOADING CASE
                if (testrobo.loadaisle == 0 || testrobo.loadaisle == 1 || testrobo.loadaisle == 2)//assuming only load to bay 2 right now, and just send up left side
                {
                    if (testrobo.robo_rownum == 4 && testrobo.robo_colnum <= 2 && whcomp.dtruck_parked && testrobo.isloading == true && testrobo.robo_colnum != testrobo.loadaisle)
                        testrobo.movetoloadaisle(warehouselayout);

                    //aisle 0 loading case
                    if (testrobo.robo_colnum == 0 && whcomp.dtruck_parked && testrobo.isloading == true && testrobo.robo_colnum == testrobo.loadaisle && testrobo.robo_rownum > 0)//testrobo.robo_rownum > 0 bc dont wanna run checktraffic for this
                    {
                        warehouselayout[testrobo.robo_rownum, testrobo.robo_colnum].fetchitem(warehouselayout, testrobo, whcomp, empty);//'call FETCHITEM (has conditional inside) before moveuploadaisle
                        testrobo.moveuploadaisle(warehouselayout);
                    }


                    //aisle 1 and 2 loading case
                    if (testrobo.robo_colnum != 0 && testrobo.robo_colnum <= 2 && whcomp.dtruck_parked && testrobo.isloading == true && testrobo.robo_colnum == testrobo.loadaisle && testrobo.robo_rownum > 1)//testrobo.robo_rownum < 1 bc at 1 we run checktraffic to move up
                    {
                        warehouselayout[testrobo.robo_rownum, testrobo.robo_colnum].fetchitem(warehouselayout, testrobo, whcomp, empty);//'call FETCHITEM (has conditional inside) before moveuploadaisle
                        testrobo.moveuploadaisle(warehouselayout);
                    }

                    if (testrobo.robo_colnum != 0 && testrobo.robo_colnum <= 2 && whcomp.dtruck_parked && testrobo.isloading == true && testrobo.robo_colnum == testrobo.loadaisle && testrobo.robo_rownum == 1)
                    {
                        warehouselayout[testrobo.robo_rownum, testrobo.robo_colnum].fetchitem(warehouselayout, testrobo, whcomp, empty);//'call FETCHITEM (has conditional inside) before checktraffictop
                        testrobo.Checktraffictop(warehouselayout);
                    }

                    //aisle 0, 1, 2 loading cases merge here

                    if (testrobo.robo_rownum == 0 && testrobo.robo_colnum < 7)
                        testrobo.robodonejob_sendbacktotrucks1();

                    if (testrobo.robo_rownum < 4 && testrobo.robo_colnum == 7)
                        testrobo.robodonejob_sendbacktotrucks2();

                    //not sure if i need the robodonejob_sendbacktoloadingtrucks(); here too because i put that at the start

                    //if (testrobo.robo_rownum == 4 && testrobo.robo_colnum > 2 && whcomp.dtruck_parked && testrobo.isloading == true)
                    //    testrobo.robodonejob_sendbacktoloadingtrucks();

                }
                //'/////END OF AISLE 0,1,2 LOADING CASE


                //'/////START OF AISLE >= 3 LOADING CASE
                if (testrobo.loadaisle >= 3)
                {
                    if (testrobo.robo_rownum == 4 && testrobo.robo_colnum <= 2 && testrobo.robo_colnum != 0 && whcomp.dtruck_parked && testrobo.isloading == true && testrobo.robo_colnum != testrobo.loadaisle)
                        testrobo.movetoaisle0();


                    if (testrobo.robo_colnum == 0 && whcomp.dtruck_parked && testrobo.isloading == true && testrobo.robo_colnum != testrobo.loadaisle && testrobo.robo_rownum > 0)
                        testrobo.moveupaisle0();

                    if (testrobo.robo_rownum == 0 && testrobo.robo_colnum < 7 && whcomp.dtruck_parked && testrobo.isloading == true && testrobo.robo_colnum != testrobo.loadaisle)
                        testrobo.movetoloadaislefromtop();

                    //aisle 7 loading case

                    if (testrobo.robo_rownum < 4 && testrobo.robo_colnum == 7 && testrobo.robo_colnum == testrobo.loadaisle && whcomp.dtruck_parked && testrobo.isloading == true && testrobo.robo_colnum >= 3)//will call checktraffic from bottom function at rownum 3
                    {
                        warehouselayout[testrobo.robo_rownum, testrobo.robo_colnum].fetchitem(warehouselayout, testrobo, whcomp, empty);//' call FETCHITEM (has conditional inside) before movedownloadaislefromtop
                        testrobo.movedownloadaislefromtop();
                    }

                    //aisle 3-6 loading case

                    if (testrobo.robo_colnum != 7 && testrobo.robo_colnum == testrobo.loadaisle && whcomp.dtruck_parked && testrobo.isloading == true && testrobo.robo_colnum >= 3 && testrobo.robo_rownum < 3)//will call checktraffic from bottom function at rownum 3
                    {
                        warehouselayout[testrobo.robo_rownum, testrobo.robo_colnum].fetchitem(warehouselayout, testrobo, whcomp, empty);//' call FETCHITEM (has conditional inside) before movedownloadaislefromtop
                        testrobo.movedownloadaislefromtop();
                    }

                    if (testrobo.robo_rownum == 3 && testrobo.robo_colnum != 7 && testrobo.robo_colnum == testrobo.loadaisle && whcomp.dtruck_parked && testrobo.isloading == true && testrobo.robo_colnum >= 3)
                    {
                        warehouselayout[testrobo.robo_rownum, testrobo.robo_colnum].fetchitem(warehouselayout, testrobo, whcomp, empty);//' call FETCHITEM (has conditional inside) before movedownloadaislefromtop
                        testrobo.checkbottomtraffic(warehouselayout);
                    }

                    //aisle 3-6 and 7 loading cases merge here

                    //continues from robodonejob_sendbacktoloadingtrucks();

                }
                //'/////END OF AISLE >= 3 LOADING CASE



                //'-------------------------------------conditionals for stocking shelves/ unloading items------------------------------


                if (testrobo.robo_rownum == 4 && whcomp.rtruck_parked && testrobo.isunloading == true)
                    testrobo.robodonejob_sendbacktounloadingtrucks();


                if (testrobo.robo_rownum == 4 && testrobo.robo_colnum == 3 && whcomp.rtruck_parked && testrobo.isunloading == true)//only unloadng from left unloading dock for now
                    rtruck.robot_restock(testrobo, whcomp);//' UNLOAD FROM RESTOCKINGTRUCK, change rtruck_parked to false if truck emptied? probably yes


                if (testrobo.robo_rownum == 4 && testrobo.robo_colnum == 3 && testrobo.isunloading == true)
                    testrobo.Chooseunloadaisle(warehouselayout, empty);



                //'////START OF AISLE 0,1,2 UNLOADING CASES

                if (testrobo.unloadaisle <= 2)
                {

                    if (testrobo.robo_rownum == 4 && testrobo.robo_colnum <= 3 && testrobo.isunloading == true && testrobo.robo_colnum != testrobo.unloadaisle)
                        testrobo.movetounloadaisle(warehouselayout);

                    //aisle 0 unloading case
                    if (testrobo.robo_colnum == 0 && testrobo.isunloading == true && testrobo.robo_colnum == testrobo.unloadaisle && testrobo.robo_rownum > 0)//testrobo.robo_rownum > 0 bc dont wanna run checktraffic for this
                    {
                        warehouselayout[testrobo.robo_rownum, testrobo.robo_colnum].restock(warehouselayout, testrobo, empty,whcomp);//'call RESTOCK (has conditional inside) before moveupunloadaisle
                        testrobo.moveupunloadaisle(warehouselayout);
                    }

                    //aisle 1 and 2 unloading case
                    if (testrobo.robo_colnum != 0 && testrobo.robo_colnum <= 2 && testrobo.isunloading == true && testrobo.robo_colnum == testrobo.unloadaisle && testrobo.robo_rownum > 1)//testrobo.robo_rownum < 1 bc at 1 we run checktraffic to move up
                    {
                        warehouselayout[testrobo.robo_rownum, testrobo.robo_colnum].restock(warehouselayout, testrobo, empty,whcomp);//'call RESTOCK (has conditional inside) before moveupunloadaisle
                        testrobo.moveupunloadaisle(warehouselayout);
                    }

                    if (testrobo.robo_colnum != 0 && testrobo.robo_colnum <= 2 && testrobo.isunloading == true && testrobo.robo_colnum == testrobo.unloadaisle && testrobo.robo_rownum == 1)
                    {
                        warehouselayout[testrobo.robo_rownum, testrobo.robo_colnum].restock(warehouselayout, testrobo, empty,whcomp);//'call RESTOCK (has conditional inside) before moveupunloadaisle
                        testrobo.Checktraffictop(warehouselayout);
                    }


                    //aisle 0 and aisle 1 and 2 unloading cases merge here

                    if (testrobo.robo_rownum == 0 && testrobo.robo_colnum < 7)
                        testrobo.robodonejob_sendbacktotrucks1();

                    if (testrobo.robo_rownum < 4 && testrobo.robo_colnum == 7)
                        testrobo.robodonejob_sendbacktotrucks2();


                    if (testrobo.robo_rownum == 4 && whcomp.rtruck_parked && testrobo.isunloading == true)
                        testrobo.robodonejob_sendbacktounloadingtrucks();
                    //not sure if i need the robodonejob_sendbacktounloadingtrucks(); here too ?? note sendbacktoloading truck was at the start, so i probly do need to add


                }
                //'/////END OF AISLE 0,1,2 UNLOADING CASES



                //'////START OF AISLE 3-7 UNLOADING CASES
                if (testrobo.unloadaisle >= 3)
                {


                    if (testrobo.robo_rownum == 4 && testrobo.robo_colnum <= 3 && testrobo.robo_colnum != 0 && testrobo.isunloading == true)//only unloading at column 3
                        testrobo.movetoaisle0();


                    if (testrobo.robo_colnum == 0 && testrobo.isunloading == true && testrobo.robo_rownum > 0)
                        testrobo.moveupaisle0();

                    if (testrobo.robo_rownum == 0 && testrobo.robo_colnum < 7 && testrobo.isunloading == true && testrobo.robo_colnum != testrobo.unloadaisle)
                        testrobo.movetounloadaislefromtop();



                    //aisle 7 unloading case

                    if (testrobo.robo_rownum < 4 && testrobo.robo_colnum == 7 && testrobo.robo_colnum == testrobo.unloadaisle && testrobo.isunloading == true)
                    {
                        warehouselayout[testrobo.robo_rownum, testrobo.robo_colnum].restock(warehouselayout, testrobo, empty,whcomp);//'call RESTOCK before movedownunloadaislefromtop
                        testrobo.movedownunloadaislefromtop();
                    }



                    //aisle 3-6 unloading cases


                    if (testrobo.robo_colnum != 7 && testrobo.robo_colnum == testrobo.unloadaisle && testrobo.isunloading == true && testrobo.robo_colnum >= 3 && testrobo.robo_rownum < 3)//will call checktraffic from bottom function at rownum 3
                    {
                        warehouselayout[testrobo.robo_rownum, testrobo.robo_colnum].restock(warehouselayout, testrobo, empty,whcomp);//' call RESTOCK before movedownunloadaislefromtop
                        testrobo.movedownloadaislefromtop();
                    }

                    if (testrobo.robo_rownum == 3 && testrobo.robo_colnum != 7 && testrobo.robo_colnum == testrobo.unloadaisle && testrobo.isunloading == true && testrobo.robo_colnum >= 3)//will call checktraffic from bottom function at rownum 3
                    {
                        warehouselayout[testrobo.robo_rownum, testrobo.robo_colnum].fetchitem(warehouselayout, testrobo, whcomp, empty);//' call RESTOCK before checkbottomtraffic
                        testrobo.checkbottomtraffic(warehouselayout);
                    }

                    //aisle 3-6 and 7 unloading cases merge here

                    //continues from robodonejob_sendbacktounloadngtrucks

                    if (testrobo.robo_rownum == 4 && whcomp.rtruck_parked && testrobo.isunloading == true)
                        testrobo.robodonejob_sendbacktounloadingtrucks();

                }
                //'////END OF AISLE 3-7 UNLOADING CASES




                //conditionals for restocking item/unloading

                //if (testrobo.robo_rownum == 4 && testrobo.isunloading == true)
                //    testrobo.Chooseunloadaisle(warehouselayout);




                Moverobots();
                updaterobotmap();
                printrobotlayout();
                printinventory(whcomp.warehouseinventory);
                Thread.Sleep(500);

            }






            //------------------LOCAL FUNCTION DECLARATIONS-----------


           


            void printinventory(Dictionary<string, Item> warehouseinventory)
            {
                Console.WriteLine();
                Console.WriteLine("Warehouse Inventory");
                foreach (KeyValuePair<string, Item> x in warehouseinventory)
                {
                    Console.WriteLine("Coordinate: {0}, Item: {1}",
                    x.Key, x.Value.name);
                }
            }



            void Moverobots()
            {
                if (testrobo.nextmoveup)
                {
                    testrobo.robo_rownum--;
                }
                else if (testrobo.nextmovedown)
                    testrobo.robo_rownum++;
                else if (testrobo.nextmoveleft)
                    testrobo.robo_colnum--;
                else if (testrobo.nextmoveright)
                    testrobo.robo_colnum++;
            }



            void updaterobotmap()
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (testrobo.robo_rownum == warehouselayout[i, j].shelf_rownum && testrobo.robo_colnum == warehouselayout[i, j].shelf_colnum)
                            warehouselayout[i, j].isOccupied_Rob = true;
                        else
                            warehouselayout[i, j].isOccupied_Rob = false;
                    }
                }


            }



            //function to print out all elements of the warehouselayout 2d array, can also use to print the value of a member for each element in the 2d array, eg. colnum, isOccupied_Rob
            void printwarehousegrid()
            {
                Console.WriteLine();
                Console.WriteLine("gridlayout");
                var arowCount = warehouselayout.GetLength(0);
                var acolCount = warehouselayout.GetLength(1);
                for (int row = 0; row < arowCount; row++)
                {
                    for (int col = 0; col < acolCount; col++)
                        Console.Write(String.Format("[{0},{1}]  \t", warehouselayout[row, col].shelf_rownum, warehouselayout[row, col].shelf_colnum));
                    Console.WriteLine();
                }
            }



            void printrobotlayout()
            {
                Console.WriteLine();
                Console.WriteLine("squares occupied by robot");
                var arowCount = warehouselayout.GetLength(0);
                var acolCount = warehouselayout.GetLength(1);
                for (int row = 0; row < arowCount; row++)
                {
                    for (int col = 0; col < acolCount; col++)
                        Console.Write(String.Format("{0}\t", warehouselayout[row, col].isOccupied_Rob));
                    Console.WriteLine();
                }
            }





        }
        //end of main function









    }
}
