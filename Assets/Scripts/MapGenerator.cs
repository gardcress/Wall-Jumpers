using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class MapGeneratorScript : MonoBehaviour
{
    public int objectsPerTheme = 10;
    
    public GameObject standardWall;
    public GameObject groundPrefab;

    private float wallSpacing = 2.0f;

    private string[] map = new string[]
    {
        " xo ",
        " ox ",
        " xo ",
        " ox ",
        " xo ",
        " ox ",
        " xo ",
        " ox ",
        " xo ",
        " ox ",
        "-"
    };

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Map generator running");


        for(int y = 0; y < map.Length; y++)
        {
            string row = map[y]; 

            for (int x = 0; x < row.Length; x++)
            {
                char tile = row[x];
                if(tile == '-')
                {
                    Camera cam = Camera.main;
                    float screenHeight = cam.orthographicSize * 2;
                    float screenWidth = (screenHeight * cam.aspect);

                    GameObject ground = Instantiate(groundPrefab, new Vector2(0,0), Quaternion.identity, transform);

                    // set scale
                    ground.transform.localScale = new Vector3(screenWidth, ground.transform.localScale.y, ground.transform.localScale.z);
                    Debug.Log(transform.localScale.y);

                    // move the square so the bottom edge aligns with the bottom of the screen
                    ground.transform.position = new Vector3(0, -screenHeight / 2 + ground.transform.localScale.y / 2, 0);
                }

                if (tile == 'x')
                {

                }
                else if (tile == 'o')
                {
                }
            }
        }




    }

    // Update is called once per frame
    void Update()
    {


    }


}
