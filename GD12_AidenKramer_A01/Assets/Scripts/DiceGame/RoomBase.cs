
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class RoomBase : MonoBehaviour
    {
        [SerializeField] public GameObject NorthDoorWay, EastDoorWay, SouthDoorWay, WestDoorWay;
        // todo make them all lambdo like north
        public void SetRoomLocation(Vector2 coords)
        {

            transform.position = new Vector3(coords.x, 0, coords.y);


        }
        public void OnTriggerEnter(Collider otherObject)
        {

            Debug.Log("IN ROOM");
        }
        public void OnTriggerStay(Collider otherObject)
        {

            Debug.Log("IN ROOM stay");
        }
        public void OnTriggerExit(Collider otherObject)
        {

             Debug.Log("out ROOM");
        }
    /*
    public void SetRooms(RoomBase roomNorth, RoomBase roomEast, RoomBase roomSouth, RoomBase roomWest)
    {
        North = roomNorth;
        NorthDoorWay.SetActive(north == null);
        East = roomEast;
        EastDoorWay.SetActive(East == null);
        South = roomSouth;
        SouthDoorWay.SetActive(South == null);
        West = roomWest;
        WestDoorWay.SetActive(West == null);
    }




    */
}


