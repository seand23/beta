using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private GameManager gameManager;
    public int health = 5;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= 1;
        }
        if (health <= 0)
        {
            //kill the boss zombie 
            Destroy(collision.gameObject);
            Destroy(gameObject);

            //keeping track of score
            gameManager.UpdateScore(200);
            //congratulation text for killing/survivng boss
        }

    }

}
