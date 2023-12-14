using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

public class PlayerDet : MonoBehaviour
{
    //Welcome messages
    private string[] dialogueLines = { "Hello and Welcome, Maze Walker!", 
        "You have to reach to the other side of the maze to escape this island.", 
        "You can find the Maze guardians' chambers in the maze. They are the blue spheres.", 
        "Answering a riddle inside the chamber takes you to the other side of the maze.", 
        "You can follow the map for help.", "Press the controller trigger to show/hide the map.", 
        "Go to the cave after solving the maze.", 
        "You can reach cave by going to the left side of the map.", 
        "Now, go inside the maze and start the adventure." };
    // Text object to display dialogue
    [SerializeField] private TextMeshProUGUI dialogueText; 
    //Canvas to contain the Text object
    [SerializeField] private Canvas dialogueCanvas;
    //Class variable to check whether the player has been into the NPC's collider
    static public bool first = true;
    //This checks whether has been into the NPC's collider after failing to solve the riddle
    bool yes = true;                                       
    //Messages after the player has failed to solve 
    private string[] afterLines = { "You have failed!", 
        "The Guardians' chambers can no longer be used.", 
        "The maze has also changed", 
        "You have to solve the maze manually now.", 
        "All the best." };
    //Class variable to check if the player has solve the riddle
    static public bool failed = false;
    //Check whether the player has been into the Maze Guardian's chamber
    static public bool inChamber = false;

    private void Start()
    {
        //NPC's dialogue canvas is set to be inactive
        dialogueCanvas.enabled = false;
        //canva.SetActive(false);
    }

    //To check whether the player is in the proximity of the NPC
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "OVRPlayerController")
        {
            dialogueCanvas.enabled = true;
            StartDialogue();
            first = false;
        }
    }
    //To check whether the player is far from the NPC
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "OVRPlayerController")
        {
            dialogueCanvas.enabled = false;
            StopDialogue();
        }
    }
    //NPC starts talking
    void StartDialogue()
    {
        StartCoroutine(DisplayDialogueLines());
    }
    //NPC stops talking
    void StopDialogue()
    {
        dialogueText.text = "";
    }

    //The coroutine below checks the progress into the game and based on the progress
    //the dialogues are shown to the player
    IEnumerator DisplayDialogueLines()
    {
        if (first)
        {
            foreach (string line in dialogueLines)
            {
                dialogueText.text = line;
                yield return new WaitForSeconds(2.75f); // Delay between lines
            }
        }
        else if (!inChamber)
        {
            dialogueText.text = "Go inside the maze and start the adventure.";
        }
        else if (failed && yes)
        {
            yes = false;
            foreach (string line in afterLines)
            {
                dialogueText.text = line;
                yield return new WaitForSeconds(2.75f); // Delay between lines
            }
        }
        else
        {
            dialogueText.text = "All the best";
        }
    }
}
