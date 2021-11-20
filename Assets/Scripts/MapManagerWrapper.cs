using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class MapManangerWrapper : MonoBehaviour
{
    public Texture2D map;
    // Start is called before the first frame update

    public GameObject hexObject;
    public float hexSize = 0.1F;
    public GameObject squareObject;
    public float squareSize = 0.1F;
    public int offset_coordinates = 0;
    public float heightMod;
    public int fieldType = 0;

    MapVisualizer map_visualizer;

    List<MapNode> map_nodes;

    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
    }

}