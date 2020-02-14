using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class exitToMenu : MonoBehaviour {

    public Button myButton;
    void OnEnable()
    {
        myButton.onClick.AddListener(Button);
    }

    void Button()
    {
        SceneManager.LoadScene(1);
    }




}
