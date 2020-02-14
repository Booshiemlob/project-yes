using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class donotdestroyonstart : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();


        // Retrieve the index of the scene in the project's build settings.
        int buildIndex = currentScene.buildIndex;

        /* 0 is Main Menu
         * 1 is Preload
         * 2 is Game
         */
        // Check the scene name as a conditional.
        switch (buildIndex)
        {
            case 0:
                gameObject.SetActive(false);
                break;
            case 1:
                MonoBehaviour.DontDestroyOnLoad(this);
                SceneManager.LoadScene(2);
                break;
            case 2:
                Debug.Log("ya");
                break;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.index == 0)
        {
            Destroy(gameObject);
        }
    }
}
