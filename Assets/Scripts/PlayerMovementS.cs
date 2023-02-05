using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementS : MonoBehaviour
{
    public float moveSpeed;
    public Transform movePoint;

    public LayerMask obstacles;
    public LayerMask roots;
    public LayerMask idleRoots;
    public bool holding;
    public GameObject theInHand;
    public bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoint.position) < .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                TerranceAnim(Input.GetAxisRaw("Horizontal"));
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0),
                    .2f, obstacles)){
                    
                    if(Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0),
                       .2f, idleRoots))
                    {
                        
                        if(holding && movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) == theInHand.GetComponent<Root>().moves.Peek())
                        {
                            theInHand.GetComponent<Root>().moves.Pop();
                            theInHand.GetComponent<Root>().putDown(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0));
                            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
                        }
                    }
                    

                    else if (holding)
                    {
                        
                        Vector3 oldPosition = movePoint.position;
                        theInHand.GetComponent<Root>().moves.Push(oldPosition);
                        theInHand.GetComponent<Root>().putDown(oldPosition);
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
                    }
                    else
                    { 
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
                    }
                }

            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0,Input.GetAxisRaw("Vertical"),0),
                    .2f, obstacles))
                {

                    if (Physics2D.OverlapCircle(movePoint.position + new Vector3(0,Input.GetAxisRaw("Vertical"),0),
                       .2f, idleRoots))
                    {
                        
                        if (holding && movePoint.position + new Vector3(0,Input.GetAxisRaw("Vertical"),0) == theInHand.GetComponent<Root>().moves.Peek())
                        {
                            theInHand.GetComponent<Root>().moves.Pop();
                            theInHand.GetComponent<Root>().putDown(movePoint.position + new Vector3(0,Input.GetAxisRaw("Vertical"),0));
                            movePoint.position += new Vector3(0,Input.GetAxisRaw("Vertical"),0);
                        }
                    }


                    else if (holding)
                    {
                        
                        Vector3 oldPosition = movePoint.position;
                        theInHand.GetComponent<Root>().moves.Push(oldPosition);
                        theInHand.GetComponent<Root>().putDown(oldPosition);
                        movePoint.position += new Vector3(0,Input.GetAxisRaw("Vertical"),0);
                    }
                    else
                    {
                        movePoint.position += new Vector3(0,Input.GetAxisRaw("Vertical"),0);
                    }
                }

            }
            else if (Physics2D.OverlapCircle(gameObject.transform.position, .2f, roots) && !holding)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    holding = true;
                    theInHand = Physics2D.OverlapCircle(gameObject.transform.position, .2f, roots).gameObject;
                    theInHand.GetComponent<Root>().pickUp();
                }
            }
            else if (holding)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    holding = false;
                    theInHand.GetComponent<Root>().pickUp();
                }
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "LevelEnter"){
            SceneManager.LoadScene(1);
        }
    }

    private void TerranceAnim(float direction){
        if(direction > 0.0 && !facingRight){
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
            facingRight = true;
        }

        if(direction < 0.0f && facingRight){
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
            facingRight = false;
        }
    }
}
