using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class WallGeneratorScript : MonoBehaviour
{
    public int objectsPerTheme = 10;
    public GameObject standardWall;
    private GameObject player;

    private float lastGeneration = 0.0f;
    private float yLevel = 0.0f;

    private float xSpacing = 1.0f;
    private float ySpacing = 1.0f;

    private bool isRight = true;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Wall generator running");

        player = GameObject.FindWithTag("Player");
        lastGeneration = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        yLevel = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y; 

        if (player == null)
        {
            Debug.LogError("Player is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < yLevel)
        {
            return;
        }
        yLevel = player.transform.position.y;





    }

    private void GenerateStandardWall(int height, GameObject prefab)
    {
        





        isRight = !isRight;
    }


}
