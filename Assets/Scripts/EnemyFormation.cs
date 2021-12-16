using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour
{
    public bool movingDown;
    public bool movingSide;
    public float speed = 2;
    private float descendSpeed = 1;
    public Vector3 destination;
    public GameObject bulletPrefab;

    private float timeTillFire;
    public float fireDelay = 1 ;

    public AudioSource audioSource;
    public AudioClip deathClip;

    void Start()
    {
        movingSide = true;
        timeTillFire = fireDelay;
        //destination = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);

    }

    void Update()
    {
        if (movingSide)
        {
            MoveHorizontal();
        }

        if (movingDown)
        {
            MoveDown();
        }


        if (timeTillFire > 0)
        {
            timeTillFire -= Time.deltaTime;
        }
        else
        {
            EnemyShoot();
            timeTillFire = fireDelay;
        }

    }


    public void PlayEnemyDeathAudio()
    {
        audioSource.PlayOneShot(deathClip);
    }


    public void EnemyShoot()
    {
        int numberofEnemies = GetComponentsInChildren<EnemyScript>().Length;

        if (numberofEnemies<=0)
        {
            return;
        }
        int index = Random.Range(0, numberofEnemies);
        var enemyArray = GetComponentsInChildren<EnemyScript>();

        Vector3 bullPos = enemyArray[index].transform.position;
        Instantiate(bulletPrefab, bullPos, Quaternion.identity);
    }

    public void SetDestinationAndMoveDown()
    {
        destination = new Vector3(transform.position.x, transform.position.y - 0.75f, transform.position.z);
        movingDown = true;

    }

    public void MoveDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * descendSpeed);

        if (transform.position == destination)
        {
            movingDown = false;
            speed *= -1;
            movingSide = true;
        }
    }

    public void MoveHorizontal()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

}