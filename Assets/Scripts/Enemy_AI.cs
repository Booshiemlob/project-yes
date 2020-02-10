using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public float speed = 3f;
    public float timer = 1f;
    public float timeBTWShots = 0.5f;
    private float shootTime;
    public float movePattern = 1f;

    public bool leftS;
    public bool death = false;

    public Rigidbody2D rb;

    public GameObject bullet;
    //public GameObject self;

    public Transform playerShip;
    public Transform firePoint;
    public Transform angle2Player;

    void Start()
    {
        //Chooses a random movement pattern.
        //movePattern = Random.Range(1, 3);

        shootTime = timeBTWShots;

        rb = this.GetComponent<Rigidbody2D>();
        if (GameObject.FindWithTag("Player") != null)
        {
            playerShip = GameObject.FindWithTag("Player").transform;
        }
        //angle2Player = playerShip;
    }
    void FixedUpdate()
    {
        findPlayerAngle();
        timer -= Time.deltaTime;
        movement1();
        movement2();
    }
    void Update()
    {
        if(death == true)
        {
            Destroy(gameObject);
        }

        shootTimer();
    }

    //Enemy moves down, pauses then to the left
    void movement1()
    {
        if(movePattern == 1f)
        {
            if(timer > 0)
            {
                rb.velocity = transform.up * speed *Time.deltaTime;
            }
            else
            {
                movePattern = 1.1f;
                timer = 1.5f;
                Debug.Log("Change 1");
            }
        }
        if(movePattern == 1.1f)
        {
            if(timer > 0)
            {
                return;
            }
            else
            {
                movePattern = 1.2f;
                timer = 5;
            }
        }
        if(movePattern == 1.2f)
        {
            if (timer > 0)
            {
                if(leftS == true)
                {
                    rb.velocity = transform.right * speed * Time.deltaTime;
                }

            }
            if (timer < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void movement2()
    {
        if(movePattern == 2)
        {
            rb.velocity = transform.up * speed * Time.deltaTime;
        }
    }

    void shootTimer()
    {
        shootTime -= Time.deltaTime;
        if(shootTime < 0)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            shootTime = timeBTWShots;
        }
    }

    void findPlayerAngle()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            var addAngle = 270;
            var dir = playerShip.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + addAngle;
            angle2Player.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player Bullets"))
        {
            if(death == false)
            {
                death = true;
            }
        }
        if (hitInfo.CompareTag("Player"))
        {
            if (death == false)
            {
                death = true;
            }
        }
        if (hitInfo.CompareTag("Barrier"))
        {
            Debug.Log("yes");
            if (death == false)
            {
                death = true;
            }
        }
    }
}
