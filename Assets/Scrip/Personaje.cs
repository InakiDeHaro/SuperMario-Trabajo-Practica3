using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    //respawn
    private Vector3 respawnPoint;

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
        isTouchground = Physics2D.OverlapCircle(Groundcheck.position, GroundcheckRadius, groundLayer);
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

 


        //jump
        if (Input.GetButtonDown("Jump") && isTouchground)
        {
            rg.velocity = new Vector2(rg.velocity.x, jumpspeed);
        }
        //animation "run"
        anima.SetFloat("spd", Mathf.Abs(direction));
        //animation "jump" & "fall"
        if (isTouchground)
        {
            anima.SetInteger("Falling", 0);
        }
        else
        {
            if (rg.velocity.y > 0.1f)
            {
                anima.SetInteger("Falling", 1);
            }
            else if (rg.velocity.y < -0.1f)
            {
                anima.SetInteger("Falling", -1);
            }
        }
        if (transform.position.y < -6.54)
        {
            SceneManager.LoadScene("17.55_17-01-2023_Practica_3");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("enemy kill"))
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("17.55_17-01-2023_Practica_3");
        }
    }
}
