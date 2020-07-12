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

        InvokeRepeating("GenerateObject", 5, 5);//Do this every [x] sec
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateObject()
    {
        Direction dir = globals.currentDirection;

        switch (dir)
        {
            case Direction.UP:
                GenerateBuilding(generatorNorth, false);
                break;
            case Direction.UP_RIGHT:
                GenerateBuilding(generatorEast, generatorNorth);
                break;
            case Direction.RIGHT:
                GenerateBuilding(generatorEast, true);
                break;
            case Direction.DOWN_RIGHT:
                GenerateBuilding(generatorEast, generatorSouth);
                break;
            case Direction.DOWN:
                GenerateBuilding(generatorSouth, false);
                break;
            case Direction.DOWN_LEFT:
                GenerateBuilding(generatorWest, generatorSouth);
                break;
            case Direction.LEFT:
                GenerateBuilding(generatorWest, true);
                break;
            case Direction.UP_LEFT:
                GenerateBuilding(generatorWest, generatorNorth);
                break;
            default:
                break;
        }
    }

    void GenerateBuilding(GameObject spawner, bool isHorizontal)
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

        int buildingRandomizer = Random.Range(0,100);

        if(buildingRandomizer < 25)
            Instantiate(FlatPrefab, newPos, new Quaternion(0, 0, 0, 0));
        else if(globals.Score > 1000 && buildingRandomizer > 70)//Gravestone
            Instantiate(TombstonePrefab, newPos, new Quaternion(0, 0, 0, 0));
        else
            Instantiate(HousePrefab, newPos, new Quaternion(0, 0, 0, 0));
    }

    void GenerateBuilding(GameObject spawner1, GameObject spawner2)
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
            GenerateBuilding(spawner1, true);//SPAWNER 1 SHOULD ALWAYS EITHER BE WEST OR EAST
        else
            GenerateBuilding(spawner2, true);//SPAWNER 2 SHOULD ALWAYS EITHER BE SOUTH OR NORTH

    }
}
