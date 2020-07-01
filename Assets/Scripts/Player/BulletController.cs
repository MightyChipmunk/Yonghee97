using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Transform tr;
        
    public float moveSpeed = 0.0f;
    public float DestroyPos = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector2.up * moveSpeed * Time.deltaTime);

        if(tr.position.y > DestroyPos)
        {
            Destroy(gameObject);
        }
    }
}
