﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void IncreaseHealth(int health) 
    {
        this.health += health;
        if (this.health > maxHealth)
        {
            this.health = maxHealth;
        }
    }

    public void DecreaseHealth(int health)
    {
        this.health -= health;
        if (this.health < 0)
        {
            Destroy(this.gameObject);
        }
    }
}