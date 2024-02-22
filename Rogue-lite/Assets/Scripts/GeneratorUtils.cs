using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GeneratorUtils
{

    public static Vector2Int[] vonNeumannNeighbours =
    {
        new Vector2Int(0, 1),
        new Vector2Int(1, 0),
        new Vector2Int(0, -1),
        new Vector2Int(-1, 0)
    };
    public static Vector2Int[] mooreNeighbours =
    {
        new Vector2Int(0, 1),
        new Vector2Int(1, 1),
        new Vector2Int(1, 0),
        new Vector2Int(1, -1),
        new Vector2Int(0, -1),
        new Vector2Int(-1, -1),
        new Vector2Int(-1, 0),
        new Vector2Int(-1, 1),
    };
    
    
    public static void DrawMap(Tilemap map, TileBase tile, HashSet<Vector2Int> allPositions)
    {
        map.ClearAllTiles();
        
        foreach (Vector2Int position in allPositions)
        {
            map.SetTile(new Vector3Int(position.x, position.y), tile);
        }
        
    }
}