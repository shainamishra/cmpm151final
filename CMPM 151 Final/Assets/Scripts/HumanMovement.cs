using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;

public class HumanMovement : MonoBehaviour
{
    public float moveSpeed;
    public Animator animator;

    public GameObject humanON;

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
        if (humanON.activeSelf == true)
        {
            processInputs();

            // Animate
            animate();

            // Move
            move();
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
    // Start is called before the first frame update
    void Start()
    {
        Application.runInBackground = true;

        OSCHandler.Instance.Init();
    }

    void FixedUpdate() {

		OSCHandler.Instance.UpdateLogs();
		Dictionary<string, ServerLog> servers = new Dictionary<string, ServerLog>();
		servers = OSCHandler.Instance.Servers;

		foreach (KeyValuePair<string, ServerLog> item in servers) {
			// If we have received at least one packet,
			// show the last received from the log in the Debug console
			if (item.Value.log.Count > 0) {
				int lastPacketIndex = item.Value.packets.Count - 1;
			}
		}
    }
}
