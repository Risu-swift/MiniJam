using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Rockspawner : MonoBehaviour
{
    [SerializeField] private int minRocks = 3;
    [SerializeField] private int maxRocks = 10;
    [SerializeField] private BoxCollider2D spawnArea;
    
    private int currentRocks;
    public GameObject HealthOrb;
    private List<GameObject> rockInstances;
    public List<GameObject> rockPrefab;

    private void Start()
    {
        rockInstances = new List<GameObject>();
        ChangeRocks();
    }
    
    public void ChangeRocks()
    {
        currentRocks = Random.Range(minRocks, maxRocks);

        for (int i = 0; i < currentRocks; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-spawnArea.bounds.extents.x, spawnArea.bounds.extents.x),
                Random.Range(-spawnArea.bounds.extents.y, spawnArea.bounds.extents.y));
            foreach (var rock in rockInstances)
            {
                int diff = rock.GetComponent<BoxCollider2D>().size - pos;
            }
            rockInstances.Add(Instantiate(rockPrefab[Random.Range(0,rockPrefab.Count)],pos,transform.rotation));
        }
    }

    public GameObject HealthOrbSpawn()
    {
        foreach (var rock in rockInstances)
        {
            rock.GetComponent<BoxCollider2D>();
        }
    }
}
