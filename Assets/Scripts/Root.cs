using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Root : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isEnd;
    public bool inHand;
    public GameObject stemRoot;
    public GameObject player;
    public Tilemap rootTiles;
    public Tile newRoot;

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

    public void putDown(Vector3 input)
    {
        if (rootTiles.HasTile(new Vector3Int((int)input.x - 1, (int)input.y - 1, 0)))
        {
            suckUp(input);
        }
        else
        {
            rootTiles.SetTile(new Vector3Int((int)input.x - 1, (int)input.y - 1, 0), newRoot);
        }
    }

    public void suckUp(Vector3 input)
    {
        rootTiles.SetTile(new Vector3Int((int)input.x - 1, (int)input.y - 1, 0), null);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, gameObject.transform.position, 
            player.GetComponent<PlayerMovementS>().moveSpeed * Time.deltaTime);
    }
}