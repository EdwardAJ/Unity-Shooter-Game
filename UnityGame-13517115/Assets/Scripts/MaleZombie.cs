using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleZombie : Zombie
{
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag.Equals("Bullet")) {
            energy -= 15;
            if (energy <= 0) {
                scoreCanvas.GetComponent<ScoreController>().scoreInt += 1;
                CancelInvoke();
                DisableZombie();
            }
        }
    }
}
