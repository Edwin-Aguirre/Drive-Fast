using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField]
    public Transform[] spawnPoints; //Has to be public so that I can use in DestoryScript
    [SerializeField]
    private float spawnTime = 1.5f;
    [SerializeField]
    private GameObject[] powerUps;

    [SerializeField]
    public List<Transform> possibleSpawns = new List<Transform>(); //Has to be public so that I can use in DestoryScript


    // Start is called before the first frame update
    void Start()
    {
        //Fills the possible spawns
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            possibleSpawns.Add(spawnPoints[i]);
        }

        //Start spawning
        InvokeRepeating("SpawnItems", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnItems()
    {
        if(possibleSpawns.Count > 0)
        {
            int spawnIndex = Random.Range(0, possibleSpawns.Count);
            int spawnObject = Random.Range(0, powerUps.Length);

            GameObject NewPowerUp = Instantiate(powerUps[spawnObject], possibleSpawns[spawnIndex].position, possibleSpawns[spawnIndex].rotation) as GameObject;
            NewPowerUp.GetComponent<DestroyScript>().mySpawnPoint = possibleSpawns[spawnIndex];

            possibleSpawns.RemoveAt(spawnIndex);
        }
    }
}
