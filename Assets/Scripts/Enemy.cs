using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigidbody_Enemy;

    //Movement
    public float xSpeed;
    public float ySpeed;

    //Utilities
    public float fireRate;
    public float hp;
    public bool canShoot;
    public int scores;

    public GameObject lasser, explosion;
    public Color lasserColor;

    private void Awake()
    {
        rigidbody_Enemy = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!canShoot) return;

        fireRate = fireRate + (Random.Range(fireRate / -2, fireRate / 2));
        InvokeRepeating("Shoot", fireRate, fireRate);
    }

    void Shoot()
    {
        GameObject temp = (GameObject)Instantiate(lasser, transform.position, Quaternion.identity);
        temp.GetComponent<Bullet>().ChangeDirection();
        temp.GetComponent <Bullet>().ChangeColor(lasserColor);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody_Enemy.velocity = new Vector2(xSpeed, ySpeed * -1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<MainSpaceShip>().Damage();
            Die();
        }
        else if (collision.gameObject.tag == "KillZone")
        {
            Destroy(gameObject);
        }
    }

    void Die()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + scores);
        Destroy(gameObject);
    }

    public void Damage()
    {
        hp--;
        if (hp == 0)
        { 
            Die();
        }
    }
}
