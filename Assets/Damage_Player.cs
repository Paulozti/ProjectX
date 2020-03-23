using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Player : MonoBehaviour
{
    public int health = 3;

    public GameObject death;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(death, transform.position, Player1.tag);
        Destroy(gameObject);
    }
}
