using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class donotdestroyonstart : MonoBehaviour
{

    public string game = "Kent";
    public string menu = "Menu";
    // Start is called before the first frame update
    void Start()
    {
        

        //Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();


        // Retrieve the index of the scene in the project's build settings.
        int buildIndex = currentScene.buildIndex;

        // Check the scene name as a conditional.
        switch (buildIndex)
        {
            case 1:
                MonoBehaviour.DontDestroyOnLoad(this);
                SceneManager.LoadScene(2);
                break;
            case 2:
                Debug.Log("yeye");
                break;
                
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
