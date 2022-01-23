using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float RestTimeToSpawn;

    public int MinTimeToSpawn;
    public int MaxTimeToSpawn;
    public bool HasToSpawn;

    public GameObject EnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        ResetTimeSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (HasToSpawn)
        {
            if(RestTimeToSpawn <= 0)
            {
                Spawn();
            }
            else
            {
                RestTimeToSpawn -= Time.deltaTime;
            }
        }
    }

    public void ResetTimeSpawn()
    {
        RestTimeToSpawn = Random.Range(MinTimeToSpawn, MaxTimeToSpawn);
    }
    public void Spawn()
    {
        GameObject En;
        ResetTimeSpawn();
        HasToSpawn = false;
        Vector3 aux = new Vector3(transform.position.x, transform.position.y, 0.0f);
        En = Instantiate(EnemyPrefab, aux, transform.rotation);
        En.GetComponent<EnemyIA>().SpawnTransform = this.transform;
    }
}
