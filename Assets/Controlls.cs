using UnityEngine;
using System.Collections;

public class Controlls : MonoBehaviour
{

    public float speed = 1.0f;
    public float rotatespeed = 1.0f;

    public WeaponManager wm;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Animation>().isPlaying == false)
        {
            wm.active = false;
            gameObject.GetComponent<Animation>().Play("idle");
        }
        else if(gameObject.GetComponent<Animation>().IsPlaying("dance"))
            gameObject.GetComponent<Animation>().PlayQueued("dance");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            wm.active = true;
            gameObject.GetComponent<Animation>().Play("attack");
        }

        else if (Input.GetKey(KeyCode.W) && !gameObject.GetComponent<Animation>().IsPlaying("attack"))
        {
            gameObject.GetComponent<Transform>().localPosition += gameObject.GetComponent<Transform>().forward * speed / 100;
            gameObject.GetComponent<Animation>().Play();
        }

        else if (Input.GetKey(KeyCode.S) && !gameObject.GetComponent<Animation>().IsPlaying("attack"))
        {
            gameObject.GetComponent<Transform>().localPosition -= gameObject.GetComponent<Transform>().forward * speed / 100;
            gameObject.GetComponent<Animation>().Play();
        }
        else if (Input.GetKey(KeyCode.A) && !gameObject.GetComponent<Animation>().IsPlaying("attack"))
        {
            gameObject.GetComponent<Transform>().localPosition -= gameObject.GetComponent<Transform>().right * speed / 100;
            gameObject.GetComponent<Animation>().Play();
        }
        else if (Input.GetKey(KeyCode.D) && !gameObject.GetComponent<Animation>().IsPlaying("attack"))
        {
            gameObject.GetComponent<Transform>().localPosition += gameObject.GetComponent<Transform>().right * speed / 100;
            gameObject.GetComponent<Animation>().Play();
        }
        else if (Input.GetKey(KeyCode.Q) && !gameObject.GetComponent<Animation>().IsPlaying("attack"))
            gameObject.GetComponent<Animation>().Play("dance");



        if (Input.GetKey(KeyCode.J))
        {
            gameObject.GetComponent<Transform>().forward -= gameObject.GetComponent<Transform>().right * rotatespeed / 100;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            gameObject.GetComponent<Transform>().forward += gameObject.GetComponent<Transform>().right * rotatespeed / 100;
        }


    }


}
