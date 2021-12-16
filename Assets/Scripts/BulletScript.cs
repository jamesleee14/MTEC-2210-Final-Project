using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public bool isPlayerBullet;
    private GameManager gameManager;
    public float speed;
    private float mod;
    private EnemyFormation enemyFormation;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyFormation = GameObject.Find("EnemyFormation").GetComponent<EnemyFormation>();

        if (isPlayerBullet)
        {
            mod = 1;
        }    
        else
        {
            mod = -1;
        }


    }


    void Update()
    {

        transform.Translate(0, speed*Time.deltaTime*mod, 0);
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            gameManager.IncreaseScore(collision.gameObject.GetComponent<EnemyScript>().scoreValue);
            enemyFormation.PlayEnemyDeathAudio();
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            gameManager.RestartGame();
        }
        Destroy(gameObject);
    }

}