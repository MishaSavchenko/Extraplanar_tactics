using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public struct MapNode
{
    public MapNode(string name_, Vector3 position_, Color color_)
    {
        name = name_;
        position = position_;
        color = color_;
    }
    public string name { get; }
    public Vector3 position { get; }
    public Color color { get; }

}