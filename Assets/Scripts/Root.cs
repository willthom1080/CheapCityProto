using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isEnd;
    public bool inHand;
    public GameObject stemRoot;
    public GameObject player;

    public void pickUp()
    {
        if (!inHand)
        {
            inHand = true;
            gameObject.transform.parent = player.transform;
        }
        else
        {
            inHand = false;
            gameObject.transform.parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, gameObject.transform.position, 
            player.GetComponent<PlayerMovementS>().moveSpeed * Time.deltaTime);
    }
}
