using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Windows;

public class Root : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isEnd;
    public bool inHand;
    public GameObject player;
    public Tilemap rootTiles;
    public RuleTile newRoot;
    public Tile[] newRoots;
    public int desire; //1 for water, 2 for minerals, 3 for fungi
    public bool satisfied;
    public Stack<Vector3> moves;

    struct pathway
    {
        bool inLine;
    }

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
            if (moves.Count() == 0)
            {
                moves.Push(transform.position);
            }
        }
        else
        {
            inHand = false;
            gameObject.transform.parent = null;
        }
        
    }

    public void thinkTrail()
    {
        if (rootTiles.HasTile(new Vector3Int((int)transform.position.x, (int)transform.position.y, 0)))
        {
            //Turn back into "head" of root
        }
        else
        {
            putTrail();
        }
    }

    private void putTrail()
    {
        if (moves.Count == 1)
        {
            
        }
        else
        {
            Vector3 temp = moves.Pop();
            bool verticalDest = ((temp.x - transform.position.x) == 0);
            bool verticalOrig = ((temp.x - moves.Peek().x) == 0);
            if(verticalDest == verticalOrig)//Straight line root being placed
            {
                rootTiles.SetTile(new Vector3Int((int)temp.x, (int)temp.y, 0), newRoots[1]);
            }
            else//Curved root being placed
            {
                rootTiles.SetTile(new Vector3Int((int)temp.x, (int)temp.y, 0), newRoots[2]);
            }
            moves.Push(temp);

        }
        rootTiles.SetTile(new Vector3Int((int)transform.position.x, (int)transform.position.y, 0), newRoots[0]);
    }

    public void safePutDown(Vector3 input)
    {
        
        if (rootTiles.HasTile(new Vector3Int((int)input.x - 1, (int)input.y - 1, 0)))
        {

            suckUp(input);
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
       
    }
}
