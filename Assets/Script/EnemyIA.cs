using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyIA : MonoBehaviour
{

    [SerializeField] Transform target;
    NavMeshAgent agent;
    public bool Knock = false;

    public float damage;
    public float Live;
    public float KnockTime;
    public float KnockDistance;
    public float Speed;

    public Transform SpawnTransform;

    public GameManager gm;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

        gm = GameObject.Find("LevelManager").GetComponent<GameManager>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        Speed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        // agent.Warp(SpawnTransform.position);
        if (!Knock)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            KnockEnemy();
        }
    }

    public void ApplyDamage(float d)
    {
        Live -= d;
        if (Live <= 0)
        {
            gm.RemindEnemies--;
            if (gm.RemindEnemies <= 0) gm.EnableDoors();
            Destroy(this.gameObject);
        }
    }

    public void KnockEnemy()
    {
        agent.enabled = false;
        Knock = false;
        Vector3 hitVector = (target.transform.position - transform.position).normalized;
        hitVector = (target.transform.position - transform.position);
        hitVector.z = 0;
        hitVector = hitVector.normalized;
        transform.position -= hitVector * KnockDistance * Time.deltaTime;
        agent.enabled = true;
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().ApplyDamage(damage,true);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Knock = true;
            ApplyDamage(collision.gameObject.GetComponent<Bullet>().Damage);
            Destroy(collision.gameObject);
        }
    }




   

}
