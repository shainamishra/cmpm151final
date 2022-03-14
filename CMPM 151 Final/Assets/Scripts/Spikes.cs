using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    public Animator transition;
    private int x = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("fruit").Length == 0) {
            x = 1;
            StartCoroutine(Collect());
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/win", 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            StartCoroutine(Collect());
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/lose", 1);
        }
    }

    IEnumerator Collect()
    {
        Debug.Log("death");

        // play animation
        transition.SetTrigger("Start");

        // wait for x amount of seconds
        yield return new WaitForSeconds(0.5f);

        // load next scene
        SceneManager.LoadScene(1 + x);

        
    }
}
