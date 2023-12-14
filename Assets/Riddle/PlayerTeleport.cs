using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject player;           //player reference
    public GameObject moja;             //GameObject referring to the maze chamber
    public GameObject teleport;         //Referrence to the spot the player will be teleported
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerDet.inChamber)        //If the player is coming from the riddle scene
        {
            moja.SetActive(false);      //Chambers are set to Inactive
            if (!PlayerDet.failed)      //If player has solved the riddle successfully
            {
                
                player.transform.position = teleport.transform.position; //teleport the player to the end of the maze
            }
        }
    }
}
