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

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        direction = Input.GetAxis("Horizontal");
        if (direction > 0f)
        {
            rg.velocity = new Vector2(direction * speed, rg.velocity.y);
        }
        else if (direction < 0f)
        {
            rg.velocity = new Vector2(direction * speed, rg.velocity.y);
        }
        else
        {
            rg.velocity = new Vector2(0, rg.velocity.y);
        }
        //jump
        if (Input.GetButtonDown("Jump"))
        {
            rg.velocity = new Vector2(rg.velocity.x, jumpspeed);
        }
    }
}
