using UnityEngine;
using System.Collections;

public class Controlls : MonoBehaviour
{

    public float speed = 1.0f;
    public float rotatespeed = 1.0f;

    public float hp;
    public float maxHP;
    public int kills = 0;

    bool dead = false;
   public bool died;


    public WeaponManager wm;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
            dead = true;

        if (dead && !died && !gameObject.GetComponent<Animation>().IsPlaying("die"))
        {
            died = true;
            GameObject.Find("GUIManager").GetComponent<GuiManager>().killText();
            gameObject.GetComponent<Animation>().Play("die");
        }

        else if (!dead)
        {
            if (gameObject.GetComponent<Animation>().isPlaying == false)
            {
                wm.active = false;
                gameObject.GetComponent<Animation>().Play("idle");
            }
            else if (gameObject.GetComponent<Animation>().IsPlaying("dance"))
                gameObject.GetComponent<Animation>().PlayQueued("dance");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                wm.active = true;
                gameObject.GetComponent<Animation>().Play("attack");
            }

            else if (Input.GetKey(KeyCode.W))
            {
                gameObject.GetComponent<Transform>().localPosition += gameObject.GetComponent<Transform>().forward * speed / 100;
                if (!gameObject.GetComponent<Animation>().IsPlaying("attack"))
                    gameObject.GetComponent<Animation>().Play("run");
            }

            else if (Input.GetKey(KeyCode.S))
            {
                gameObject.GetComponent<Transform>().localPosition -= gameObject.GetComponent<Transform>().forward * speed / 100;
                if (!gameObject.GetComponent<Animation>().IsPlaying("attack"))
                    gameObject.GetComponent<Animation>().Play("run");
            }
            else if (Input.GetKey(KeyCode.A))
            {
                gameObject.GetComponent<Transform>().localPosition -= gameObject.GetComponent<Transform>().right * speed / 100;
                if (!gameObject.GetComponent<Animation>().IsPlaying("attack"))
                    gameObject.GetComponent<Animation>().Play("run");
            }
            else if (Input.GetKey(KeyCode.D))
            {
                gameObject.GetComponent<Transform>().localPosition += gameObject.GetComponent<Transform>().right * speed / 100;
                if (!gameObject.GetComponent<Animation>().IsPlaying("attack"))
                    gameObject.GetComponent<Animation>().Play("run");
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
            GameObject.Find("GUIManager").GetComponent<GuiManager>().kill(kills);
            GameObject.Find("GUIManager").GetComponent<GuiManager>().hp(maxHP, hp);

    }

    void OnCollisionEnter(Collision o)
    {
        if (o.gameObject.GetComponent<Enemy_Manager>() && !died)
            hp--;
    }






}
