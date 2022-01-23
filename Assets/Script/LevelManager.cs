using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int minRocks = 3;
    [SerializeField] private int maxRocks = 10;
    [SerializeField] private int maxElements = 15;
    [SerializeField] private BoxCollider2D spawnArea;
    
    private int currentRocks;
    public GameObject Player;
    public GameObject HealthOrb;
    private List<GameObject> rockInstances;
    public List<GameObject> rockPrefab;
    public List<GameObject> EnemeyList;

    public GameObject Apath;
    private void Start()
    {
        rockInstances = new List<GameObject>();
        ChangeRocks();
        SpawnHealthOrb();
        SpawnEnemy();
        SpawnAPath();
    }
    
    public void ChangeRocks()
    {
        currentRocks = Random.Range(minRocks, maxRocks);

        for (int i = 0; i < currentRocks; i++)
        {
            Vector2 pos = getRandomPos();

            foreach (var rockInstance in rockInstances)
            {
                BoxCollider2D rockCollider = rockInstance.GetComponent<BoxCollider2D>();
                if (rockCollider.bounds.Contains(pos + (Vector2) rockCollider.bounds.size))
                {
                    getRandomPos();
                }
            }
         
            rockInstances.Add(Instantiate(rockPrefab[Random.Range(0,rockPrefab.Count)],pos,transform.rotation));
        }
    }

    public void SpawnHealthOrb()
    {
        Vector2 pos = getRandomPos();

        Instantiate(HealthOrb,pos, transform.rotation);
    }

    public void SpawnEnemy()
    {
        
        for (int i = 0; i < maxElements - currentRocks; i++)
        {
            Vector2 pos = getRandomPos();
            GameObject temp = Instantiate(EnemeyList[Random.Range(0, EnemeyList.Count)], pos, transform.rotation);
            //temp.GetComponent<EnemyIA>().target = Player;
        }

    }

    public Vector2 getRandomPos()
    {
        return new Vector2(Random.Range(-spawnArea.bounds.extents.x, spawnArea.bounds.extents.x),
            Random.Range(-spawnArea.bounds.extents.y, spawnArea.bounds.extents.y));
    }

    public void SpawnAPath()
    {
        Instantiate(Apath);
    }

}
