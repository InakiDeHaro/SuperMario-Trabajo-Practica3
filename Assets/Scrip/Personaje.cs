using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
   
    public float jumpspeed = 8f;
    public float speed = 5f;
    private float direction = 0f;
    private Rigidbody2D rg;
    private BoxCollider2D hitbox;
    SpriteRenderer spriter;
    Animator anima;

    //salto check
    public Transform Groundcheck;
    public float GroundcheckRadius;
    public LayerMask groundLayer;
    private bool isTouchground;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchground = Physics2D.OverlapCircle(Groundcheck.position,GroundcheckRadius,groundLayer);
        //movement
        direction = Input.GetAxis("Horizontal");
        if (direction > 0f)
        {
            rg.velocity = new Vector2(direction * speed, rg.velocity.y);
            spriter.flipX = false;
        }
        else if (direction < 0f)
        {
            rg.velocity = new Vector2(direction * speed, rg.velocity.y);
            spriter.flipX = true;
        }
        else
        {
            rg.velocity = new Vector2(0, rg.velocity.y);
        }
        //direction

        //jump
        if (Input.GetButtonDown("Jump") && isTouchground)
        {
            rg.velocity = new Vector2(rg.velocity.x, jumpspeed);
        }
        //animation "run"
        anima.SetFloat("spd", Mathf.Abs(direction));
        //animation "jump"

        //animation "fall"
    }
}
