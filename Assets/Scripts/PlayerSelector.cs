using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        //string playerId = CharacterSelector.gameObjectId;
        //if (playerId.Equals("default"))
        //{
        //    player1.SetActive(true);
        //    return;
        //}
        //if (playerId.Equals("crow"))
        //{
        //    player1.SetActive(true);
        //    return;
        //}
        if (PlayerPrefs.HasKey("playerId"))
        {
            if(PlayerPrefs.GetInt("playerId") == 0)
            {
                player1.SetActive(true);
                return;
            }
            if (PlayerPrefs.GetInt("playerId") == 1)
            {
                player2.SetActive(true);
                return;
            }

        } else
        {
            player1.SetActive(true) ;
            Debug.Log("No player pref found for player");
        }


    }

    
}
