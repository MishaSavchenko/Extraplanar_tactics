using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    // Map settings
    public Texture2D map;
    public GameObject hexObject;
    public float hexSize = 0.1F;
    public GameObject squareObject;
    public float squareSize = 0.1F;
    public int offset_coordinates = 0;
    public float heightMod;
    public int fieldType = 0;


    public GameObject test_character; 
    public int spawn_x = 0; 
    public int spawn_y = 0; 
    // Start is called before the first frame update
    void Start()
    {
        // given a list of objects spawn them on the filed with the given coordinates 
        // figure out where to what to spawn ( or use the test_character ) 
        // get coordinates coresponding to ij from the map object 
        // spawn the object at the coordinates 

        Vector3 map_center = GetComponent<Renderer>().bounds.center;
        Vector3 map_size = GetComponent<Renderer>().bounds.size;

        // Create the map manager
        MapManager map_manager = new MapManager(map_center,
                                               map_size,
                                               map,
                                               hexObject,
                                               hexSize,
                                               squareObject,
                                               squareSize,
                                               offset_coordinates,
                                               heightMod,
                                               fieldType);
        map_manager.initialize();


        Vector3 spawn_position = map_manager.getCoordinates(spawn_x,spawn_y);

        test_character.transform.localScale= new Vector3(0.9f, 0.9f, 0.9f);
        spawn_position.y += test_character.GetComponent<Renderer>().bounds.size.y/2 + 0.1f;


        GameObject actor = Instantiate(test_character, spawn_position, Quaternion.identity);
        
    }

    void setUpMap()
    { }

    // Update is called once per frame
    void Update()
    {

    }
}
