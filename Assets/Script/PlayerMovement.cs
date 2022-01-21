using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float Live;
    public float TotalLive;
    public float ShootDamage;

    public GameObject RotationManager;
    public GameObject Bullet;

    public Sprite[] Sprites;
    public SpriteRenderer Srender;
    // Start is called before the first frame update
    void Start()
    {
        TotalLive = Live;
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();

    }

    public void CheckMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.eulerAngles = new Vector3(0, -180, 0);
            transform.position += transform.right * Speed * Time.deltaTime;
            RotationManager.transform.eulerAngles = new Vector3(0, 0, -180);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.up * Speed * Time.deltaTime;
            RotationManager.transform.eulerAngles = new Vector3(0, 0, -90);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
            transform.position += transform.right * Speed * Time.deltaTime;
            RotationManager.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * Speed * Time.deltaTime;
            RotationManager.transform.eulerAngles = new Vector3(0, 0, -270);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            RotationManager.transform.eulerAngles = new Vector3(0, 0, 45);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            RotationManager.transform.eulerAngles = new Vector3(0, 0, -225);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            RotationManager.transform.eulerAngles = new Vector3(0, 0, -135);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            RotationManager.transform.eulerAngles = new Vector3(0, 0, -45);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        ApplyDamage(ShootDamage);
        Instantiate(Bullet, this.transform.position, RotationManager.transform.rotation);
        
    }

    public void ApplyDamage(float d)
    {
        Live -= d;
        if(Live <= 0)
        {
            GameOver();
        }

        ChangeSprite();
    }

    public void ChangeSprite()
    {
        float factor = TotalLive / 4;
        //Full Live
        if((Live <= TotalLive) && (Live > factor * 3))
        {
            Srender.sprite = Sprites[0];
        }

        //75% Live
        else if ((Live >= factor * 3) && (Live > factor * 2))
        {
            Srender.sprite = Sprites[1];
        }
        //50% Live
        else if((Live >= factor * 2) && (Live > factor))
        {
            Srender.sprite = Sprites[2];
        }
        //25% Live
        else if((Live >= factor) && (Live > 0))
        {
            Srender.sprite = Sprites[3];
        }
        else
        {
            Srender.sprite = Sprites[4];
        }
    }
    public void GameOver()
    {
        Debug.Log("GameOver");
    }
}
