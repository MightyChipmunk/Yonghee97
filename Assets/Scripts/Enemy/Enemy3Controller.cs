using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Controller : MonoBehaviour
{
    private bool status;
    public float power;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveCycle());
    }

    // Update is called once per frame
    void Update()
    {
        if (status)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.right * power);
        }
        if (status == false)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.left * power);
        }
    }

    IEnumerator MoveCycle()
    {
        while (true)
        {
            status = true;
            yield return new WaitForSeconds(delay);
            status = false;
            yield return new WaitForSeconds(delay);
        }
    }
}
