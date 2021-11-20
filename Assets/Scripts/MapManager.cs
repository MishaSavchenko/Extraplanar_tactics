using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class MapManager
{
    public Vector3 plane_center;
    public Vector3 plane_size; 

    public Texture2D map;

    public GameObject hexObject;
    public float hexSize = 0.1F;
    public GameObject squareObject;
    public float squareSize = 0.1F;
    public int offset_coordinates = 0;
    public float heightMod;
    public int fieldType = 0;

    MapVisualizer map_visualizer;

    List<MapNode> map_nodes;

    public MapManager(Vector3 center_,
                       Vector3 size_,
                       Texture2D map_,
                       GameObject hexObject_,
                       float hexSize_,
                       GameObject squareObject_,
                       float squareSize_,
                       int offset_coordinates_,
                       float heightMod_,
                       int fieldType_)
    {
        this.plane_center = center_;
        this.plane_size = size_;

        this.map = map_;
        this.hexObject = hexObject_;
        this.hexSize = hexSize_;
        this.squareObject = squareObject_;
        this.squareSize = squareSize_;
        this.offset_coordinates = offset_coordinates_;
        this.heightMod = heightMod_;
        this.fieldType = fieldType_;
    }

    public void initialize()
    {
        Vector3 map_size = new Vector3(map.width, 1, map.height);

        Vector3 cube_scale = new Vector3(plane_size.x / map_size.x,
                                         0.2f,
                                         plane_size.z / map_size.z);
        cube_scale /= 2.0f;

        Vector3 map_origin = plane_center - plane_size / 2 + new Vector3(cube_scale.x / 2.0f,
                                                                         0.0f,
                                                                         cube_scale.z / 2.0f);
        map_origin.y = 0.5f;

        map_visualizer = new MapVisualizer(hexObject,
                                            squareObject,
                                            offset_coordinates,
                                            heightMod,
                                            fieldType);

        map_visualizer.cubeScale = cube_scale;
        map_nodes = new List<MapNode>(map.width * map.height);
        for (int h = 0; h < map.height; h++)
        {
            for (int w = 0; w < map.width; w++)
            {

                int node_index = w + (map.width * h);
                Vector3 node_pos = map_origin + new Vector3(w * cube_scale.x * 2, 0, h * cube_scale.z * 2);
                Color pixel_color = map.GetPixel(w, h);
                MapNode new_node = new MapNode("", node_pos, pixel_color);
                map_nodes.Add(new_node);
                map_visualizer.spawnNode(new_node);
            }
        }
    }

    public Vector3 getCoordinates(int i, int j)
    {
        int node_index = this.map.width * j + i;
        return this.map_nodes[node_index].position;
    }
}
