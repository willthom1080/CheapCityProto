using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExperimentalPlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform movePoint;

    public LayerMask obstacles;
    public LayerMask roots;
    public LayerMask idleRoots;
    public bool holding;
    public GameObject theInHand;
    public bool facingRight = true;

    public Animator transition;
    public float transitionTime = 1f;
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
                    .2f, obstacles))
                {
                    moveMe(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0));
                }

            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0, Input.GetAxisRaw("Vertical"), 0),
                    .2f, obstacles))
                {
                    moveMe(movePoint.position + new Vector3(0, Input.GetAxisRaw("Vertical"), 0));
                }

            }
            else if (Physics2D.OverlapCircle(gameObject.transform.position, .2f, roots) && !holding)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    holding = true;
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    theInHand = Physics2D.OverlapCircle(gameObject.transform.position, .2f, roots).gameObject;
                    //theInHand.GetComponent<Root>().putDown(transform.position);
                    theInHand.GetComponent<Root>().pickUp();
                }
            }
            else if (holding)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    holding = false;
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    //theInHand.GetComponent<Root>().putDown(transform.position);
                    theInHand.GetComponent<Root>().pickUp();
                    theInHand = null;

                }
            }
        }

    }

    private void TerranceAnim(float direction)
    {
        if (direction > 0.0 && !facingRight)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
            facingRight = true;
        }

        if (direction < 0.0f && facingRight)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
            facingRight = false;
        }
    }

    private void moveMe(Vector3 dest)
    {
        if (Physics2D.OverlapCircle(dest, .2f, idleRoots) || (holding && theInHand.GetComponent<Root>().satisfied))
        {

            if (holding)
            {
                theInHand.GetComponent<Root>().thinkTrail();
                movePoint.position = dest;
            }
            if (!holding)
            {
                movePoint.position = dest;
            }
        }


        else if (holding && !Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0),
           .2f, roots))
        {
            Vector3 oldPosition = movePoint.position;
            theInHand.GetComponent<Root>().moves.Push(oldPosition);
            theInHand.GetComponent<Root>().putDown(oldPosition);
            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        }
        else if (!holding)
        {
            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        }
    }
}
