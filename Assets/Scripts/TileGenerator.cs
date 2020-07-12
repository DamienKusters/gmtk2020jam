using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System;

public class TileGenerator : MonoBehaviour
{
    private Globals global;

    public GameObject cameraObject;
    private Camera camera;

    public Tile baseTile;
    public Tilemap tilemap;

    int baseX = 0;
    int baseY = 0;
    
    //called before the first frame update
    void Start()
    {
        camera = cameraObject.GetComponent<Camera>();
        global = GameObject.Find("GLOBALS").GetComponent<Globals>();
    }

    public void CreateTileInRequiredDirections()
    {
        baseX = (int) camera.transform.position.x;
        if(baseX % 19 != 0)
        {
            baseX = FindClosestNumber(baseX, 19);
        }
        baseY = (int) camera.transform.position.y;
        if (baseY % 10 != 0)
        {
            baseY = FindClosestNumber(baseY, 10);
        }
        switch (global.currentDirection)
        {
            case Direction.UP:
                tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                baseY += 10;
                tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                baseY += 10;
                tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                break;
            case Direction.UP_RIGHT:
                for(int i = 0; i < 4; i++)
                {
                    for(int x = 0; x < 4; x++)
                    {
                        tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                        baseX += 19;
                    }
                    baseX -= 76;
                    baseY += 10;
                }
                break;
            case Direction.RIGHT:
                tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                baseX += 19;
                tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                baseX += 19;
                tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                break;
            case Direction.DOWN_RIGHT:
                for (int i = 0; i < 4; i++)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                        baseX += 19;
                    }
                    baseX -= 76;
                    baseY -= 10;
                }
                break;
            case Direction.DOWN:
                tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                baseY -= 10;
                tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                baseY -= 10;
                tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                break;
            case Direction.DOWN_LEFT:
                for (int i = 0; i < 4; i++)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                        baseX -= 19;
                    }
                    baseX += 76;
                    baseY -= 10;
                }
                break;
            case Direction.LEFT:
                tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                baseX -= 19;
                tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                baseX -= 19;
                tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                break;
            case Direction.UP_LEFT:
                for (int i = 0; i < 4; i++)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                        baseX -= 19;
                    }
                    baseX += 76;
                    baseY += 10;
                }
                break;
            default:
                break;
        }
    }

    private int FindClosestNumber(int n, int m)
    {
        // find the quotient 
        int q = n / m;

        // 1st possible closest number 
        int n1 = m * q;

        // 2nd possible closest number 
        int n2 = (n * m) > 0 ? (m * (q + 1)) : (m * (q - 1));

        // if true, then n1 is the required closest number 
        if (Math.Abs(n - n1) < Math.Abs(n - n2))
            return n1;

        // else n2 is the required closest number 
        return n2;
    }
}
