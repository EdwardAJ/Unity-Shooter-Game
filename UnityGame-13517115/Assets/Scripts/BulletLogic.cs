using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    private float bulletSpeed = 10f;
    public float delayTime = 0.5f;

    private void OnEnable() {
        // Hide after one second.
        if (transform.localScale.x < 0) {
            transform.GetComponent<Rigidbody2D>().AddForce(-1 * Vector2.right * bulletSpeed, ForceMode2D.Impulse);
        } else {
            transform.GetComponent<Rigidbody2D>().AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
        }
        Invoke("Hide", delayTime);
    }
    
    void Hide() {
        gameObject.SetActive(false);
    }

    private void OnDisable() {
        // Do not hide again
        CancelInvoke();
    }
}
