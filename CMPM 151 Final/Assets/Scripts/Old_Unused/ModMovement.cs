using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModMovement : MonoBehaviour
{
    public float moveSpeed;
    public Animator animator;

    public GameObject modON;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection = 0f;

    // Awake is called after all objects are initialized. Called in random order
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // will look for a component on this GameObject (what the script is attached to) of type Rigidbody2D
    }

    // Update is called once per frame
    void Update()
    {
        if (modON.activeSelf == true)
        {
            processInputs();

            // Animate
            animate();

            // Move
            move();

            // swapping
            if (Input.GetKeyDown("space"))
            {
                //swap();
            }
        }
    }

    void swap()
    {
        if (player1.activeSelf == true && (Input.GetKeyDown("space")))
        {
            Debug.Log("in mod script 1");
            player1.SetActive(false);
            player2.SetActive(true);
            player3.SetActive(false);
            player4.SetActive(false);
        }
    }

    private void move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (Input.GetKeyDown("w"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10, 0);
        }
    }

    private void animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            flipChara();
        }
        else if (moveDirection < 0 && facingRight)
        {
            flipChara();
        }
    }

    private void processInputs()
    {
        moveDirection = Input.GetAxis("Horizontal"); // from -1 to 1
        animator.SetFloat("Speed", Mathf.Abs(moveDirection));
    }

    private void flipChara()
    {
        facingRight = !facingRight; //inverse boolean
        transform.Rotate(0f, 180f, 0f);
    }
}
