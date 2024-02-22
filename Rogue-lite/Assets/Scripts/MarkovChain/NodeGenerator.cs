using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGenerator
{
    //setup variables text generator
    private string _text;
    private List<NodeGenerator> _nextNode; //node == noeud

    //constructor
    public NodeGenerator(string nodetext)
    {
        _text = nodetext;
        _nextNode = new List<NodeGenerator>();
    }
    
    //function to add a node to the list
    public void AddNode(string nodeText)
    {
        if (_nextNode != null)
        {
            _nextNode.Add(new NodeGenerator(nodeText));
        }
    }
    
}
