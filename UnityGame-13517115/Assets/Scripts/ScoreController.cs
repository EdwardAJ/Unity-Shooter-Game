﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

public class ScoreController : MonoBehaviour
{
    public Camera camera;
    public Text scoreText;

    public GameObject inputField;
    public int scoreInt;

    // Start is called before the first frame update
    void Start()
    {
        scoreInt = 0;
        scoreText.text = "Score: " + scoreInt.ToString();
        inputField.SetActive(false);
    }

    void LateUpdate()
    {
        scoreText.text = "Score: " + scoreInt.ToString();
        transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y,  -0.1f);
    }
   
    public void DisplayInputField() {
        inputField.SetActive(true);
    }

    public void StoreUserStats(Text username) {
        Debug.Log("USERNAME: " + username.text);
        UserStats userStats = new UserStats(username.text, scoreInt);
        RestClient.Post("http://134.209.97.218:5051/scoreboards/13517115", userStats).Then(response => {
            Debug.Log("Response: " + response.Text);
            if (response.Text.Equals("OK")) {
                Debug.Log("Luar biasa");
            }
        });
    }
}

class UserStats {
    public string username;
    public int score;

    public UserStats(string _username, int _score) {
        username = _username;
        score = _score;
    }
}