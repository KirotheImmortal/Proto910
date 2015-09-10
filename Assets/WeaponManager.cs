using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour
{

    public bool active = false;
    public bool enemy = false;
    public int dmg;


    void OnTriggerEnter(Collider o)
    {
        if (active && o.gameObject.GetComponent<Enemy_Manager>() && !enemy)
            o.gameObject.GetComponent<Enemy_Manager>().getHit(dmg);
        else if (active && o.gameObject.GetComponent<Controlls>())
            o.gameObject.GetComponent<Controlls>().hp--;
    }


}
