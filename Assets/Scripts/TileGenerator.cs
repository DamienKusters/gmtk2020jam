using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TileGenerator : MonoBehaviour
{
    private Globals global;

    public GameObject cameraObject;
    private Camera camera;

    public Tile baseTile;
    public Tilemap tilemap;

    int baseX = 0;
    int baseY = -1;
    // Start is called before the first frame update
    void Start()
    {
        camera = cameraObject.GetComponent<Camera>();
        global = GameObject.Find("GLOBALS").GetComponent<Globals>();
    }

    public void CreateTileInRequiredDirections()
    {
        switch (global.currentDirection)
        {
            case Direction.UP:
                baseY += 10;
                tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                break;
            case Direction.UP_RIGHT:
                for(int i = 0; i < 3; i++)
                {
                    for(int x = 0; x < 3; x++)
                    {
                        tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                        baseX += 19;
                    }
                    baseX -= 57;
                    baseY += 10;
                }
                break;
            case Direction.RIGHT:
                baseX += 19;
                tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                break;
            case Direction.DOWN_RIGHT:
                for (int i = 0; i < 3; i++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                        baseX += 19;
                    }
                    baseX -= 57;
                    baseY -= 10;
                }
                break;
            case Direction.DOWN:
                baseY -= 10;
                tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                break;
            case Direction.DOWN_LEFT:
                for (int i = 0; i < 3; i++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                        baseX -= 19;
                    }
                    baseX += 57;
                    baseY -= 10;
                }
                break;
            case Direction.LEFT:
                baseX -= 19;
                tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                break;
            case Direction.UP_LEFT:
                for (int i = 0; i < 3; i++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                        baseX += 19;
                    }
                    baseX += 57;
                    baseY += 10;
                }
                break;
            default:
                break;
        }
    }
}
