using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileGenerator : MonoBehaviour
{
    private Globals global;

    public GameObject cameraObject;
    private Camera camera;

    public 

    // Start is called before the first frame update
    void Start()
    {
        camera = cameraObject.GetComponent<Camera>();
        global = GameObject.Find("GLOBALS").GetComponent<Globals>();
    }

    // Update is called once per frame
    void Update()
    {
        //[1] Check if New Tile needs to be Rendered [2] Determine where tile needs to be [3] Create and Place Tile
        //if Viewport X + Viewport Width >= Tile Width { Create New Tile}
        //Debug.Log("Camera X Coordinate Equals: " + camera.rect.width);
        if(global.currentDirection == Direction.RIGHT)
        {

        }

    }
}
