using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    private Transform playerTransform;

    public float power;

    public float FireDelay = 0.0f;
    private bool FireState;

    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        FireState = true;
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {    
        if (playerTransform.position.x > gameObject.transform.position.x) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.right * power);
        }
        else if (playerTransform.position.x < gameObject.transform.position.x)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.left * power);
        }
        fire();
    }

    void fire()
    {
        if (FireState)
        {
            StartCoroutine(FireCycle());
            Instantiate(Bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f, 0), Quaternion.identity);
        }
    }
    IEnumerator FireCycle()
    {
        FireState = false;
        yield return new WaitForSeconds(FireDelay);
        FireState = true;
    }
}


