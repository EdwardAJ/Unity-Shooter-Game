using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private GameObject mainCharacter;
    [SerializeField] private GameObject maleZombie;
    [SerializeField] private GameObject femaleZombie;
    // private GameObject zombie;

    // Using Object Pooling
    private List<GameObject> zombieList;
    private int numberOfZombies = 10;

    // Start is called before the first frame update
    void Start()
    {
        // zombie = GameObject.FindGameObjectWithTag("Zombie");
        zombieList = new List<GameObject>();
        for (int i = 0; i < numberOfZombies; i++) {
            GameObject zombieObject = null;
            if (i % 2 == 0) {
                zombieObject = (GameObject) Instantiate(femaleZombie);
            } else {
                zombieObject = (GameObject) Instantiate(maleZombie);
            }
            zombieObject.SetActive(false);
            zombieList.Add(zombieObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpawnZombie();
    }

    private void SpawnZombie() {
        for (int i = 0; i < zombieList.Count; i++) {
            if (!zombieList[i].activeInHierarchy) {
                float offset = Random.Range(0.3f, 7f);
                zombieList[i].transform.position = new Vector3(mainCharacter.transform.position.x + offset, 1.6f, -0.1f);
                // zombieList[i].transform.rotation = zombie.transform.rotation;
                zombieList[i].SetActive(true);
                // Only triggered once!
            }
        }
    }

    public void DeleteZombie() {
        // CancelInvoke();
        for (int i = 0; i < zombieList.Count; i++) {
            zombieList[i].SetActive(false);
            Destroy(zombieList[i]);
        }
        Destroy(this);
    }
}
