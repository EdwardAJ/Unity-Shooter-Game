using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button scoreboardButton;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private AudioSource music;

    private Text soundButtonText;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayOnClick);
        scoreboardButton.onClick.AddListener(ScoreboardOnClick);
        soundButton.onClick.AddListener(SoundOnClick);
        exitButton.onClick.AddListener(ExitOnClick);

        soundButtonText = soundButton.GetComponentInChildren<Text>();

        PlayerPrefs.SetInt("Sound", 1);
        soundButtonText.text = "Sound: " + "On";
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayOnClick() {
        SceneManager.LoadScene("Game");
    }

    private void ScoreboardOnClick() {
        SceneManager.LoadScene("Scoreboard");
    }

    private void SoundOnClick() {
        if (soundButtonText.text.Equals("Sound: Off")) {
            music.Play();
            PlayerPrefs.SetInt("Sound", 1);
            soundButtonText.text = "Sound: " + "On";
        } else {
            music.Pause();
            PlayerPrefs.SetInt("Sound", 0);
            soundButtonText.text = "Sound: " + "Off";
        }
    }

    private void ExitOnClick() {
        Application.Quit();
    }
}
