using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneController : MonoBehaviour
{

    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private GameObject _firstAidPrefab;
    private GameObject[] _NPCs = new GameObject[10];
    private GameObject[] _firstAid = new GameObject[3];
    private int _randEnemyIdentifier;
    private int _randRoomSpawn;

    private int _randNumOfEnemies;
    private int _randMutant2Locations;
    private Vector3 _enemySpawnPoint;
    private float _randomX;
    private float _randomZ;

    private PlayerController _player;
    private UIManager _uiManager;
    private AudioSource _backgroundMusic;


    //This will be used to control the number of enemies on the scene.
    public int numOfEnemiesOnScene = 0;

    // Use this for initialization
    void Start()
    {
        IntialSpawn();
        CreateFirstAidKits();
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        _uiManager = GameObject.Find("Controller").GetComponent<UIManager>();
        _backgroundMusic = GetComponent<AudioSource>();
        _backgroundMusic.Play();
    }


    
    public void Reset()
    {
        _uiManager.NumOfKills = 15;
        //Reset Player intial position and rotation
        GameObject player = GameObject.Find("Player");
        player.transform.position = new Vector3(18.41f, 1f, -1.33f);
        player.transform.rotation = Quaternion.Euler(0f, -60f, 0f);

        //Reset Player's health and show it in console
        PlayerController playerCharacter = player.GetComponent<PlayerController>();
        playerCharacter.health = 100;

        //Reset First Aid Kits
        for (int i = 0; i < _firstAid.Length; i++)
        {
            Destroy(_firstAid[i]);
        }
        CreateFirstAidKits();
        

        GameObject[] byStanders = GameObject.FindGameObjectsWithTag("byStander");
        if (byStanders != null && byStanders.Length != 0)
        {
            foreach (var b in byStanders)
            {
                Destroy(b);
            }
        }

        GameObject[] mutants = GameObject.FindGameObjectsWithTag("mutant");
        if (mutants != null && mutants.Length != 0)
        {
            foreach (var m in mutants)
            {
                Destroy(m);
            }
        }

        GameObject[] mutants2 = GameObject.FindGameObjectsWithTag("mutant2");
        if (mutants2 != null && mutants2.Length != 0)
        {
            foreach (var m2 in mutants2)
            {
                Destroy(m2);
            }
        }

        numOfEnemiesOnScene = 0;
        IntialSpawn();
    }

    void IntialSpawn()
    {

        SpawnInRoom1(3);
        SpawnInRoom2(1);
        SpawnInRoom3(1);
    }

    /*Three first aid kits are created at different locations across the scene */
    void CreateFirstAidKits()
    {
        for (int i = 0; i < 3; i++)
        {
            _firstAid[i] = Instantiate(_firstAidPrefab) as GameObject;
        }

        _firstAid[0].transform.position = new Vector3(-53.21f, 3.54f, 20.152f);
        _firstAid[1].transform.position = new Vector3(-43.21f, 0.07f, 1.12f);
        _firstAid[2].transform.position = new Vector3(-59.19f, 3.55f, 21.12f);
    }

    public void ReSpawn()
    {
        --numOfEnemiesOnScene;

        //random number of enemies we would like to create making sure that there is not a point
        //where there is always 10 enemies ont the scene or more than 10.
        _randNumOfEnemies = Random.Range(1, 4);
        _randNumOfEnemies = CheckMaxEnemies(_randNumOfEnemies);


        if (_player.RoomNumber == 1)
        {
            SpawnInRoom1(_randNumOfEnemies);
        }
        else if (_player.RoomNumber == 2)
        {
            SpawnInRoom2(_randNumOfEnemies);
        }
        else
            SpawnInRoom3(_randNumOfEnemies);
    }

    void SpawnInRoom1(int numOfEnemies)
    {


        for (int i = 0; i < numOfEnemies; i++)
        {

            //Random int that chooses random enemy type
            _randEnemyIdentifier = Random.Range(1, 4);

            switch (_randEnemyIdentifier)
            {

                case 1:
                    //Spawn a mutant
                    _NPCs[i] = Instantiate(_enemyPrefabs[0]) as GameObject;
                    _NPCs[i].transform.position = GetRoom1RandomLocations();
                    _NPCs[i].GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
                    break;
                case 2:
                    //Spawn mutant2
                    _NPCs[i] = Instantiate(_enemyPrefabs[1]) as GameObject;
                    _NPCs[i].transform.position = GetRoom1Locations();

                    break;
                default:
                    //if case 1 and 2 don't happen Spawn Passive_Enemy
                    _NPCs[i] = Instantiate(_enemyPrefabs[2]) as GameObject;
                    _NPCs[i].transform.position = GetRoom1RandomLocations();
                    _NPCs[i].GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
                    break;
            }

            numOfEnemiesOnScene++;

        }
    }

    void SpawnInRoom2(int numOfEnemies)
    {


        for (int i = 0; i < numOfEnemies; i++)
        {

            //Random int that chooses random enemy type
            _randEnemyIdentifier = Random.Range(1, 4);

            switch (_randEnemyIdentifier)
            {

                case 1:
                    //Spawn a mutant
                    _NPCs[i] = Instantiate(_enemyPrefabs[0]) as GameObject;
                    _NPCs[i].transform.position = GetRoom2RandomLocations();
                    _NPCs[i].GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
                    break;
                case 2:
                    //Spawn mutant2
                    _NPCs[i] = Instantiate(_enemyPrefabs[1]) as GameObject;
                    _NPCs[i].transform.position = GetRoom2Locations();
                    break;
                case 3:
                    //if case 1 and 2 don't happen Spawn Passive_Enemy
                    _NPCs[i] = Instantiate(_enemyPrefabs[2]) as GameObject;
                    _NPCs[i].transform.position = GetRoom2RandomLocations();
                    _NPCs[i].GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
                    break;
            }

            numOfEnemiesOnScene++;

        }
    }



    void SpawnInRoom3(int numOfEnemies)
    {


        for (int i = 0; i < numOfEnemies; i++)
        {

            //Random int that chooses random enemy type
            _randEnemyIdentifier = Random.Range(1, 4);

            switch (_randEnemyIdentifier)
            {

                case 1:
                    //Spawn a mutant
                    _NPCs[i] = Instantiate(_enemyPrefabs[0]) as GameObject;
                    _NPCs[i].transform.position = GetRoom3RandomLocations();
                    _NPCs[i].GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
                    break;
                case 2:
                    //Spawn mutant2
                    _NPCs[i] = Instantiate(_enemyPrefabs[1]) as GameObject;
                    _NPCs[i].transform.position = GetRoom3Locations();
                    break;
                default:
                    //if case 1 and 2 don't happen Spawn Passive_Enemy
                    _NPCs[i] = Instantiate(_enemyPrefabs[2]) as GameObject;
                    _NPCs[i].transform.position = GetRoom3RandomLocations();
                    _NPCs[i].GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
                    break;
            }

            numOfEnemiesOnScene++;

        }
    }

    public Vector3 GetRoom1RandomLocations()
    {
        _randomX = Random.Range(-59.4f, 10.5f);
        _randomZ = Random.Range(-12.3f, 13.1f);

        return new Vector3(_randomX, 0, _randomZ);
    }

    Vector3 GetRoom1Locations()
    {
        _randMutant2Locations = Random.Range(1, 4);
        switch (_randMutant2Locations)
        {
            case 1:
                _enemySpawnPoint = new Vector3(-23.22f, 0, -10.44f);
                break;
            case 2:
                _enemySpawnPoint = new Vector3(-7.25f, 0, 12.25f);
                break;
            case 3:
                _enemySpawnPoint = new Vector3(-30.85f, 0, 11.9f);
                break;
            default:
                _enemySpawnPoint = new Vector3(-54f, 0, 10.75f);
                break;

        }

        return _enemySpawnPoint;
    }


    //right Platform to the right of player's starting postion
    public Vector3 GetRoom2RandomLocations()
    {
        _randomX = Random.Range(-47.19f, 11.56f);
        _randomZ = Random.Range(17.25f, 25.3f);
        return new Vector3(_randomX, 4.16f, _randomZ);

    }

    private Vector3 GetRoom2Locations()
    {
        _randMutant2Locations = Random.Range(1, 3);

        if (_randMutant2Locations == 1)
            return new Vector3(17.16f, 4.16f, 24.61f);

        return new Vector3(-54.13f, 4.16f, 24.97f);
    }

    //left Platform to the right of player's starting postion
    public Vector3 GetRoom3RandomLocations()
    {
        _randomX = Random.Range(-46.95f, 10.6f);
        _randomZ = Random.Range(-22.3f, -15.4f);
        return new Vector3(_randomX, 4.16f, _randomZ);

    }

    private Vector3 GetRoom3Locations()
    {
        _randMutant2Locations = Random.Range(1, 3);

        if (_randMutant2Locations == 1)
            return new Vector3(16.5f, 4.16f, -21.6f);

        return new Vector3(-53.15f, 4.16f, -21.6f);
    }


    private int CheckMaxEnemies(int numOfEnemiesToCreate)
    {

        int potentialNumOfEnemies = numOfEnemiesToCreate + numOfEnemiesOnScene;
        if (numOfEnemiesOnScene == 10)
        {
            return 0;
        }
        else if (potentialNumOfEnemies >= 10)
        {
            potentialNumOfEnemies = 10 - numOfEnemiesOnScene;
            potentialNumOfEnemies = Random.Range(0, potentialNumOfEnemies + 1);
            return potentialNumOfEnemies;

        }
        else
            return Random.Range(1, numOfEnemiesToCreate + 1);

    }


}
