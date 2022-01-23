using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float NumerOfEnemies;
    public float RemindEnemies;
    public float PlayerScore;
    public int MinEnemis;
    public int MaxEnemis;

    public Spawner[] Spawners;

    public GameObject Doors;
    public GameObject[] Rooms;
    public GameObject ActualRoom;
    public GameObject Player;

    public Text LiveText;
    public Text ScoreText;
    public Text EnemiesText;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        ChangeRoom();
    }

    void SpawnEnemies()
    {
        NumerOfEnemies = Random.Range(MinEnemis, MaxEnemis);
        RemindEnemies = NumerOfEnemies;
        for (int i = 0; i < NumerOfEnemies; i++)
        {
            int aux = Random.Range(0, Spawners.Length);
            while (Spawners[aux].HasToSpawn) aux = Random.Range(0, Spawners.Length);
            Spawners[aux].HasToSpawn = true;
        }
    }
    void ChangeRoom()
    {
        SpawnEnemies();
        int RandomRoom = Random.Range(0, Rooms.Length);
        Destroy(ActualRoom);
        ActualRoom = Instantiate(Rooms[RandomRoom]);
    }

    public void EnableDoors()
    {
        Doors.SetActive(true);
    }
    public void DisableDoors()
    {
        Doors.SetActive(false);
        ChangeRoom();
    }

    public void CheckText()
    {
        LiveText.text = Player.GetComponent<PlayerMovement>().Live.ToString();
        ScoreText.text = PlayerScore.ToString();
        EnemiesText.text = RemindEnemies.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        CheckText();
    }
}
