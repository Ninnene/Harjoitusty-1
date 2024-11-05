using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlauerControllerTheOther : MonoBehaviour
{
    // tässä luetellaan koodille tarpeellisia muuttujia myöhempää käyttöa varten
    private  Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool gameOver = false;
    public bool isOnGround = true;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioSource playerAudio; // tämä minun piti avata publiciksi ja liittää inspectorissa jotta se toimi ja musiikit soi

    // Start is called before the first frame update
    void Start()
    {
        // tässä aktivoidaan pelin suorittamista varten tarvittavia komponentteja
        //playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //tässä updatemetodissa peli tarkkailee painaako pelaaja välilyöntiä ja suorittaa asioita kun pelaaja painaa
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && ! gameOver)
        {
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Huomaan collisionin");
    // tämä metodi tarkkailee törmäyksiä colliderien avulla ja suorittaa asioita kun törmäys tapahtuu
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("cOllision Ground:n kanssa");
            dirtParticle.Play();
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //Debug.Log("Collision Obstaclen kanssa");
            playerAudio.PlayOneShot(crashSound, 1.0f);
            dirtParticle.Stop();
            explosionParticle.Play();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            gameOver = true;
            Debug.Log("Game Over!");
        }
        
    }
}
