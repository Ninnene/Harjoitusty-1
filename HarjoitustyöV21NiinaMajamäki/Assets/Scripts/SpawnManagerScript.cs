using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
//tämä koodi saa esteet ilmestymään peliin
    public GameObject obstaclePrefab;

    private Vector3 spawnPos = new Vector3(25, 0, 0);

    //private float startDelay = 2;
    private float repeatRate = 2;

    private PlauerControllerTheOther playerControllerScripts;
    public float timeSinceLastSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawn = 0;


        //InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScripts = GameObject.Find("Player").GetComponent<PlauerControllerTheOther>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScripts.gameOver == false && Time.timeScale > 0)
        {
            timeSinceLastSpawn += Time.deltaTime;
            if (timeSinceLastSpawn >= repeatRate)
            {
                SpawnObstacle();
                timeSinceLastSpawn = 0;
            }
        }
    }

    void SpawnObstacle()
    {
        if (playerControllerScripts.gameOver == false) 
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
