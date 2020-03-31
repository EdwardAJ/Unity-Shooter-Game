using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShooting : ShootingController
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (PlayerPrefs.GetInt("Sound") == 1) {
                sound.Play();
            }
            Fire();
        }
    }
}