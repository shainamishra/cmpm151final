using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform hunter;
    public Transform frog;
    public Transform human;
    public Transform mod;

    public GameObject hunterON;
    public GameObject frogON;
    public GameObject humanON;
    public GameObject modON;

    public float[] _xClamp;
    public float[] _yClamp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // focus on the hunter
        if (hunterON.activeSelf == true)
        {
            float xClamp = Mathf.Clamp(hunter.position.x, _xClamp[0], _xClamp[1]);
            float yClamp = Mathf.Clamp(hunter.position.y, _yClamp[0], _yClamp[1]);
            transform.position = new Vector3(xClamp, yClamp, transform.position.z);
        }

        // focus on the frog
        if (frogON.activeSelf == true)
        {
            float xClamp = Mathf.Clamp(frog.position.x, _xClamp[0], _xClamp[1]);
            float yClamp = Mathf.Clamp(frog.position.y, _yClamp[0], _yClamp[1]);
            transform.position = new Vector3(xClamp, yClamp, transform.position.z);
        }

        // focus on the human
        if (humanON.activeSelf == true)
        {
            float xClamp = Mathf.Clamp(human.position.x, _xClamp[0], _xClamp[1]);
            float yClamp = Mathf.Clamp(human.position.y, _yClamp[0], _yClamp[1]);
            transform.position = new Vector3(xClamp, yClamp, transform.position.z);
        }

        // focus on the mod
        if (modON.activeSelf == true)
        {
            float xClamp = Mathf.Clamp(mod.position.x, _xClamp[0], _xClamp[1]);
            float yClamp = Mathf.Clamp(mod.position.y, _yClamp[0], _yClamp[1]);
            transform.position = new Vector3(xClamp, yClamp, transform.position.z);
        }
    }
}
