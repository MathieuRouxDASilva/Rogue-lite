using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(GameOfLifeGenerator))]
public class GameOfLifeGeneratorEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameOfLifeGenerator gen = (GameOfLifeGenerator)target;


        if (GUILayout.Button("Generate"))
        {
            gen.Generate();
        }
        if (GUILayout.Button("Clear"))
        {
            gen.Clear();
        }
        if (GUILayout.Button("Game of life iteration"))
        {
            gen.GameOfLifeIteration();
        }

    }
    
}