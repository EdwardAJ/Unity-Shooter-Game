using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFollow : MonoBehaviour
{
    public Camera camera;
    public Text scoreText;
    public int scoreInt;

    // Start is called before the first frame update
    void Start()
    {
        scoreInt = 0;
        scoreText.text = "Score: " + scoreInt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreInt.ToString();
        transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y,  -0.1f);
    }
}