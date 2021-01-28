﻿using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update

    private int initialDamage = 35;
    private string goTag;
    private float fireballSpeed = 0.1f;
    private Rigidbody2D rb;
   public GameObject projectile;

  public  Vector3 attackerPos;
    public Vector3 preyPos;

    public bool haveCoords = false;

    private List<string> enemyTags = new List<string>();

    private void Awake()
    {
        GetEnemyTags();
        
    }

    private void GetEnemyTags()
    {
        goTag = this.gameObject.tag;

        if (goTag == "Fireball1")
        {
            enemyTags.Add("EnemyBody2");
        }
        else if (goTag == "Fireball2")
        {
            enemyTags.Add("EnemyBody1");
        }
    }

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (haveCoords)
        {
            Debug.Log(haveCoords);
           

            MoveFireballTowardsEnemy(ref attackerPos, ref preyPos);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("A HIT");
        if (collision.gameObject.tag == enemyTags[0])
        {
            var health = collision.gameObject.GetComponentInParent<Health>();
            health.DecreaseHealth(initialDamage);
        }

        //   Destroy(this.gameObject);
    }
    
    public void SetCoordForFireball(GameObject attacker, GameObject prey)
    {

        attackerPos = attacker.transform.position;
        preyPos = prey.transform.position;
        
        haveCoords = true;
        
        Instantiate(projectile, attackerPos, transform.rotation);
        /*
        this.attacker = attacker;
        this.prey = prey;
        Debug.Log(this.attacker);
        Debug.Log(this.prey);
        //  projectile.transform.position = Vector3.MoveTowards(attacker.transform.position, prey.transform.position, fireballSpeed);
    */
    }
    
    private void MoveFireballTowardsEnemy(ref Vector3 attPos, ref Vector3 preyPosi)
    {

        projectile.transform.position = Vector3.MoveTowards(attPos, preyPosi, fireballSpeed);
    }
}