using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    Rigidbody2D rg;

    BoxCollider2D hitbox;

    public int Speed;

    public float Movex;

    CapsuleCollider2D capsule2d;

    LayerMask groundLayer;

    SpriteRenderer spriter;


    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        capsule2d = GetComponent<CapsuleCollider2D>();
        groundLayer = LayerMask.GetMask("Ground");
        Movex = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Sprite da la vuelta
        transform.localScale = new Vector2(Movex, transform.localScale.y);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(Movex, 0), capsule2d.size.x / 2 + 0.5f, groundLayer.value);
        //movimiento
        rg.velocity = new Vector2(Movex, 0) * Speed;

        if(hit.collider != null)
        {
            Movex *= -1;
        }
    }
}
