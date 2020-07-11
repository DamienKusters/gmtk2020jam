using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    private Globals globals;
    private Camera camera;

    public GameObject generatorNorth, generatorEast, generatorSouth, generatorWest;

    // Start is called before the first frame update
    void Start()
    {
        globals = GameObject.Find("GLOBALS").GetComponent<Globals>();
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();

        InvokeRepeating("GenerateObject", 2, 2);//Do this every [2] sec
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void GenerateObject()
    {

        ResetSpawnerPositions();
    }

    void ResetSpawnerPositions()
    {
        float camHeight = camera.orthographicSize;
        float camWidth = camHeight * camera.aspect;

        generatorNorth.transform.position = new Vector2(0, camHeight + 3);
        generatorSouth.transform.position = new Vector2(0, 0 - camHeight - 3);
        generatorEast.transform.position = new Vector2(camWidth + 3, 0);
        generatorWest.transform.position = new Vector2(0 - camWidth - 3, 0);
    }
}
