using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RickDeath : MonoBehaviour {

    public AudioClip deathSound;

    private Animator anim;
    private AudioSource source;
    private bool canDie = true;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            if (canDie == true)
            {
                Destroy(collision.gameObject);
                source.PlayOneShot(deathSound, 1.0f);
                StartCoroutine(AnimDeath());
                canDie = false;
            }
        }
    }

    IEnumerator AnimDeath()
    {
        anim.SetTrigger("Dead");
        StartCoroutine(Invencible());
        yield return new WaitForSeconds(2.0f);
        gSceneManager.Instance.life--;
        anim.SetTrigger("Revive");
        if (gSceneManager.Instance.life <= 0)
        {
            gSceneManager.Instance.proxScene = gSceneManager.Instance.gameoverScene;
        }

    }

    IEnumerator Invencible()
    {
        yield return new WaitForSeconds(4.0f);
        canDie = true;
    }
}
