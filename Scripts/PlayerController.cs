using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    static int score = 0;
    static int lives = 3;
    public Text scoreText;
    public Text livesText;
    public LayerMask ground;
    Rigidbody2D rb;
    Vector2 force;
    Animator anim;
    bool facingRight = true;
    AudioSource audio;
    public AudioClip jump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        force = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            force.x = -10;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            force.x = 10;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 feet = new Vector2(transform.position.x, transform.position.y - 0.5f);
            Vector2 dimensions = new Vector2(1.0f, 0.2f);
            bool grounded = Physics2D.OverlapBox(feet, dimensions, 0, ground);
            
            if (grounded)
            {
                force.y = 275;
                audio.clip = jump;
                audio.Play();
            }

        }

        if(force.x < 0)
        {
            anim.SetBool("isWalking", true);

            if (facingRight) Flip();
        }else if(force.x > 0)
        {
            anim.SetBool("isWalking", true);

            if (facingRight == false) Flip();
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

    }

    private void FixedUpdate()
    {
        rb.AddForce(force);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -5, 5), rb.velocity.y);
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingRight = !facingRight;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Pit")
        {
            lives -= 1;
            if(lives > 0)
            {
                Scene scene = SceneManager.GetActiveScene();
                if (scene.name == "Level 1")
                {
                    SceneManager.LoadScene("Level 1");
                }
                else if (scene.name == "Level 2")
                {
                    SceneManager.LoadScene("Level 2");
                }
                else if (scene.name == "Level 3")
                {
                    SceneManager.LoadScene("Level 3");
                }
            }
            else
            {
                SceneManager.LoadScene("You Lose");
            }
            
        }
        else if (collision.gameObject.tag == "Coin")
        {
            score += 1;
            scoreText.text = "Score: " + score.ToString();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Respawn")
        {
            lives += 1;
            livesText.text = "Remaining Lives: " + lives.ToString();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            Scene scene = SceneManager.GetActiveScene();
            Debug.Log(scene.name);
            if (scene.name == "Level 1")
            {
                SceneManager.LoadScene("Level 2");
            }else if (scene.name == "Level 2")
            {
                SceneManager.LoadScene("Level 3");
            }else if (scene.name == "Level 3")
            {
                SceneManager.LoadScene("You Win");
            }

        }
    }
}
