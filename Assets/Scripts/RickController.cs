using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RickController : MonoBehaviour {

    public float JumpForce = 2f;
    public AudioClip jumpSound;

    private AudioSource source;
    private bool groundCheck;
    private Animator anim;
    private float jumpStartTime = 0f;
    private Rigidbody2D rb;
    private bool js = true;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButton("Jump") && groundCheck == true || Input.touches.Length > 0)
        {
            if (js == true)
            {
                source.PlayOneShot(jumpSound, 1.0f);
                js = false;
            }
            anim.SetBool("Jumping", true);
            jumpStartTime += Time.fixedDeltaTime;
            DoJump();
        }

    }

    void DoJump()
    {
        if (jumpStartTime <= 0.15f)
            rb.AddForce(Vector2.up * JumpForce);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        anim.SetBool("Jumping", false);
        jumpStartTime = 0f;
        groundCheck = true;
        js = true;
    }
}
