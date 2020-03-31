using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private AudioSource sound;

    // Using Object Pooling
    private List<GameObject> bulletList;
    private float bulletSpeed = 100f;
    private int numberOfBullets = 3;

    // Start is called before the first frame update
    void Start()
    {
        bulletList = new List<GameObject>();
        for (int i = 0; i < numberOfBullets; i++) {
            GameObject bulletObject = (GameObject) Instantiate(bullet);
            // Deactivate all of the bullets in object pool
            bulletObject.SetActive(false);
            bulletList.Add(bulletObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (PlayerPrefs.GetInt("Sound") == 1) {
                sound.Play();
            }
            Fire();
        }
    }

    void Fire() {
        for (int i = 0; i < bulletList.Count; i++) {
            if (!bulletList[i].activeInHierarchy) {
                bulletList[i].transform.position = spawnPoint.position;
                bulletList[i].transform.rotation = spawnPoint.rotation;

                if (transform.localScale.x < 0) {
                    bulletList[i].transform.localScale = new Vector2(-1 * bullet.transform.localScale.x, bullet.transform.localScale.y);
                } else {
                    bulletList[i].transform.localScale = bullet.transform.localScale;
                }
                bulletList[i].SetActive(true);
                // Only triggered once!
                break;
            }
        }
    }
}
