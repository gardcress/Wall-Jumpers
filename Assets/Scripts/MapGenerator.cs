using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class MapGeneratorScript : MonoBehaviour
{
    public int objectsPerTheme = 10;
    
    public GameObject standardWall;
    public GameObject groundPrefab;

    private string[] startMap = new string[]
    {
        "x",
        "+x",
        "x"
    };

    private string[] startMap2 = new string[]
    {
        "x",
        "-x",
        "x"
    };

    private string[] normalSegment1 = new string[]
    {
        "x",
        "+x",
        "x",
        "-x",
        "x",
        "+x",
        "x",
        "-x",
        "x",
        "+x",
        "x"
    };

    private string[] normalSegment2 = new string[]
    {
        "x",
        "+x",
        "+x",
        "+x",
        "x",
        "+x",
        "+x",
        "+x",
        "x"
    };

    private Vector2 spawnerAnchor = new Vector2(0,0);


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Map generator running");
        


        Camera cam = Camera.main;
        float screenHeight = cam.orthographicSize * 2;
        float screenWidth = (screenHeight * cam.aspect);

        GameObject ground = Instantiate(groundPrefab, new Vector2(0, 0), Quaternion.identity, transform);

        // set scale
        //ground.transform.localScale = new Vector3(screenWidth, ground.transform.localScale.y, ground.transform.localScale.z);
        //Debug.Log(transform.localScale.y);

        // move the square so the bottom edge aligns with the bottom of the screen
        ground.transform.position = new Vector3(0, -screenHeight / 2, 0);

        spawnerAnchor = new Vector2(ground.transform.position.x - 1, ground.transform.position.y + 2);


        SpawnMap(startMap);
        SpawnMap(normalSegment1);
        SpawnMap(normalSegment2);
        SpawnMap(normalSegment1);
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player.transform.position.y >= spawnerAnchor.y - 20)
        {
            Debug.Log("Spawning new map part");
            SpawnMap(normalSegment1);
        }

    }

    private void SpawnMap(string[] str)
    {
        string[] map = str;
        Array.Reverse(map);

        foreach (string row in map)
        {
            foreach (char col in row)
            {
                if (col == 'x')
                {
                    SpawnObject(standardWall, spawnerAnchor.x, spawnerAnchor.y);
                    continue;
                }
                if(col == '+')
                {
                    spawnerAnchor.x += 2.5f;
                    continue;
                }
                if (col == '-')
                {
                    spawnerAnchor.x -= 2.5f;
                    continue;
                }
            }
            spawnerAnchor.y += 3.5f;
        }
    }

    void SpawnObject(GameObject go, float x, float y)
    {
        Instantiate(go, new Vector2(x, y), Quaternion.identity, transform);
    }

}
