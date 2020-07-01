using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Transform tr;
    public float moveSpeed;

    private bool rightmove;
    private bool status;
    private bool atstat;
    private bool atstop;

    public float power;
    public float attackpower;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        rightmove = true;
        atstop = false;
        StartCoroutine(MoveCycle());
        StartCoroutine(AttackCycle());
    }

    // Update is called once per frame
    void Update()
    {
        if (!atstat)
        {
            HorizonMove();
            VerticalMove();
        }
        else if (atstat)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Attack();
        }
    }

    void HorizonMove()
    {
        if (rightmove)
        {
            tr.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (tr.position.x >= 6.0f)
            {
                rightmove = false;
            }
        }
        else
        {
            tr.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (tr.position.x <= -6.0f)
            {
                rightmove = true;
            }
        }
    }

    void VerticalMove()
    {
        if (status)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * power);
        }
        if (status == false)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.down * power);
        }
    }

    void Attack()
    {
        Invoke("DownMove", 0.5f);
        Invoke("Upmove", 1.5f);
        Invoke("ChangeStop", 3.5f);
        tr.position = new Vector2(tr.position.x, Mathf.Clamp(tr.position.y, -3.0f, 1.5f));
    }

    void DownMove()
    {
        if (tr.position.y > -3.0f && !atstop)
        {
            tr.Translate(Vector2.down * attackpower * Time.deltaTime);
        }
        else
        {

            atstop = true;
        }
    }

    void Upmove()
    {
        if (tr.position.y <= 1.5f)
        {
            tr.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
    }
    void ChangeStop()
    {
        atstop = false;
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
    IEnumerator AttackCycle()
    {
        while (true)
        {
            atstat = false;
            yield return new WaitForSeconds(3.0f);
            atstat = true;
            yield return new WaitForSeconds(3.0f);
        }
    }
}
