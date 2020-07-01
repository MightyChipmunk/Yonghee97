using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform tr;
    private SpriteRenderer spriteRenderer;
    
    public float XmoveableRange = 0.0f;
    public float YmoveableRange = 0.0f;
    public float moveSpeed = 0.0f;

    public GameObject Bullet;
    public Transform SpawnPoint;
    
    public float FireDelay = 0.0f;
    private bool FireState;

    public Sprite CurrentSprite;
    public Sprite NextSprite;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        FireState = true;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = CurrentSprite;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        fire();
    }

    void move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tr.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            tr.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tr.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tr.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.sprite = NextSprite;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.sprite = CurrentSprite;
        }

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -XmoveableRange, XmoveableRange), transform.position.y);
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -YmoveableRange, YmoveableRange));
    }

    void fire()
    {
        if (FireState)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                StartCoroutine(FireCycle());
                Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
            }
        }
    }

    IEnumerator FireCycle()
    {
        FireState = false;
        yield return new WaitForSeconds(FireDelay);
        FireState = true;
    }
}
