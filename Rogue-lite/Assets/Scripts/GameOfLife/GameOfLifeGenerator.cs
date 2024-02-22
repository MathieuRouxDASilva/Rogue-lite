using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;


public class GameOfLifeGenerator : MonoBehaviour
{
    //setup variables
    [SerializeField] private Vector2Int size;
    [SerializeField] private Tilemap map;
    [SerializeField] private TileBase _base;
    [SerializeField] private TileBase _sand;
    [SerializeField] private int xSize;
    [SerializeField] private int ySize;
    [SerializeField] private Vector2 perlinScale = new Vector2(1, 1);
    [SerializeField] private float _centerX;
    [SerializeField] private float _centerY;

    private BoundsInt startZone;
    private HashSet<Vector2Int> tiles = new HashSet<Vector2Int>();

    public void Generate()
    {
        Init();
        
        //GameOfLifeIteration();
        
        GeneratorUtils.DrawMap(map, _base, tiles);
    }

    private void Update()
    {
        GameOfLifeIteration();
    }

    private void Init()
    {
        tiles.Clear();

        startZone.xMin = -1 * xSize / 2;
        startZone.xMax = xSize / 2;
        startZone.yMin = -1 * ySize / 2;
        startZone.yMax = ySize / 2;
        
        //goes throught the hashset thing
        for (int x = startZone.xMin; x < startZone.xMax / 2; x++)
        {
            for (int y = startZone.yMin ; y < startZone.yMax / 2; y++)
            {
                //perlin noise system (like a random)
                float noiseCoordX = x / (2.0f * xSize);
                float noiseCoordY = y / (2.0f * ySize);

                float rnd = Mathf.PerlinNoise(noiseCoordX * perlinScale.x, noiseCoordY * perlinScale.y);

                //system that set tile based on rnd
                if (rnd > 0.5f)
                {
                    tiles.Add(new Vector2Int(x, y));
                }
            }
        }
    }


    private int NeighboursCount(Vector2Int startPosition)
    {
        int count = 0;
        foreach (Vector2Int neighbour in GeneratorUtils.mooreNeighbours)
        {
            //if neighbours -> add one to count
            if (tiles.Contains(startPosition + neighbour))
            {
                count++;
            }
        }

        return count;
    }


    public void GameOfLifeIteration()
    {
        HashSet<Vector2Int> aliveTiles = new HashSet<Vector2Int>(tiles);
     
        //gameplay by ging again in the thing....
        for (int x = -1 * xSize / 2; x < xSize / 2; x++)
        {
            for (int y = -1 * ySize / 2; y < ySize / 2; y++)
            {
                Vector2Int cellPosition = new Vector2Int(x, y);
                int neighbours = NeighboursCount(cellPosition);
                
                if (tiles.Contains(cellPosition))
                {
                    if (neighbours < 2 || neighbours > 3)
                    {
                        aliveTiles.Remove(cellPosition);
                    }
                }
                else
                {
                    //dead
                    if (neighbours > 2 && neighbours < 5)
                    {
                        aliveTiles.Add(cellPosition);
                    }
                }
            }
        }

        tiles = new HashSet<Vector2Int>(aliveTiles);
        GeneratorUtils.DrawMap(map, _base, tiles);
    }


    public void Clear()
    {
       map.ClearAllTiles();
    }
}