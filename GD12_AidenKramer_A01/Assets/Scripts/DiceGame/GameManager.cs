
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    internal class GameManager : MonoBehaviour
    {
    
        [SerializeField] private MapManager GameMapPrefab;
        [SerializeField] private PlayerController _PlayerPrefab;

         private MapManager _gameMap;
         private PlayerController _playerController;

        // Start is called before the first frame update
        void Start()
        {

            Debug.Log("GameManager Start");



            transform.position = Vector3.zero;
            _gameMap = Instantiate(GameMapPrefab, transform);
            _gameMap.transform.position = Vector3.zero;

            _gameMap.CreateMap();

            Debug.Log("GameManager Map Created");



            PlayGame();

            Debug.Log("Start");
            transform.position = Vector3.zero;
            SetUpMap();
            SpawnPlayer();
            StartGame();
        }

        // Update is called once per frame
        public void SetUpMap()
        {
            Debug.Log("Setup Map");

            _gameMap = Instantiate(GameMapPrefab, transform);
            _gameMap.transform.position = Vector3.zero;
            _gameMap.CreateMap();

            Debug.Log("Setup Map Done");
        }
        public void StartGame()
        {
            Debug.Log("Game Starts!");

        }

        public void SpawnPlayer()
        {
            Debug.Log("Spawns Player");

            var randomStartingRoom = _gameMap._Room[0, 0];

            _playerController = Instantiate(_PlayerPrefab, transform);

            _playerController.transform.position = new Vector3(12, 1, 0);


            _playerController.Setup();

            Debug.Log("Spawns Player Done");
        }

         internal void PlayGame()//Calls PlayGame
         {
            
            


         }

        
    }
    

