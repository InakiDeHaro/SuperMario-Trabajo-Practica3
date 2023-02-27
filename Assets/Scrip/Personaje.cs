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
    public GameObject FallDetector;

    // coins
    int coincounter;
    public static int cointake = 0;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
        coins();

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
            GameManager.instance.ChangeScene("Menu");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("enemy kill"))
        {
            Destroy(collision.transform.parent.gameObject);
            Audiomanager.instance.PlaySFX("pisoton");
            GameManager.instance.AddPunt(5);
        }
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            cointake++;

            if (cointake == coincounter)
            {
                Audiomanager.instance.PlaySFX("monedas all");
            }
            else
            {
                Audiomanager.instance.PlaySFX("Monedas");
            }
            GameManager.instance.AddPunt(10);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.ChangeScene("Menu");
        }
    }
<<<<<<< HEAD
    public void coins()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        coincounter = coins.Length;
=======


    void ChangeScene(string name)
    {
        SceneManager.LoadScene
>>>>>>> ec7a36166cf134090f6d11242cff8b7e2cc07210
    }
}


