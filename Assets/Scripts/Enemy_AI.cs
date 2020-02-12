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
    public float spawnLoc;

    public bool leftS;
    public bool death = false;

    private Rigidbody2D rb;

    public GameObject bullet;
    //public GameObject self;

    public Transform playerShip;
    public Transform firePoint;
    public Transform angle2Player;

    public Spawner spawn;

    void Start()
    {
        spawn = GameObject.Find("Spawner (Right)").GetComponent<Spawner>();
        spawnLoc = spawn.randSpawn;
        //Chooses a random movement pattern.
        movementRandomizer();

        shootTime = timeBTWShots;

        rb = this.GetComponent<Rigidbody2D>();
        /*if (GameObject.FindWithTag("p") != null)
        {
            playerShip = GameObject.FindWithTag("p").transform;
        }*/
       
    }
    void FixedUpdate()
    {
        findPlayerAngle();
        timer -= Time.deltaTime;
        movement1();
        movement2();
        if (spawnLoc == 0)
        {
            leftS = false;
        }
        if(spawnLoc == 4)
        {
            leftS = true;
        }
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
            }
        }
        if(movePattern == 1.1f)
        {
            if(timer > 0)
            {
                rb.velocity = Vector2.zero;
            }
            else
            {
                movePattern = 1.2f;
                timer = 1f;
            }
        }
        if(movePattern == 1.2f)
        {
            if (timer > 0)
            {
                if(leftS == true)
                {
                    rb.velocity = new Vector2(1, -1) * speed * Time.deltaTime;
                }
                if(leftS == false)
                {
                    rb.velocity = new Vector2(-1,-1) * speed * Time.deltaTime;
                }
            }            
            else
            {
                movePattern = 1.3f;
                timer = 1f;
            }
        }
        if(movePattern == 1.3f)
        {
            if(timer > 0)
            {
                if (leftS == true)
                {
                    rb.velocity = new Vector2(-1, -1) * speed * Time.deltaTime;
                }
                if (leftS == false)
                {
                    rb.velocity = new Vector2(1, -1) * speed * Time.deltaTime;
                }
            }
            else
            {
                movePattern = 1.2f;
                timer = 1f;
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

    void movementRandomizer()
    {
        int a = Random.Range(0, 2);

        if(spawnLoc == 0 || spawnLoc == 4)
        {
            if (a == 0)
            {
                movePattern = 1f;
            }
            else
            {
                movePattern = 2f;
            }
        }
        else
        {
            movePattern = 2f;
        }
    }
}
