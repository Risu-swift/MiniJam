using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public float Live;
    public float Damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckLive();
        MoveBullet();
    }


    public void MoveBullet()
    {
        transform.position += transform.right * Speed * Time.deltaTime;
    }
    public void CheckLive()
    {
        if(Live <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Live -= Time.deltaTime;
        }
    }
}
