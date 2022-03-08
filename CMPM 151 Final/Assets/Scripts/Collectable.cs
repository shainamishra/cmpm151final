using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            animator.Play("Collected");
            StartCoroutine(Collect());
        }
    }
    IEnumerator Collect()
    {
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
    }
}
