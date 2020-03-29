using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private GameObject mainCharacter;
    [SerializeField] private GameObject zombie;

    // Using Object Pooling
    private List<GameObject> zombieList;
    private int numberOfZombies = 6;

    // Start is called before the first frame update
    void Start()
    {
        zombieList = new List<GameObject>();
        for (int i = 0; i < numberOfZombies; i++) {
            GameObject zombieObject = (GameObject) Instantiate(zombie);
            // Deactivate all of the bullets in object pool
            zombieObject.SetActive(false);
            zombieList.Add(zombieObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsAllZombieActive()) {
            Invoke("SpawnZombie", 4f);
        }
    }

    private void SpawnZombie() {
        for (int i = 0; i < zombieList.Count; i++) {
            if (!zombieList[i].activeInHierarchy) {
                float offset = Random.Range(1f, 5f);
                zombieList[i].transform.position = new Vector2(mainCharacter.transform.position.x + offset, -1.6f);
                zombieList[i].transform.rotation = zombie.transform.rotation;
                zombieList[i].SetActive(true);
                // Only triggered once!
                break;
            }
        }
    }

    private bool IsAllZombieActive() {
        for (int i = 0; i < zombieList.Count; i++) {
            if (!zombieList[i].activeInHierarchy) {
                return false;
            }
        }
        return true;
    }

    public void DeleteZombie() {
        CancelInvoke();
        for (int i = 0; i < zombieList.Count; i++) {
            zombieList[i].SetActive(false);
            Destroy(zombieList[i]);
        }
        Destroy(this);
    }
}
