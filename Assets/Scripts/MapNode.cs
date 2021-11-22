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

    public static bool operator ==(MapNode a, MapNode b)
    {
        bool name_b = a.name == b.name;
        bool position_b = a.position == b.position;
        bool color_b = a.color == b.color;
        return name_b & position_b & color_b;
    }

    public static bool operator !=(MapNode a, MapNode b)
    {
        return !(a == b);
    }

    public override bool Equals(object o)
    {
        if (o == null)
            return false;

        MapNode? second = o as MapNode?;

        return second != null && this == second;
    }

    public override int GetHashCode()
    {
        return this.name.GetHashCode() ;
    }
}