using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Root : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isEnd;
    public bool inHand;
    public GameObject player;
    public Tilemap rootTiles;
    public RuleTile newRoot;
    public int desire; //1 for water, 2 for minerals, 3 for fungi
    public bool satisfied;
    public Stack<Vector3> moves;

    private void Start()
    {
        moves = new Stack<Vector3>();
        
    }
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
            Debug.Log("Thinks it's there" + input);
            suckUp(input);
        }
        else
        {
            Debug.Log("Knows it ain't");
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
       
    }
}
