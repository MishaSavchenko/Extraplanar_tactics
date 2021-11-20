using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSetup : MonoBehaviour
{
    /* 
     * https://www.redblobgames.com/grids/hexagons/
     * setup the field
     * draw hexagons
     * highlight hexagons on the field when hover 
     * 
     * 
     * non rectangular meshes 
     *      high  
     * 
     * 
     * 
     * 
     */
    // Start is called before the first frame update
    public GameObject hexObject;
    public float hexSize = 0.1F;

    public GameObject squareObject;
    public float squareSize = 0.1F;

    float wi, hi;

    Renderer rend;

    public int offset_coordinates = 0;

    public float heighMod;
    //private enum OffsetFunction ;
    private List<offsetFunc> OffsetFunctions;

    Color red_ncs; //= new Color(191, 26, 47);
    Color mardi_gras; // = new Color(128, 26, 134);
    Color caribbean_green; //= new Color(38, 196, 133);
    Color blue_ncs; // = new Color(54, 133, 181);

    GameObject map; 

    public int fieldType = 0;
    
    void Start()
    {
        map = GameObject.Find("field");
        map.GetComponentInChildren<Renderer>().enabled = false;
        
        // Tile Color list 
        red_ncs =         new Color(191 / 255.0f, 26 / 255.0f, 47 / 255.0f);
        mardi_gras =      new Color(128 / 255.0f, 26 / 255.0f, 134 / 255.0f);
        caribbean_green = new Color(38 / 255.0f, 196 / 255.0f, 133 / 255.0f);
        blue_ncs =        new Color(54 / 255.0f, 133 / 255.0f, 181 / 255.0f);

        setupGridParams(fieldType);

    }

    delegate void offsetFunc(int w, int h, ref Vector3 pos);

    void oddRowOffset(int w, int h, ref Vector3 pos)
    {
        float offset = h % 2 == 0 ? 0 : wi / 2;
        pos += new Vector3(offset, 0, 0);
    }

    void evenRowOffset(int w, int h, ref Vector3 pos)
    {
        float offset = h % 2 == 1 ? 0 : wi / 2;
        pos += new Vector3(offset, 0, 0);
    }

    void oddColumnOffset(int w, int h, ref Vector3 pos)
    {
        float offset = w % 2 == 0 ? 0 : hi / 2;
        pos += new Vector3(0, 0, offset);
    }

    void evenColumnffset(int w, int h, ref Vector3 pos)
    {
        float offset = w % 2 == 0 ? 0 : hi / 2;
        pos += new Vector3(0, 0, offset);
    }

    
    void setupGridParams(int type)
    {
        if(type == 0)
        {
            wi = Mathf.Sqrt(3) * hexSize / 2;
            hi = hexSize * 3 / 4;

            rend = GetComponent<Renderer>();
            Vector3 fieldCenter = rend.bounds.center;
            Vector3 fieldSize = rend.bounds.size;

            int horizontalHexNum = (int)Mathf.Ceil(fieldSize.z / hi);
            int verticalHexNum = (int)Mathf.Ceil(fieldSize.x / wi);

            OffsetFunctions = new List<offsetFunc>() { oddRowOffset, evenRowOffset, evenColumnffset, oddColumnOffset };
            Vector3 origin = fieldCenter - fieldSize / 2;
            constructHexGrid(verticalHexNum, horizontalHexNum,  origin, OffsetFunctions[offset_coordinates]);
        }
        else if (type == 1)
        {
            wi = squareSize;
            hi = squareSize;

            rend = GetComponent<Renderer>();
            Vector3 fieldCenter = rend.bounds.center;
            Vector3 fieldSize = rend.bounds.size;

            int horizontalHexNum = (int)Mathf.Ceil(fieldSize.z / hi);
            int verticalHexNum = (int)Mathf.Ceil(fieldSize.x / wi);

            OffsetFunctions = new List<offsetFunc>() { oddRowOffset, evenRowOffset, evenColumnffset, oddColumnOffset };
            Vector3 origin = fieldCenter - fieldSize / 2 + new Vector3(squareSize / 2.0f, 0.0f, squareSize / 2.0f);
            constructSquareGrid(verticalHexNum, horizontalHexNum, origin);
        }
    }

    void constructHexGrid(int width, int height, Vector3 origin, offsetFunc offset_func)
    {
        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                Vector3 pos = origin + new Vector3(w * wi , 0, h * hi);
                offset_func(w, h, ref pos);
                GameObject tile = Instantiate(hexObject, pos, Quaternion.identity);
                tile.transform.localScale *= hexSize;
                styleObjectFromGrid(tile, h, w);
                tile.transform.parent = map.transform;
            }
        }
    }

    void constructSquareGrid(int width, int height, Vector3 origin)
    {

        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                Vector3 pos = origin + new Vector3(w * wi, heighMod * Random.value, h * hi);
                GameObject tile = Instantiate(squareObject, pos, Quaternion.identity);
                tile.transform.localScale *= squareSize;
                styleObjectFromGrid(tile, h, w);
                tile.transform.parent = map.transform;
            }
        }
    }

    void styleObjectFromGrid(GameObject go, int h, int w)
    {

        Color tile_color;
        if (h % 2 == 0)
        {
            tile_color = w % 2 == 0 ? red_ncs : blue_ncs;
        }
        else
        {
            tile_color = w % 2 == 0 ? mardi_gras : caribbean_green;
        }
        go.GetComponent<Renderer>().material.SetColor("_Color", tile_color);
        go.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
