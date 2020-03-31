using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

public class ScoreboardController : MonoBehaviour
{
    // Child element
    [SerializeField] private GameObject userStatsLayout;
    // Parent element
    [SerializeField] private GameObject scoreboardContainer;
    // Back Button
    [SerializeField] private Button backButton;

    private int maxNumOfUserStats = 5;
    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(BackButtonOnClick);
        GetDataFromBackend();
    }

    private void GetDataFromBackend() {
        RestClient.GetArray<ScoreboardResponse>("http://134.209.97.218:5051/scoreboards/13517115").Then(arrayResponse => {
            int listLength = Math.Min(maxNumOfUserStats, arrayResponse.Length);
            for (int i = 0; i < listLength; i++) {
                GameObject childObject = (GameObject) Instantiate(userStatsLayout);
                childObject.transform.SetParent(scoreboardContainer.transform);
                childObject.transform.position = new Vector3(userStatsLayout.transform.position.x, userStatsLayout.transform.position.y, 0);
                childObject.transform.localScale = new Vector3(1, 1, 1);

                Text usernameText = childObject.transform.GetChild(0).GetComponent<Text>();
                usernameText.text = arrayResponse[i].username;

                Text scoreText = childObject.transform.GetChild(1).GetComponent<Text>();
                scoreText.text = arrayResponse[i].score.ToString();
            }
        });
    }

    private void BackButtonOnClick() {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}