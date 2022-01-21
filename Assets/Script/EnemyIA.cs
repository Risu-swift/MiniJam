using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{

    public bool hit = false;

    public float speed;
    public float damage;
    public float Live;

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void ApplyDamage(float d)
    {
        Live -= d;
        if (Live <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().ApplyDamage(damage);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            ApplyDamage(collision.gameObject.GetComponent<Bullet>().Damage);
            Destroy(collision.gameObject);
            hit = true;
            SpriteBlinkingEffect();
        }
    }
   

    private void SpriteBlinkingEffect()
    {
        if (hit == true)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(whitecolor());
        }
    }

    IEnumerator whitecolor()
    {
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
        hit = false;
    }
}
