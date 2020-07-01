using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollide : MonoBehaviour
{
    private Transform tr;

    public GameObject obj;
    public GameObject effect;
    public int score;
    public int hp;

    void Start()
    {
        tr = GetComponent<Transform>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == obj.tag)
        {
            hp--;
        }
    }

    private void Update()
    {
        if (hp == 0)
        {
            for (int i = 0; i < 5; i++) 
            { 
                Effect(tr);
            }
            Destroy(gameObject);
            SpawnManager.isboss = false;
            BossSpawn.status = true;
            ScoreManager.score += score;
            
        }
    }

    void Effect(Transform transform)
    {
        GameObject tmp = Instantiate(effect, new Vector2(transform.position.x + Random.Range(0.0f, 2.0f), transform.position.y + Random.Range(0.0f, 2.0f)), Quaternion.identity);
        Destroy(tmp, 3.0f);
    }
}
