using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float interval = 3.0f;

    public GameObject Enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", interval, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        if (SpawnManager.isboss == false)
        {
            float Xpos = Random.Range(-6.5f, 6.5f);
            Instantiate(Enemy, new Vector3(Xpos, 6.0f), Quaternion.identity);
        }
    }
}
