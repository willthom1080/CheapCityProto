using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public int resType;
    public PlayerMovementS player;
    GameObject theManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementS>();
        theManager = GameObject.FindGameObjectWithTag("GameController");
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<Root>() != null)
        {
            if (collision.gameObject.GetComponent<Root>().desire == resType)
            {
                player.holding = false;
                player.GetComponent<SpriteRenderer>().enabled = true;
                player.theInHand.GetComponent<Root>().pickUp();
                collision.gameObject.transform.position = transform.position;
                player.theInHand.GetComponent<Root>().satisfied = true;
                theManager.GetComponent<GameManager>().checkDone();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Root>() != null)
        {
            if (collision.gameObject.GetComponent<Root>().desire == resType)
            {
                
                player.theInHand.GetComponent<Root>().satisfied = false;
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
