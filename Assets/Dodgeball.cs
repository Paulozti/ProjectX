using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodgeball : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public Rigidbody2D force;
    public Gameobject hitEffect;


    // Start is called before the first frame update
    void Start()
    {
        force.velocity = transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {

        Debug.Log("Batata");
                      
        {
             GameObject Instantiate(hitEffect, transform.position, Quarternion.identity);
               
        }

    }
 }
    
