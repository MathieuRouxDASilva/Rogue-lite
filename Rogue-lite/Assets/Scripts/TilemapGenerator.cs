using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour
{
    //setup variables
    [SerializeField] private Tilemap map;
    [SerializeField] private TileBase _base;
    [SerializeField] private TileBase _sand;
    [SerializeField] private int xSize;
    [SerializeField] private int ySize;
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector2 perlinScale = new Vector2(1, 1);
    [SerializeField]private float _centerX;
    [SerializeField]private float _centerY;
    
    
    
    //function that generate a map
    public void GenerateMap()
    {
        
        map.ClearAllTiles();
        
        //set size in editor and center = center of camera
        for (int x = -1 * xSize / 2; x < xSize / 2; x++)
        {
            for (int y = -1 * ySize / 2; y < ySize / 2; y++)
            {

                //perlin noise system (like a random)
                float noiseCoordX = x / (2.0f * xSize);
                float noiseCoordY = y / (2.0f * ySize);

                float rnd = Mathf.PerlinNoise(noiseCoordX * perlinScale.x, noiseCoordY * perlinScale.y);
                //Debug.Log(rnd);
                
                //system that set tile based on rnd
                if (rnd > 0.5f)
                {
                    map.SetTile(
                        new Vector3Int((int)_camera.transform.position.x + x, (int)_camera.transform.position.y + y),
                        _base);   
                }
                else
                {
                    map.SetTile(
                        new Vector3Int((int)_camera.transform.position.x + x, (int)_camera.transform.position.y + y),
                        _sand);
                }
            }
        }
    }
}