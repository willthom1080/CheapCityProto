using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public bool inside = false;

    void Update(){
        if (Input.GetButtonDown("Fire1") && inside){
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }

    public Dialogue signDialogue;

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(signDialogue);
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            inside = true;
            TriggerDialogue();
        }
    }

    public void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player"){
            inside = false;
        }
    }
    
}
