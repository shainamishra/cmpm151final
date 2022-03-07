using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    int var = 0;

    // Start is called before the first frame update
    void Start()
    {
        //player1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // swapping
        if (Input.GetKeyDown("space") && var == 0)
        {
            Debug.Log("switch");
            Switch();
        }
    }

    void Switch()
    {
        if (player1.activeSelf == true && var == 0)
        {
            //Debug.Log("mod to human");
            player1.SetActive(false);
            player2.SetActive(true);
            var = 1;
        }
        else if (player2.activeSelf == true && var == 0)
        {
            //Debug.Log(var);
            //Debug.Log("human to hunter");
            player2.SetActive(false);
            player3.SetActive(true);
            var = 1;
        }
        else if (player3.activeSelf == true && var == 0)
        {
            //Debug.Log("hunter to frog");
            player3.SetActive(false);
            player4.SetActive(true);
            var = 1;
        }
        else if (player4.activeSelf == true && var == 0)
        {
            //Debug.Log("frog to mod");
            player1.SetActive(true);
            player4.SetActive(false);
            var = 1;
        }
    }
}
