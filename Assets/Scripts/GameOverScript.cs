using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public void GameOverscreen()
    {
            
            this.gameObject.SetActive(true);
            Invoke("Restart", 5);
    }
}
