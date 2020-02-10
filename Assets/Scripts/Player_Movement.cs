using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    public float speed = 3.0f;
    public bool death = false;
    void Start()
    {

    }

    void FixedUpdate()
    {
        //Movement();
        TouchMovement();
    }
    void Update()
    {
        if(death == true)
        {
            gameObject.SetActive(false);
            Invoke("Restart", 1);
        }
    }

    void Movement()
    {
        //Gets an input when an Input is detected on a horizontal or vertical axis (W, S, Up, Down for vertical + A, D, Left, Right for horizontal).
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        //Moves the player in accordance to the input detected.
        transform.position += move * speed * Time.deltaTime;


    }

    void TouchMovement()
    {
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            // get mouse position in screen space
            // (if touch, gets average of all touches)
            Vector3 screenPos = Input.mousePosition;
            // convert mouse position to world space
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

            // get current position of this GameObject
            Vector3 newPos = transform.position;
            // set x and y position to mouse world-space x and y position
            newPos.x = worldPos.x;
            newPos.y = worldPos.y;
            // apply new position
            transform.position = newPos;
        }
    }

    void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Enemy Bullets"))
        {
            if (death == false)
            {
                death = true;
            }
        }
        if (hitInfo.CompareTag("Enemy"))
        {
            if (death == false)
            {
                death = true;
            }
        }
    }
}
