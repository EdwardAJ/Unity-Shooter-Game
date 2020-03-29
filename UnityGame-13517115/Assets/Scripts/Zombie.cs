using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private GameObject mainCharacter;
    [SerializeField] private GameObject scoreCanvas;
    private int energy = 30;
    private Rigidbody2D zombieRB;
    private Vector2 zombieMovement;
    private bool isEnabled;
    private float moveSpeed = 1f;
    // // Start is called before the first frame update
    void Start()
    {
        zombieRB = GetComponent<Rigidbody2D>();
    }

    void OnEnable() {
        isEnabled = true;
        energy = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled) {
            SetZombieMovement();
        }
    }

    private void SetZombieMovement() {
        if (transform.position.y < -10) {
            isEnabled = false;
            gameObject.SetActive(false);
        } else {
            if (mainCharacter != null) {
                if (transform.position.x >= mainCharacter.transform.position.x) {
                    zombieMovement = new Vector2(-1f, zombieRB.velocity.y);
                } else {
                    zombieMovement = new Vector2(1f, zombieRB.velocity.y);
                }
                zombieRB.velocity = zombieMovement * moveSpeed;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag.Equals("Bullet")) {
            energy -= 10;
            if (energy <= 0) {
                scoreCanvas.GetComponent<TextFollow>().scoreInt += 1;
                isEnabled = false;
                gameObject.SetActive(false);
            }
        }
    }
}
