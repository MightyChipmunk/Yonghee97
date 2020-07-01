using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public float interval = 25.0f;
    public static bool status;
    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        status = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (status)
        {
            Invoke("Spawn", interval);
            status = false;
        }
    }

    void Spawn()
    {
        if (SpawnManager.isboss == false)
        {
            Instantiate(boss, new Vector3(0, 1.5f), Quaternion.identity);
            SpawnManager.isboss = true;
        }
    }

    
}
