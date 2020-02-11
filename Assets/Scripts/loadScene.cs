using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadScene : MonoBehaviour
{


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
