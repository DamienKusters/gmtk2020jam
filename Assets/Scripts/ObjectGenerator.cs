using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    private Globals globals;

    private int min_x = -17, max_x = 17;
    private int min_y = -8, max_y = 8;

    public GameObject generatorNorth, generatorEast, generatorSouth, generatorWest;
    public GameObject HousePrefab, FlatPrefab, TombstonePrefab;

    // Start is called before the first frame update
    void Start()
    {
        globals = GameObject.Find("GLOBALS").GetComponent<Globals>();

        InvokeRepeating("GenerateBuilding", 5, 5);//Do this every [x] sec
        InvokeRepeating("GenerateGravestone", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateBuilding()
    {
        GenerateObject(true);
    }

    void GenerateGravestone()
    {
        
        if (globals.Score < 599)
            return;

        int rand = Random.Range(0, 9000);

        if (rand < globals.Score)//Gravestone
            GenerateObject(false);
    }

    void GenerateObject(bool isBuilding)
    {
        Direction dir = globals.currentDirection;

        switch (dir)
        {
            case Direction.UP:
                GenerateBuilding(isBuilding, generatorNorth, false);
                break;
            case Direction.UP_RIGHT:
                GenerateBuilding(isBuilding, generatorEast, generatorNorth);
                break;
            case Direction.RIGHT:
                GenerateBuilding(isBuilding, generatorEast, true);
                break;
            case Direction.DOWN_RIGHT:
                GenerateBuilding(isBuilding, generatorEast, generatorSouth);
                break;
            case Direction.DOWN:
                GenerateBuilding(isBuilding, generatorSouth, false);
                break;
            case Direction.DOWN_LEFT:
                GenerateBuilding(isBuilding, generatorWest, generatorSouth);
                break;
            case Direction.LEFT:
                GenerateBuilding(isBuilding, generatorWest, true);
                break;
            case Direction.UP_LEFT:
                GenerateBuilding(isBuilding, generatorWest, generatorNorth);
                break;
            default:
                break;
        }
    }

    void GenerateBuilding(bool isBuilding, GameObject spawner, bool isHorizontal)
    {
        int randRange;
        Vector2 newPos;

        if (isHorizontal)
        {
            randRange = Random.Range(min_y, max_y);
            newPos = new Vector2(spawner.transform.position.x, spawner.transform.position.y + randRange);
        }
        else
        {
            randRange = Random.Range(min_x, max_x);
            newPos = new Vector2(spawner.transform.position.x + randRange, spawner.transform.position.y);
        }

        if(!isBuilding)
        {
            Instantiate(TombstonePrefab, newPos, new Quaternion(0, 0, 0, 0));
            return;
        }

        int buildingRandomizer = Random.Range(0,100);

        if(buildingRandomizer < 25)
            Instantiate(FlatPrefab, newPos, new Quaternion(0, 0, 0, 0));
        else
            Instantiate(HousePrefab, newPos, new Quaternion(0, 0, 0, 0));
    }

    void GenerateBuilding(bool isBuilding, GameObject spawner1, GameObject spawner2)
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
            GenerateBuilding(isBuilding, spawner1, true);//SPAWNER 1 SHOULD ALWAYS EITHER BE WEST OR EAST
        else
            GenerateBuilding(isBuilding, spawner2, true);//SPAWNER 2 SHOULD ALWAYS EITHER BE SOUTH OR NORTH

    }
}
