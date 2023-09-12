using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    [SerializeField]
    private float destroyTime = 3.0f;

    private SpawnScript SS;
    public Transform mySpawnPoint; //Has to be public so that I can use it in the SpawnScript

    // Start is called before the first frame update
    void Start()
    {
        SS = GameObject.Find("ItemSpawn").GetComponent<SpawnScript>();
        //Destroys the powerups after a while so that there isn't powerups spawning on top of eachother
        StartCoroutine(DestroyObjects());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyObjects()
    {
        yield return new WaitForSeconds(destroyTime);

        for(int i = 0; i < SS.spawnPoints.Length; i++)
        {
            if(SS.spawnPoints[i] == mySpawnPoint)
            {
                SS.possibleSpawns.Add(SS.spawnPoints[i]);
            }
        }
        Destroy(gameObject);
    }
}
