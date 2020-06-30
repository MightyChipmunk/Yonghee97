using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    public GameObject obj;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == obj.tag)
        {
            Destroy(gameObject);
        }
    }
}
