using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECollide : MonoBehaviour
{
    private Transform tr;

    public GameObject obj;
    public GameObject effect;
    public int score;

    void Start()
    {
        tr = GetComponent<Transform>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == obj.tag)
        {
            GameObject tmp = Instantiate(effect, tr.position, Quaternion.identity);
            Destroy(gameObject);
            ScoreManager.score += score;
            Destroy(tmp, 1.0f);
        }
    }
}
