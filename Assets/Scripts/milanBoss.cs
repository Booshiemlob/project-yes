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
        timer -= Time.deltaTime;
        shootTime -= Time.deltaTime;
        movement();
        FindPlayerAngle();
        RandomAngle();
        if(shootTime < 0)
        {

            Shooting();
        }

    }

    
    void movement()
    {
        if (movePattern == 1f)
        {
            if (timer > 0)
            {
                rb.velocity = transform.up * -speed * Time.deltaTime * 10;
            }
            else
            {
                movePattern = 1.1f;
                timer = 2f;
            }
        }
        if (movePattern == 1.1f)
        {
            if (timer > 0)
            {
                rb.velocity = Vector2.zero;
            }
            else
            {
                movePattern = 1.2f;
                timer = 1f;
            }
        }
        if (movePattern == 1.2f)
        {
            if (timer > 0)
            {
                rb.velocity = new Vector2(1, -1f) * speed * Time.deltaTime * 5;
            }
            else
            {
                rb.velocity = Vector2.zero;
                movePattern = 1.3f;
                timer = 1f;
            }
        }
        if (movePattern == 1.3f)
        {
            if (timer > 0)
            {
                rb.velocity = new Vector2(-1, 1f) * speed * Time.deltaTime * 5;
            }
            else
            {
                rb.velocity = Vector2.zero;
                movePattern = 1.4f;
                timer = 1f;
            }
        }
        if (movePattern == 1.4f)
        {
            if (timer > 0)
            {
                rb.velocity = new Vector2(-1, -1f) * speed * Time.deltaTime * 5;
            }
            else
            {
                rb.velocity = Vector2.zero;
                movePattern = 1.5f;
                timer = 1f;
            }
        }
        if (movePattern == 1.5f)
        {
            if (timer > 0)
            {
                rb.velocity = new Vector2(1, 1f) * speed * Time.deltaTime * 5;
            }
            else
            {
                rb.velocity = Vector2.zero;
                movePattern = 1.1f;
                timer = 1f;
            }
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

    void RandomAngle()
    {
        firePoint[0].rotation = Quaternion.AngleAxis(Random.Range(-200, 200), Vector3.forward);
        firePoint[1].rotation = Quaternion.AngleAxis(Random.Range(-200, 200), Vector3.forward);

    }

    void Shooting()
    {

        randBullet = Random.Range(0, 3);
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
}
