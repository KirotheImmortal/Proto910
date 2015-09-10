using UnityEngine;
using System.Collections;

public class Controlls : MonoBehaviour
{

    public float speed = 1.0f;
    public float rotatespeed = 1.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
            gameObject.GetComponent<Transform>().localPosition += gameObject.GetComponent<Transform>().forward * speed / 100;
        else if (Input.GetKey(KeyCode.S))
            gameObject.GetComponent<Transform>().localPosition -= gameObject.GetComponent<Transform>().forward * speed / 100;
        else if (Input.GetKey(KeyCode.A))
            gameObject.GetComponent<Transform>().localPosition += new Vector3(0, 0, 0);
        else if (Input.GetKey(KeyCode.D))
            gameObject.GetComponent<Transform>().localPosition -= new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.J))
            gameObject.GetComponent<Transform>().forward += new Vector3(-rotatespeed, 0, 0) / 90;
        else if (Input.GetKey(KeyCode.L))
            gameObject.GetComponent<Transform>().forward -= new Vector3(-rotatespeed, 0, 0) / 90;
    }


}
