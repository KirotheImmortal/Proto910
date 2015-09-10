using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour
{

    public bool active = false;
    public int dmg;


    void OnCollisionEnter(Collision o)
    {
        if (active)
            o.gameObject.GetComponent<Enemy_Manager>().getHit(dmg);
    }


}
