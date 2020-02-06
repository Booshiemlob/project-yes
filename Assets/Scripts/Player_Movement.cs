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
    }

    void Movement()
    {
        //Gets an input when an Input is detected on a horizontal or vertical axis (W, S, Up, Down for vertical + A, D, Left, Right for horizontal).
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        //Moves the player in accordance to the input detected.
        transform.position += move * speed * Time.deltaTime;
    }
}
