using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform tr;
    private SpriteRenderer spriteRenderer;

    public Sprite CurrentSprite;
    public Sprite NextSprite;
    public float moveSpeed;
    public float repeat;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = CurrentSprite;
        InvokeRepeating("sym", repeat, repeat);
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        if(tr.position.y <= -5.5)
        {
            Destroy(gameObject);
        }
    }

    void sym()
    {
        if(spriteRenderer.sprite == CurrentSprite)
        {
            spriteRenderer.sprite = NextSprite;
        }
        else
        {
            spriteRenderer.sprite = CurrentSprite;
        }
    }
}
