using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class milanBoss : MonoBehaviour
{

    public float movePattern = 1f;
    //private int health = 420;
    public float timer;
    public Rigidbody2D rb;
    public float speed;
    public float randBullet;
    public int shootPos = 0;
    public float timeBTWShots = 0.1f;
    public float shootTime;
    public int health = 212;

    public Transform playerShip;
    public Transform[] firePoint;
    public Transform angle2Player;
    // Start is called before the first frame update
    void Start()
    {
        shootTime = timeBTWShots;
    }

    // Update is called once per frame
    void Update()
    {
        //Timer goes down in real time.
        timer -= Time.deltaTime;
        shootTime -= Time.deltaTime;
        movement();
        FindPlayerAngle();
        RandomAngle();
        //Calls the shootTime function when timer reaches/goes below 0.
        if(shootTime < 0)
        {

            Shooting();
        }

    }

    
    void movement()
    {
        if (movePattern == 1f)
        {
            //If the timer is above 0, the boss moves down towards the player.
            if (timer > 0)
            {
                rb.velocity = transform.up * -speed * Time.deltaTime * 10;
            }
            else
            {
                //Changes the movement to the next stage and resets the timer.
                movePattern = 1.1f;
                timer = 2f;
            }
        }
        if (movePattern == 1.1f)
        {

            if (timer > 0)
            {
                //If the timer is above 0, keeps the milanHead from moving.
                rb.velocity = Vector2.zero;
            }
            else
            {
                //Changes the movement to the next stage and resets the timer.
                movePattern = 1.2f;
                timer = 1f;
            }
        }
        if (movePattern == 1.2f)
        {
            if (timer > 0)
            { 
                //If the timer is above 0, moves the milanHead down right.
                rb.velocity = new Vector2(1, -1f) * speed * Time.deltaTime * 5;
            }
            else
            {
                //Changes the movement to the next stage and resets the timer.
                rb.velocity = Vector2.zero;
                movePattern = 1.3f;
                timer = 1f;
            }
        }
        if (movePattern == 1.3f)
        {
            if (timer > 0)
            {
                //If the timer is above 0, moves the milanHead up left.
                rb.velocity = new Vector2(-1, 1f) * speed * Time.deltaTime * 5;
            }
            else
            {
                //Changes the movement to the next stage and resets the timer.
                rb.velocity = Vector2.zero;
                movePattern = 1.4f;
                timer = 1f;
            }
        }
        if (movePattern == 1.4f)
        {
            if (timer > 0)
            {
                //If the timer is above 0, moves the player down left.
                rb.velocity = new Vector2(-1, -1f) * speed * Time.deltaTime * 5;
            }
            else
            {
                //Changes the movement to the next stage and resets the timer.
                rb.velocity = Vector2.zero;
                movePattern = 1.5f;
                timer = 1f;
            }
        }
        if (movePattern == 1.5f)
        {
            if (timer > 0)
            {
                //If the timer is above 0, moves milanHead up right.
                rb.velocity = new Vector2(1, 1f) * speed * Time.deltaTime * 5;
            }
            else
            {
                //Changes the movement to the stage 1.1 and resets the timer.
                rb.velocity = Vector2.zero;
                movePattern = 1.1f;
                timer = 1f;
            }
        }


    }
    void FindPlayerAngle()
    {
        //Finds the player angle and sets the middle fire point to point at the player.
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            var addAngle = 270;
            var dir = playerShip.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + addAngle;
            angle2Player.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
    }

    void RandomAngle()
    {
        //Sets the left and right fire points to a random angle between -200 + 200.
        firePoint[0].rotation = Quaternion.AngleAxis(Random.Range(-200, 200), Vector3.forward);
        firePoint[1].rotation = Quaternion.AngleAxis(Random.Range(-200, 200), Vector3.forward);

    }

    void Shooting()
    {
        //Randomly chooses a bullet with a 1/3 chance being a regular bullets and 2/3 chance to shoot a split bullet.
        randBullet = Random.Range(0, 3);
        //Shoots a bullet at one of the fire points and moves it along one to the right or to the left fire point if on the right fire point.
        if(shootPos == 0)
        {
            if (randBullet == 0)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("MilanHead Bullet");
                if (bullet != null)
                {
                    bullet.transform.position = firePoint[0].transform.position;
                    bullet.transform.rotation = firePoint[0].transform.rotation;
                    bullet.SetActive(true);
                    shootTime = timeBTWShots;
                }
            }
            else
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("MSplit");
                if (bullet != null)
                {
                    Debug.Log("help");
                    bullet.transform.position = firePoint[0].transform.position;
                    bullet.transform.rotation = firePoint[0].transform.rotation;
                    bullet.SetActive(true);
                    shootTime = timeBTWShots;
                }
            }
            shootPos = 1;
        }
        if(shootPos == 1)
        {
            if (randBullet == 0)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("MilanHead Bullet");
                if (bullet != null)
                {
                    bullet.transform.position = angle2Player.transform.position;
                    bullet.transform.rotation = angle2Player.transform.rotation;
                    bullet.SetActive(true);
                    shootTime = timeBTWShots;
                }
            }
            else
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("MSplit");
                if (bullet != null)
                {
                    bullet.transform.position = angle2Player.transform.position;
                    bullet.transform.rotation = angle2Player.transform.rotation;
                    bullet.SetActive(true);
                    shootTime = timeBTWShots;
                }
            }
            shootPos = 2;
        }
        if (shootPos == 2)
        {
            if (randBullet == 0)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("MilanHead Bullet");
                if (bullet != null)
                {
                    bullet.transform.position = firePoint[1].transform.position;
                    bullet.transform.rotation = firePoint[1].transform.rotation;
                    bullet.SetActive(true);
                    shootTime = timeBTWShots;
                }
            }
            else
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("MSplit");
                if (bullet != null)
                {
                    bullet.transform.position = firePoint[1].transform.position;
                    bullet.transform.rotation = firePoint[1].transform.rotation;
                    bullet.SetActive(true);
                    shootTime = timeBTWShots;
                }
            }
            shootPos = 0;
        }

    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //When the milanHead is hit by anything with the following tags, reduces the health of the milanHead.
        if (hitInfo.CompareTag("Player Bullets"))
        {
            health -= 1;
        }
        if (hitInfo.CompareTag("Player"))
        {
            health -= 1;
        }

    }

    void HealthCheck()
    {
        //if health reaches or goes below 0 kills the milanHead
        if(health <= 0)
        {
            Destroy(this);
        }
    }
}
