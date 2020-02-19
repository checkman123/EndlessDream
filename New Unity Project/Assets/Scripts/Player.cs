using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed; //Speed of player
    public float health;

    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private Animator anim;


    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() {

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveAmount = moveInput.normalized * speed; //normalized is for same speed in moving Diagonal

        //Transition movement animation to run/idle
        if(moveInput != Vector2.zero) {
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }

    }
    //Physic related
    private void FixedUpdate() {

        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime); //Time is to have same speed in every PC

    }

    public void takeDamage(int damageAmount) {
        health -= damageAmount;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
