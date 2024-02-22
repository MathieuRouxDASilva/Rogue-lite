using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DrunkyardGenerator : MonoBehaviour
{
    //setup variables
    [SerializeField] private Vector2Int stratPosition = new Vector2Int(0, 0);
    [SerializeField] private Tilemap map;
    [SerializeField] private TileBase tile;
    [SerializeField] private float lenghtFactor = 1f;
    [SerializeField] private int _maxArrea = 50;
    
    public void Generate()
    {
        Vector2Int direction =
            GeneratorUtils.vonNeumannNeighbours[Random.Range(0, GeneratorUtils.vonNeumannNeighbours.Length)];
        Vector2Int position = stratPosition;
        //hashset is a list that make sure by itself that their are no "doublons" 
        HashSet<Vector2Int> allPositions = new HashSet<Vector2Int>();


        //loop that cast the postion and add it to the hashset
        allPositions.Add(position);

        do
        {
            int lenght = Mathf.CeilToInt(lenghtFactor * Random.Range(0, 1));
            for (int n = 0; n < lenght; n++)
            {
                position += direction;
                allPositions.Add(position);
            }
        } while (allPositions.Count < _maxArrea);

        GeneratorUtils.DrawMap(map, tile, allPositions);
    }
}