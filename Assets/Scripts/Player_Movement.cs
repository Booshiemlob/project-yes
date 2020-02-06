using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 3.0f;
    void Start()
    {

    }

    void FixedUpdate()
    {
        Movement();
        TouchMovement();
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
            // set x position to mouse world-space x position
            newPos.x = worldPos.x;
            newPos.y = worldPos.y;
            // apply new position
            transform.position = newPos;
        }
    }
}
