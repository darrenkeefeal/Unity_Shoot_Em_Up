using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float rate;

    public GameObject[] enemyGO;
    public int waves;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", rate, rate);
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < waves; i++)
        {
            Instantiate(enemyGO[Random.Range(0, enemyGO.Length)], new Vector3(Random.Range(-7, 7), 6, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
