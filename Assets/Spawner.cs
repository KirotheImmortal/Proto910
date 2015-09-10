using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public GameObject enemy_prefab;
    public GameObject player_prefab;

    float time;
    public float timer;

    // Update is called once per frame
    void Update()
    {
        if (time > timer)
        {
            Instantiate(enemy_prefab, gameObject.GetComponent<Transform>().position, new Quaternion(0,0,0,0));
            time = 0.0f;
        }
        time += Time.deltaTime;

    }
}
