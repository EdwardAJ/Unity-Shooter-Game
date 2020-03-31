using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooting : ShootingController
{
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
}