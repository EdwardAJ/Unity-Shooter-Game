using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button scoreBoardButton;
    [SerializeField] private Button soundButton;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayOnClick);
        scoreBoardButton.onClick.AddListener(ScoreBoardOnClick);
        soundButton.onClick.AddListener(SoundOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayOnClick() {
        SceneManager.LoadScene("Game");
    }

    private void ScoreBoardOnClick() {

    }

    private void SoundOnClick() {

    }
}
