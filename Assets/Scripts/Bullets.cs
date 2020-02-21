using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 15;
    public float timer = 3f;

    void OnEnable()
    {
        //Resets timer on active.
        timer = 3f;
    }
    void Update()
    {
        //When the timer goes below/reaches 0, sets the bullet inactive.
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        //Constantly add velocity to move up.
        rb.velocity = transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //If the object has colliding with an object with the following tags, sets it inactive.
        if (hitInfo.CompareTag("Barrier"))
        {
            gameObject.SetActive(false);
        }
        if (hitInfo.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
}
