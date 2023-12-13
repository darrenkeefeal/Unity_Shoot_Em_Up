using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainSpaceShip : MonoBehaviour
{
    //Game Controller
    public Controller controller;

    Rigidbody2D rigidbodyShip;

    //Lasser Pos
    [SerializeField] public GameObject posA;
    [SerializeField] public GameObject posB;

    //Player Utilities
    public float speed;
    public float hp = 3;

    //Bullets
    public GameObject lasser, explosion;

   void Start()
    {
        PlayerPrefs.DeleteAll();
        rigidbodyShip = GetComponent<Rigidbody2D>();

        //Set Controller Player HP
        controller.SetPlayerHP(hp);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbodyShip.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed,0));
        rigidbodyShip.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    { 
        Instantiate(lasser, posA.transform.position, Quaternion.identity);
        Instantiate(lasser, posB.transform.position, Quaternion.identity);
    }

    public void Damage()
    {
        hp--;
        controller.SetPlayerHP(hp);
        StartCoroutine(Blink());
        if (hp == 0)
        {
            controller.PlayerIsDead();
            Destroy(gameObject, 0.1f);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }

    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
