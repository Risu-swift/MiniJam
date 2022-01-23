using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform InverseDoor;

    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("LevelManager").GetComponent<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Hola");
            gm.PlayerScore++;
            collision.gameObject.transform.position = InverseDoor.transform.position;
            gm.DisableDoors();
        }
    }
}
