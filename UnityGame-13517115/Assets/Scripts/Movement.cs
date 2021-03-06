﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject scoreCanvas;

    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    private BoxCollider2D boxCollider;
    private Vector3 characterInitialPosition;
    private Vector3 maxRightPosition;

    private float realBackgroundWidth;
    private float initialScaleX;
    private int characterEnergy = 100;

    public int score = 0;
    public float moveSpeed = 6f;
    public float jumpSpeed = 100f;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        // Get background width to limit character movement
        RectTransform backgroundRect = GameObject.FindGameObjectWithTag("Background").GetComponent<RectTransform>();
        Transform backgroundTransform = GameObject.FindGameObjectWithTag("Background").transform;
        float backgroundWidth = backgroundRect.rect.width;
        float backgroundScaleX = backgroundTransform.localScale.x;
        float realBackgroundWidth = backgroundScaleX * backgroundWidth;

        characterInitialPosition.x = transform.position.x - 0.2f;
        maxRightPosition.x = backgroundTransform.position.x + realBackgroundWidth + characterInitialPosition.x - 5f;

        initialScaleX = transform.localScale.x;

        scoreCanvas.GetComponent<ScoreController>().energyInt = characterEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        SetMovement();
        FlipCharacter();
        SetJump();
        SetShootAnimation();
    }

    private void SetMovement() {
        if (transform.position.x >= characterInitialPosition.x && transform.position.x <= maxRightPosition.x) {
            movement = new Vector2(Input.GetAxis("Horizontal"), rb.velocity.y);
        } else {
            if (transform.position.x < characterInitialPosition.x) {
                movement = new Vector2(1f, rb.velocity.y);
            } else if (transform.position.x > maxRightPosition.x) {
                movement = new Vector2(-1 * 1f, rb.velocity.y);
            }
        }
        rb.velocity = movement * moveSpeed;
        anim.SetFloat("Speed", Input.GetAxis("Horizontal"));
    }

    private void FlipCharacter() {
        if (Input.GetAxis("Horizontal") < 0) {
            transform.localScale = new Vector2(-1 * initialScaleX, transform.localScale.y);
        } else {
            transform.localScale = new Vector2(initialScaleX, transform.localScale.y);
        }
    }


    private void SetJump() {
         if (IsGrounded()) {
            anim.SetBool("isJumpActive", false);
        }

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded()) {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            anim.Play("Jump", 0, 0.25f);
            anim.SetBool("isJumpActive", true);
        }
    }

    private void SetShootAnimation() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            anim.Play("Shoot", 0, 0.25f);
            anim.SetBool("isShootActive", true);
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            anim.SetBool("isShootActive", false);
        }
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + 0.1f, layerMask);
        return raycastHit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag.Equals("Zombie")) {
            characterEnergy -= 10;
            scoreCanvas.GetComponent<ScoreController>().energyInt = characterEnergy;
            if (transform.position.x - 1f >= characterInitialPosition.x) {
                transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
            } else {
                transform.position = new Vector3(transform.position.x + 4f, transform.position.y, transform.position.z);
            }
            if (characterEnergy <= 0) {
                scoreCanvas.GetComponent<ScoreController>().DisplayInputField();
                GameObject.FindGameObjectWithTag("Background").GetComponent<ZombieMovement>().DeleteZombie();
                Destroy(gameObject);
            }
        }
    }
}