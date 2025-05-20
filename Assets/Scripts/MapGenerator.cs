using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Random = UnityEngine.Random;

public class MapGeneratorScript : MonoBehaviour
{
    public int objectsPerTheme = 10;
    
    public GameObject standardWall; //x
    public GameObject groundPrefab; //
    public GameObject smallBlock; //b
    public GameObject slideWall; //s
    public GameObject spikeWallRight; //d
    public GameObject spikeWallLeft; //a



    // ALL MAPS GENERATE FROM THE BOTTOM UP

    private string[] startMap = new string[]
    {
        "++x",
        "--x-b+",
        "++x"
    };

    private string[] rightSmallBlockStairs = new string[]
    {
        "-b",
        "x",
        "+b*+b*+b"
    };

    private string[] standardElevatorShaft = new string[]
    {
        "x++x--",
        "b++x--",
        "x++x--",
        "x++b--",
        "x++x--",
        "-x++b--"
    };

    private string[] slideElevatorShaft = new string[]
    {
        "s++s--",
        "b++s--",
        "s++s--",
        "s++b--",
        "s++s--",
        "-s++b--"
    };

    private string[] spikeElevatorShaft = new string[]
    {
        "s++s--",
        "p++s--",
        "s++s--",
        "s++p--",
        "s++s--",
        "-s++p--"
    };

    private string[] spikeElevatorShaftLong = new string[]
    {
        "p++s--",
        "p++s--",
        "p++p--",
        "s++p--",
        "s++s--",
        "-s++p--",
        "s++p--",
        "p++s--",
        "p++s--",
        "p++p--",
        "p++s--",
        "-s++p--"
    };

    private string[] spikePillarJump = new string[]
    {
        "+s",
        "+p++p++p++s",
        "s"
    };

    private string[] spikeStairs = new string[]
    {
        "++s",
        "b",
        "-p",
        "--s",
        "p",
        "++s",
        "++s",
        "++s"
    };

    private string[] smallBlockClimbWall = new string[]
    {
        "-b+++b",
        "+b++++b",
        "+++b---b----b",
        "b+++++b",
        "---b---b",
        "--b++++b+++++b",
        "+--b-b----b",
        "-b++b++b"
    };

    private string[] standardWallNormal = new string[]
    {
        "--x",
        "++x",
        "x",
        "--x",
        "++x",
        "--x",
        "++x",
        "x"
    };


    private string[] standardWallNormal2 = new string[]
    {
        "-s",
        "++s",
        "x",
        "b",
        "x",
        "++s",
        "--s",
        "+x"
    };


    private string[] rightSmallBlockPillarJump = new string[]
    {
        "+x",
        "+b++b++b++b",
        "x"
    };

    

    private string[] standardPillarJump = new string[]
    {
        "+x",
        "+x++x++x++x",
        "x"
    };

    private string[] standardStairs = new string[]
    {
        "++x",
        "b",
        "-x",
        "--x",
        "b",
        "++x",
        "++x",
        "++x"
    };


    private Vector2 spawnerAnchor = new Vector2(0,0);
    private GameObject lastObjectInRow;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Map generator running");

        lastObjectInRow = standardWall;

        Camera cam = Camera.main;
        float screenHeight = cam.orthographicSize * 2;
        float screenWidth = (screenHeight * cam.aspect);

        GameObject ground = Instantiate(groundPrefab, new Vector2(0, 0), Quaternion.identity, transform);

        // set scale
        //ground.transform.localScale = new Vector3(screenWidth, ground.transform.localScale.y, ground.transform.localScale.z);
        //Debug.Log(transform.localScale.y);

        // move the square so the bottom edge aligns with the bottom of the screen
        ground.transform.position = new Vector3(0, -screenHeight / 2, 0);

        spawnerAnchor = new Vector2(ground.transform.position.x - 1, ground.transform.position.y + 0f);


        SpawnMap(startMap);

        //SpawnMap(spikePillarJump);
        //SpawnMap(spikeStairs);
        //SpawnMap(spikeElevatorShaftLong);


        SpawnMap(standardWallNormal);


        SpawnRandomMap();
        SpawnRandomMap();
        //SpawnMap(smallBlockClimbWall);
        //SpawnMap(standardElevatorShaft);
        //SpawnMap(rightSmallBlockPillarJump);
        //SpawnMap(rightSmallBlockStairs);
        //SpawnMap(standardPillarJump);
        //SpawnMap(standardStairs);

    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player.transform.position.y >= spawnerAnchor.y - 20)
        {
            Debug.Log("Spawning new map part");
            SpawnRandomMap();
        }

    }

    void SpawnRandomMap()
    {
        // Array of possible map chunks
        string[][] mapChunks = new string[][]
        {
        startMap,
        smallBlockClimbWall,
        standardElevatorShaft,
        rightSmallBlockPillarJump,
        rightSmallBlockStairs,
        standardPillarJump,
        standardWallNormal, standardWallNormal,
        standardWallNormal2, standardWallNormal2,
        slideElevatorShaft,
        standardStairs,
        spikePillarJump,
        spikeElevatorShaftLong,
        spikeElevatorShaft,
        spikeStairs
        };


        int randIndex = Random.Range(0, mapChunks.Length);
        SpawnMap(mapChunks[randIndex]);
    }

    private void SpawnMap(string[] str)
    {
        string[] map = str;
        Array.Reverse(map);


        foreach (string row in map)
        {
            bool isFirstObject = true;

            foreach (char col in row)
            {
                // MAP OPERATORS
                if (col == '+')
                {
                    spawnerAnchor.x += 1.0f;
                    continue;
                }
                if (col == '-')
                {
                    spawnerAnchor.x -= 1.0f;
                    continue;
                }
                if (col == '*')
                {
                    spawnerAnchor.y += 1.0f;
                    continue;
                }
                if (col == '/')
                {
                    spawnerAnchor.y -= 1.0f;
                    continue;
                }


                // MAP OBJECTS
                if (col == 'x')
                {
                    lastObjectInRow = SpawnObject(standardWall, isFirstObject);
                }
                else if (col == 'b')
                {
                    lastObjectInRow = SpawnObject(smallBlock, isFirstObject);
                }
                else if (col == 's')
                {
                    lastObjectInRow = SpawnObject(slideWall, isFirstObject);
                }
                else if (col == 'p')
                {
                    if (Random.value < 0.5f)
                    {
                        lastObjectInRow = SpawnObject(spikeWallRight, isFirstObject);
                    }
                    else
                    {
                        lastObjectInRow = SpawnObject(spikeWallLeft, isFirstObject);
                    }
                }


                isFirstObject = false;
            }

            
            spawnerAnchor.y += 1f;
        }
    }

    GameObject SpawnObject(GameObject go, bool isFirstObject)
    {
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
        float localHeight = sr.sprite.bounds.size.y;

        if (isFirstObject)
        {
            spawnerAnchor.y += localHeight / 4;
            SpriteRenderer lastSr = lastObjectInRow.GetComponent<SpriteRenderer>();
            float lastHeight = lastSr.sprite.bounds.size.y;
            spawnerAnchor.y += lastHeight / 4;
        }   

        return Instantiate(go, new Vector2(spawnerAnchor.x, spawnerAnchor.y), Quaternion.identity, transform);


        //if(isFirstObject)
        //{
        //    spawnerAnchor.y += localHeight / 4;
        //}
    }

}
