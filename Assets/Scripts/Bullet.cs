using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigidbodyBullet;
    Transform bulletTransform;
    int dir = 1;

    private void Awake()
    {
        rigidbodyBullet = GetComponent<Rigidbody2D>();
        bulletTransform = GetComponent<Transform>();
    }

    public void ChangeDirection()
    { 
        dir *=-1;
    }

    public void ChangeColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }

    // Start is called before the first frame update
    void Start()
    {
        bulletTransform.rotation = Quaternion.Euler(0, 0, 90);
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbodyBullet.velocity = new Vector2(0,5 * dir);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dir == 1)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Enemy>().Damage();
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<MainSpaceShip>().Damage();
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "KillZone")
        {
            Destroy(gameObject);
        }
    }
}
