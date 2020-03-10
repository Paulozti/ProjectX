using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodgeball : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public Rigidbody2D force;


    // Start is called before the first frame update
    void Start()
    {
        force.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        Debug.Log("Batata");
        Player2 player2 = hitInfo.GetComponent<Player2>();
        if (player2 != null)
        {
            player2.TakeDamage(damage); 
        
        }
        Destroy(gameObject);   
    }
}
    
