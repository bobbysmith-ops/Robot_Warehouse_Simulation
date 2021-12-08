using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBobby1
{
    class Program
    {
        static void Main(string[] args)
        {
            //create objects of the item class that will be stored in the warehouse

            Item empty = new Item("empty", 0);

            Item airpodsitem = new Item("airpods", 2);
            Item xboxitem = new Item("xbox", 5);
            Item televisionitem = new Item("television", 10);
            Item basketballitem = new Item("basketball", 3);
            Item ricecookeritem = new Item("ricecooker", 7);

            Shelf[,] warehouselayout = new Shelf[5,8]; //declare 2d array for warehouse layout with 5 rows and 8 columns

            Robot rob1 = new Robot();



    
            for (int i=1; i < 4; i++)
            {
                warehouselayout[i, 0].rightShelves = new Item[Shelf.numofshelves];//declare the rightShelves array with size 6 for the spots on left side of warehouse layout
            }

            for (int i=1; i < 4; i++)
            {
                warehouselayout[i, 7].leftShelves = new Item[Shelf.numofshelves];//declare the leftShelves array with size 6 for the spots on right side of warehouse layout
            }


            // declare the leftShelves and rightShelves arrays with size 6 for the spots in the middle of the warehouse layout
            for (int i=1; i<4; i++)
            {
                for (int j=1; j<7; j++)
                {
                    warehouselayout[i, j].rightShelves = new Item[Shelf.numofshelves];
                    warehouselayout[i, j].leftShelves = new Item[Shelf.numofshelves];
                }
            }


            //initialize the shelf_colnum and shelf_rownum data fields for each element in the layout matrix
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    warehouselayout[i, j].shelf_colnum = i; 
                    warehouselayout[i, j].shelf_rownum = j; 
                }
            }


            


            //the warehouse simulation will have a forloop running for a certain amount of time? each second that elapses the robot will move a square and calculate next move?

            //will have a loop running the moverobot function to move the robot(s) around the warehouse









        }
    }
}
