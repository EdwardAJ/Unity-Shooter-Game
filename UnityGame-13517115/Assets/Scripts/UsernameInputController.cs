using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsernameInputController : MonoBehaviour
{
    public Text usernameText;
    public GameObject scoreCanvas;

    //Called when Input changes
    private void inputSubmitCallBack()
    {
        Debug.Log("Input Submitted: " + usernameText.text);
        scoreCanvas.GetComponent<ScoreController>().StoreUserStats(usernameText);
        gameObject.SetActive(false);

    }

    void OnEnable()
    {
        GetComponent<InputField>().onEndEdit.AddListener(delegate { inputSubmitCallBack(); });
    }

    void OnDisable()
    {
        //Un-Register InputField Events
        GetComponent<InputField>().onEndEdit.RemoveAllListeners();
    }
}
