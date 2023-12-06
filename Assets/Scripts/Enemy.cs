using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    private GameObject player;
    private Rigidbody enemyRb;
    private GameManager gameManager;
    private SpawnManager spawnManager;
    public bool isBoss = false;
    private float nextSpawn;
    private float spawnInterval;

    //animation attempt
    private Animator zombieAnimator;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        zombieAnimator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        if (isBoss)
        {
            spawnManager = FindObjectOfType<SpawnManager>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = ((player.transform.position - transform.position).normalized);

        // Rotate towards the player
        transform.LookAt(player.transform);

        // enemyRb.AddForce(lookDirection * speed);
        transform.Translate(lookDirection * speed * Time.deltaTime, Space.World);



        if (isBoss)
        {
            nextSpawn = Time.time + spawnInterval;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //animation attempt//trying to trigger 'death' if the bullet hits the zombie
        if (collision.gameObject.CompareTag("Bullet") && gameObject.CompareTag("Enemy"))
        {
            zombieAnimator.SetTrigger("Death_trig");
            
        }
        else if (collision.gameObject.CompareTag("Bullet") && gameObject.CompareTag("FastZombie"))
        {
            zombieAnimator.SetTrigger("Death_trig2");
        }
    }
}
