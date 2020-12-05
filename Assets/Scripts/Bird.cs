using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    private bool isDead = false;
    private Rigidbody2D rigidbody2D;

    public float upForce = 200f;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if  (!isDead && !GameControl.instance.gamePaused) {
            if (Input.GetMouseButtonDown(0)) {
                SoundManagerScript.PlaySound("flap");
                rigidbody2D.velocity = Vector2.zero;
                rigidbody2D.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        isDead = true;
        anim.SetTrigger("Die");
        rigidbody2D.velocity = Vector2.zero;
        GameControl.instance.BirdDied();
        SoundManagerScript.PlaySound("lose");
    }
}
