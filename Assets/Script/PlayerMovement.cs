using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float Live;

    public GameObject RotationManager;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {

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
        Instantiate(Bullet, this.transform.position, RotationManager.transform.rotation);
    }

    public void ApplyDamage(float d)
    {
        Live -= d;
        if(Live <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
    }
}
