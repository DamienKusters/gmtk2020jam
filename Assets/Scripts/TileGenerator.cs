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

    public int straightTileSize = 3;
    public int diagonalTileSize = 4;

    int baseX = 0;
    int baseY = 0;

    private int xStep = 19;
    private int yStep = 10;
    
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
                for(int z = 0; z < straightTileSize; z++)
                {
                    tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                    tilemap.SetTile(new Vector3Int(baseX-19, baseY, 0), baseTile);
                    tilemap.SetTile(new Vector3Int(baseX+19, baseY, 0), baseTile);

                    if (z < 2)
                        baseY += 10;
                }
                break;
            case Direction.UP_RIGHT:
                DrawDiagonalSquareOfTiles(xStep, yStep);
                break;
            case Direction.RIGHT:
                for (int z = 0; z < straightTileSize; z++)
                {
                    tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                    tilemap.SetTile(new Vector3Int(baseX, baseY + 10, 0), baseTile);
                    tilemap.SetTile(new Vector3Int(baseX, baseY - 10, 0), baseTile);

                    if (z < 2)
                        baseX += 19;
                }
                break;
            case Direction.DOWN_RIGHT:
                DrawDiagonalSquareOfTiles(xStep, -yStep);
                break;
            case Direction.DOWN:
                for (int z = 0; z < straightTileSize; z++)
                {
                    tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                    tilemap.SetTile(new Vector3Int(baseX - 19, baseY, 0), baseTile);
                    tilemap.SetTile(new Vector3Int(baseX + 19, baseY, 0), baseTile);

                    if (z < 2)
                        baseY -= 10;
                }
                break;
            case Direction.DOWN_LEFT:
                DrawDiagonalSquareOfTiles(-xStep, -yStep);
                break;
            case Direction.LEFT:
                for (int z = 0; z < straightTileSize; z++)
                {
                    tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                    tilemap.SetTile(new Vector3Int(baseX, baseY + 10, 0), baseTile);
                    tilemap.SetTile(new Vector3Int(baseX, baseY - 10, 0), baseTile);

                    if (z < 2)
                        baseX -= 19;
                }
                break;
            case Direction.UP_LEFT:
                DrawDiagonalSquareOfTiles(-xStep, yStep);
                break;
            default:
                break;
        }
    }

    private void DrawDiagonalSquareOfTiles(int xOffset, int yOffset)
    {
        for (int i = 0; i < diagonalTileSize; i++)
        {
            for (int x = 0; x < diagonalTileSize; x++)
            {
                tilemap.SetTile(new Vector3Int(baseX, baseY, 0), baseTile);
                baseX += xOffset;
            }
            baseX += -xOffset * diagonalTileSize;
            baseY += yOffset;

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
