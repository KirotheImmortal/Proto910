using UnityEngine;
using System.Collections;

public class Enemy_Manager : MonoBehaviour
{

    bool dieing = false;
    public int hp;
    GameObject Player;
   public WeaponManager wm;

    public float attackThresh;
   
    // Use this for initialization
    void Awake()
    {
        Player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.GetComponent<Controlls>().died)
        {
            if (hp <= 0 && !dieing)
            {
                Vector3 randforce = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f));
                gameObject.GetComponent<Animation>().Play("die");
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                gameObject.GetComponent<Rigidbody>().AddForce(randforce);
                dieing = true;
            }

           else  if (gameObject.GetComponent<Animation>().IsPlaying("die") == false && dieing)
            {
                Destroy(gameObject);
                Player.GetComponent<Controlls>().kills++;
            }
            if (dieing == false && !gameObject.GetComponent<Animation>().IsPlaying("gethit") )
            {  Vector3 facing;
                    Vector3 ppos = Player.GetComponent<Transform>().position;
                    Vector3 cpos = gameObject.GetComponent<Transform>().position;
                    float dis = Mathf.Sqrt((ppos.x - cpos.x) * (ppos.x - cpos.x) + (ppos.y - cpos.x) * (ppos.y - cpos.y) + (ppos.z - cpos.z) * (ppos.z - cpos.z));
                    facing = ppos - cpos;
                if (!gameObject.GetComponent<Animation>().IsPlaying("attack"))
                {
                    wm.active = false;

                  

                    gameObject.GetComponent<Transform>().forward = facing;

                    gameObject.GetComponent<Transform>().position += facing / 100;

                    gameObject.GetComponent<Animation>().Play("run");

                } 
                if (dis < attackThresh && !gameObject.GetComponent<Animation>().IsPlaying("attack"))
                 {
                  gameObject.GetComponent<Animation>().Stop();
                  gameObject.GetComponent<Animation>().Play("attack");
                  wm.active = true;
                }
            }
        }


        else
        {
            if (gameObject.GetComponent<Animation>().IsPlaying("dance"))
                gameObject.GetComponent<Animation>().PlayQueued("dance");
            else
                gameObject.GetComponent<Animation>().Play("dance");
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
