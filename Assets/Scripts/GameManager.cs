using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] rootContainer;
    bool victory;
    void Start()
    {
       rootContainer = GameObject.FindGameObjectsWithTag("Root");
    }

    // Update is called once per frame
    void Update()
    {
        if (victory)
        {
            Debug.Log("You win");
        }
    }

    public void checkDone()
    {
        bool fire = true;
        foreach (GameObject x in rootContainer){
            if ((!x.GetComponent<Root>().satisfied))
            {
                fire = false;
            }
        }
        victory = fire;
    }
}