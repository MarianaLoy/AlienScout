using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public float jumpSpeed;
    public float fireRate = 0.25f;
    public bool isFacingRight = true;
    public int lives = 3;

    private float canFire = 0.0f;
    private float move;
    public bool isJumping;

    public GameObject laserPrefab;
    public GameObject leftLaserPrefab;
    private AudioSource laserAudioSource;

    public AudioClip runClip;
    public AudioClip jumpClip;
    public AudioClip groundClip;
    public AudioClip damageClip;
    public AudioClip appearClip;
    

    private Rigidbody2D rb;
    private Animator anim;

    //AudioSource.PlayClipAtPoint(nutCoinClip, Camera.main.transform.position, 1f);
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        laserAudioSource = GetComponent<AudioSource>();
        AudioSource.PlayClipAtPoint(appearClip, Camera.main.transform.position, 1f);

    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * playerSpeed, rb.velocity.y);

        //Changing directions
        if(move < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            //Facing left
            isFacingRight = false;
           // AudioSource.PlayClipAtPoint(runClip, Camera.main.transform.position, 1f);


        }
        else if(move > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            isFacingRight = true;
           // AudioSource.PlayClipAtPoint(runClip, Camera.main.transform.position, 1f);

        }

        //Jump
        if((Input.GetKeyDown(KeyCode.UpArrow) && !isJumping || (Input.GetKeyDown(KeyCode.W) && !isJumping)))
        {
            AudioSource.PlayClipAtPoint(jumpClip, Camera.main.transform.position, 1f);
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed));
            isJumping = true;
        }

        //Spawn laser
        //Jump = FIRE
       if(Input.GetButtonDown("Jump"))
        {
            Shoot();
            
        }


        RunAnimations();
    }



    private void Shoot()
    {
        if (Time.time > canFire)
        {
            laserAudioSource.Play();

            if(isFacingRight)
            {
                Instantiate(laserPrefab, transform.position + new Vector3(1f, -0.25f, 0), Quaternion.identity);
            }
            if(!isFacingRight)
            {
                Instantiate(leftLaserPrefab, transform.position + new Vector3(-1f, -0.25f, 0), Quaternion.identity);
            }
            
            canFire = Time.time + fireRate;
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }

    public void Damage()
    {
        lives--;
        AudioSource.PlayClipAtPoint(damageClip, Camera.main.transform.position, 1f);

        if (lives < 0)
        {
            lives = 0;
            Destroy(this.gameObject);
            Debug.Log("GAME OVER");
            //AudioSource.PlayClipAtPoint(dieClip, Camera.main.transform.position, 1f);
            //Dead animation 
            SceneManager.LoadScene(2);
        }
    }

    void RunAnimations()
    {
        anim.SetFloat("Movement", Mathf.Abs(move));
        anim.SetBool("isJumping", isJumping);
    }
}
