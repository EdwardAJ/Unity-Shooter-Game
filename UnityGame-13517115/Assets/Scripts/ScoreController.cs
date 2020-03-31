using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

public class ScoreController : MonoBehaviour
{
    public Camera camera;
    public Text scoreText;
    public Text energyText;

    public GameObject inputField;
    public int scoreInt;
    public int energyInt;

    // Start is called before the first frame update
    void Start()
    {
        scoreInt = 0;
        scoreText.text = "Score: " + scoreInt.ToString();
        energyText.text = "Energy: " + energyInt.ToString();
        inputField.SetActive(false);
    }

    void LateUpdate()
    {
        energyText.text = "Energy: " + energyInt.ToString();
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
                SceneManager.LoadScene("MainMenu");
            }
        });
    }
}
