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

        GenerateObject();
    }

    void GenerateObject()
    {


    }
}
