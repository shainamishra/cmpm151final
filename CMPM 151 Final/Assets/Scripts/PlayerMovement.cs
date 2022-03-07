using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Animator animator;

    public GameObject playerON;

    public GameObject modON;
    public GameObject hunterON;
    public GameObject humanON;
    public GameObject frogON;

    public int order = 1;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection = 0f;

    // Awake is called after all objects are initialized. Called in random order
    private void Awake()
    {
        modON.SetActive(true);
        rb = GetComponent<Rigidbody2D>(); // will look for a component on this GameObject (what the script is attached to) of type Rigidbody2D
    }

    // Update is called once per frame
    void Update()
    {
        // swapping
        if (Input.GetKeyDown("space"))
        {
            order++;
            swap();
        }

        if (playerON.activeSelf == true)
        {
            processInputs();

            // Animate
            animate();

            // Move
            move();
        }
    }

    void swap()
    {
        if (order % 4 == 1) 
        {
            modON.SetActive(true);
            hunterON.SetActive(false);
            humanON.SetActive(false);
            frogON.SetActive(false);
        }
        if (order % 4 == 2)
        {
            modON.SetActive(false);
            hunterON.SetActive(true);
            humanON.SetActive(false);
            frogON.SetActive(false);
        }
        if (order % 4 == 3)
        {
            modON.SetActive(false);
            hunterON.SetActive(false);
            humanON.SetActive(true);
            frogON.SetActive(false);
        }
        if (order % 4 == 0)
        {
            modON.SetActive(false);
            hunterON.SetActive(false);
            humanON.SetActive(false);
            frogON.SetActive(true);
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
