
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{



    [SerializeField] private RoomBase[] RoomPrefabs;
    [SerializeField] private float RoomSize = 1;
    public int mapSize = 1;
    public RoomBase[,] _Room;

    
    
    public void CreateMap()
    {
        

        _Room =  new RoomBase[mapSize,mapSize];
        for (int x = 0; x < mapSize; x++)
        {

            for (int z = 0; z < mapSize; z++)
            {
                Vector2 coords = new Vector2(x * RoomSize, z * RoomSize);

                var roomInstance = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)]);

                roomInstance.SetRoomLocation(coords);

                //Rooms.Add(coords, roomInstance);
                if (x > 0)
                {
                    roomInstance.WestDoorWay.SetActive(false);
                }
                if (x < mapSize - 1)
                {
                    roomInstance.EastDoorWay.SetActive(false);
                }
                if (z > 0)
                {
                    roomInstance.SouthDoorWay.SetActive(false);
                }
                if (z < mapSize - 1)
                {
                    roomInstance.NorthDoorWay.SetActive(false);
                    
                }
                
                

            }

        }
    }
}
