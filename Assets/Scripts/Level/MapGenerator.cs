using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapGenerator : MonoBehaviour
{
    //We create a 2D grid to map out the level.
    private Room[,] grid;
    //With this integer we can set a mapseed which will be influenced on what we put here.
    public int mapseed;
    //This array will use the room templates to generate the level.
    public GameObject[] gridPrefabs;
    //Rows and Columns are defined from what we pass through them. In short this will allow us to do the math for the level and its doors.
    public static int rows;
    public static int cols;
    //Here we defined the width and height of each room so that they can be spaced appropriately.
    public float roomWidth = 50.0f;
    public float roomHeight = 50.0f;
    //This will allow us to create a condtion that will influence what randomness our level will take.
    public static bool isMapOfTheDay;

    //On start we will generate the map to avoid lag in actual gameplay
    void Start()
    {
        GenerateMap();
    }
    //Using System; we can access DateTime to get variables of the current Year, Month, and Day.
    public int DateToInt(DateTime dateToUse)
    {
        return dateToUse.Year + dateToUse.Month + dateToUse.Day;
    }
    void Update()
    {
        
    }
    //This will set the randomness of the rooms.
    public GameObject RandomRoomPrefrab()
    {
        return gridPrefabs[UnityEngine.Random.Range(0, gridPrefabs.Length)];
    }
    public void GenerateMap()
    {
        //With these InitState we define which randomness we can set the level.
        //With the current date or with a given mapseed.
        UnityEngine.Random.InitState(DateToInt(DateTime.Now));

        if(isMapOfTheDay)
        {
            mapseed = DateToInt(DateTime.Now.Date);
        }

        UnityEngine.Random.InitState(mapseed);
        //If our bool is checked then we will used the date as our seed rather than our own set seed.

        grid = new Room[cols, rows];
        for (int currentRow = 0; currentRow < rows; currentRow++)
        {
            for (int currentCol = 0; currentCol < cols; currentCol++)
            {
                //The columns and rows are multiplied by width and height respectively to get the positions for the rooms.
                float xPosition = roomWidth * currentCol;
                float zPosition = roomHeight * currentRow;
                //We are able to get the new position of the rooms by using Vector3.
                Vector3 newPosition = new Vector3 (xPosition, 0.0f, zPosition);

                //We will create the room with the correct position and rotation.
                GameObject tempRoomObj = Instantiate (RandomRoomPrefrab(), newPosition, Quaternion.identity) as GameObject;
                tempRoomObj.transform.parent = this.transform;
                tempRoomObj.name = "Room_"+currentCol+","+currentRow;
                Room tempRoom = tempRoomObj.GetComponent<Room>();
                grid[currentCol,currentRow] = tempRoom;
                //These if statements serve the purpose of destroying doors on the inside of the level and not on the outside.
                if (currentRow == 0)
                {
                    tempRoom.doorNorth.SetActive(false);
                }
                else if (currentRow == rows-1)
                {
                    Destroy(tempRoom.doorSouth);
                }
                else
                {
                    Destroy(tempRoom.doorNorth);
                    Destroy(tempRoom.doorSouth);
                }

                if (currentCol == 0)
                {
                    tempRoom.doorEast.SetActive(false);
                }
                else if (currentCol == cols-1)
                {
                    Destroy(tempRoom.doorWest);
                }
                else
                {
                    Destroy(tempRoom.doorEast);
                    Destroy(tempRoom.doorWest);
                }
            }
        }
    }
}

