using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    public Animator transition;

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
            StartCoroutine(Collect());
        }
    }

    IEnumerator Collect()
    {
        Debug.Log("death");

        // play animation
        transition.SetTrigger("Start");

        // wait for x amount of seconds
        yield return new WaitForSeconds(0.2f);

        // load next scene
        SceneManager.LoadScene(1);
    }
}
