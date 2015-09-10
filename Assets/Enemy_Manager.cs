using UnityEngine;
using System.Collections;

public class Enemy_Manager : MonoBehaviour
{

    bool dieing = false;
    public int hp;
    GameObject Player;
   
    // Use this for initialization
    void Awake()
    {
        Player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0 && !dieing)
        {
            gameObject.GetComponent<Animation>().Play("die");
            dieing = true;
        }

        if (gameObject.GetComponent<Animation>().IsPlaying("die") == false && dieing)
            Destroy(gameObject);

        if (dieing == false && !gameObject.GetComponent<Animation>().IsPlaying("gethit"))
        {
            Vector3 facing;
            Vector3 ppos = Player.GetComponent<Transform>().position;
            Vector3 cpos = gameObject.GetComponent<Transform>().position;
            facing = ppos - cpos;

            gameObject.GetComponent<Transform>().forward = facing;

            gameObject.GetComponent<Transform>().position += facing / 100;
            
            gameObject.GetComponent<Animation>().Play("run");
        }
    }

    public void getHit(int dmg)
    {
        gameObject.GetComponent<Animation>().Play("gethit");
        hp -= dmg;
    }


    //void OnCollisionEnter()
    //{
    //    gameObject.GetComponent<Animation>().Play("die");
    //    print("triggerhit");
    //}

}
