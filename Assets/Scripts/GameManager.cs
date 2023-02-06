using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] rootContainer;
    public RuleTile[] tilesContainer;
    public Tilemap rootTileMap;
    public bool victory;
    void Start()
    {
       rootContainer = GameObject.FindGameObjectsWithTag("Root");
       int i = 0;
       foreach( GameObject x in rootContainer)
        {
            Root target = x.GetComponent<Root>();
            target.rootTiles = rootTileMap;
            target.newRoot = tilesContainer[i];
            target.player = GameObject.FindGameObjectWithTag("Player");
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (victory)
        {
            Debug.Log("You win");
            FindObjectOfType<LevelLoader>().ChangeLevels(SceneManager.GetActiveScene().buildIndex + 1);
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
