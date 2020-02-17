using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_AI : MonoBehaviour
{
    public float speed = 3f;
    public float timer = 1f;
    public float timeBTWShots = 0.5f;
    private float shootTime;
    public float movePattern = 1f;
    public float spawnLoc;
    public ScoreTracker1 scores;
    public bool leftS;
    public bool death = false;
    public int bulletType = 0;
    public int moveLoop;

    public Rigidbody2D rb;
    //public GameObject[] bullet;
    public GameObject self;

    public Transform playerShip;
    public Transform firePoint;
    public Transform angle2Player;

    public Spawner spawn;

    void OnEnable()
    {

        scores = GameObject.Find("score1").GetComponent<ScoreTracker1>();
        spawn = GameObject.Find("Spawner (Right)").GetComponent<Spawner>();
        spawnLoc = spawn.randSpawn;
        //Chooses a random movement pattern.
        MovementRandomizer();

        shootTime = 0.5f;

        rb = GetComponent<Rigidbody2D>();
        if (GameObject.FindWithTag("Player") != null)
        {
            playerShip = GameObject.FindWithTag("Player").transform;
        }
       
    }
    void FixedUpdate()
    {
        FindPlayerAngle();
        timer -= Time.deltaTime;
        Movement1();
        Movement2();
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
            ++scores.score2;
            gameObject.SetActive(false);
        }

        ShootTimer();
    }

    //Enemy moves down, pauses then to the left
    void Movement1()
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
                timer = 0.5f;
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
                    rb.velocity = new Vector2(1, -0.3f) * speed * 0.5f * Time.deltaTime;
                }
                if(leftS == false)
                {
                    rb.velocity = new Vector2(-1,-0.3f) * speed * 0.5f * Time.deltaTime;
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
                    rb.velocity = new Vector2(-1, -0.3f) * speed * 0.5f * Time.deltaTime;
                }
                if (leftS == false)
                {
                    rb.velocity = new Vector2(1, -0.3f) * speed * 0.5f * Time.deltaTime;
                }
            }
            else
            {
                timer = 1f;
                moveLoop++;
                if(moveLoop == 2)
                {
                    movePattern = 1.3f;
                }
                else
                {
                    movePattern = 1.2f;
                }
            }
        }
    }

    void Movement2()
    {
        if(movePattern == 2)
        {
            rb.velocity = transform.up * speed * Time.deltaTime;
        }
    }

    void ShootTimer()
    {
        shootTime -= Time.deltaTime;
        if(shootTime < 0)
        {
            if (movePattern == 2)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("Enemy Bullets");
                if (bullet != null)
                {
                    bullet.transform.position = firePoint.transform.position;
                    bullet.transform.rotation = firePoint.transform.rotation;
                    bullet.SetActive(true);
                }
            }
            else
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("Enemy Bullets 1");
                if (bullet != null)
                {
                    bullet.transform.position = firePoint.transform.position;
                    bullet.transform.rotation = firePoint.transform.rotation;
                    bullet.SetActive(true);
                }
            }

            shootTime = timeBTWShots;
        }
    }

    void FindPlayerAngle()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
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
            gameObject.SetActive(false);
        }
    }

    void MovementRandomizer()
    {
        int a = Random.Range(0, 3);

        if(spawnLoc == 0 || spawnLoc == 4)
        {
            if (a != 2)
            {
                movePattern = 1f;
                bulletType = 1;
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
