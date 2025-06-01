using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public bool isRightArrow = true;
    public GameObject targetSpriteObject;

    public static string gameObjectId = "default";

    public Sprite defaultPlayer;
    public Sprite crowPlayer;

    private int playerCounter = 0;
    private int maxPlayers = 2;




    // Start is called before the first frame update
    void Start()
    {
        if(targetSpriteObject == null)
        {
            Debug.LogError("No target sprite object found");
            return;
        }
    }

    public void selectRight()
    {
        playerCounter++;
        if (playerCounter == maxPlayers) {
            playerCounter = 0;
        }
        selectNewPlayer();
    }



    public void selectLeft()
    {
        playerCounter--;
        if(playerCounter == -1)
        {
            playerCounter = maxPlayers - 1;
        }
        selectNewPlayer();
    }


    void selectNewPlayer()
    {
        if (playerCounter == 0)
        {
            gameObjectId = "default";
            targetSpriteObject.GetComponent<Image>().sprite = defaultPlayer;
            targetSpriteObject.transform.localScale = new Vector3(3.7f, 3.7f, 3.7f);

            return;
        }
        if (playerCounter == 1)
        {
            gameObjectId = "crow";
            targetSpriteObject.GetComponent<Image>().sprite = crowPlayer;
            targetSpriteObject.transform.localScale = new Vector3(4.5f, 4.5f, 4.5f);
            return;
        }
    }
}
