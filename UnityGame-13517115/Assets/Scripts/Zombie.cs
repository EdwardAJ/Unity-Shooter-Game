using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] public GameObject mainCharacter;
    [SerializeField] public GameObject scoreCanvas;
    public int energy = 30;
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
        float delayTime = Random.Range(6f, 8f);
        if (scoreCanvas.GetComponent<ScoreController>().scoreInt >= 25) {
            delayTime = Random.Range(3.5f, 6f);
        }
        if (scoreCanvas.GetComponent<ScoreController>().scoreInt >= 50) {
            delayTime = Random.Range(0.1f, 0.5f);
        }
        Invoke("ReviveZombie", delayTime);
        Invoke("DisableZombie", 12.5f);
    }

    void ReviveZombie() {
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

    public void DisableZombie() {
        isEnabled = false;
        gameObject.SetActive(false);
    }

    private void SetZombieMovement() {
        if (transform.position.y < -10) {
            CancelInvoke();
            DisableZombie();
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

    // private void OnCollisionEnter2D(Collision2D col) {
    //     if (col.gameObject.tag.Equals("Bullet")) {
    //         energy -= 10;
    //         if (energy <= 0) {
    //             scoreCanvas.GetComponent<ScoreController>().scoreInt += 1;
    //             CancelInvoke();
    //             DisableZombie();
    //         }
    //     }
    // }
}
