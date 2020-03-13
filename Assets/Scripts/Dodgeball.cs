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



        {
            if (hitInfo.gameObject.CompareTag("Player1"))
            {
                Player player1 = hitInfo.gameObject.GetComponent<Player>();
                if (player1 != null)
                {
                    player1.TakeDamage(damage);
                    Destroy(gameObject);
                }

            }

        }

    }

    }

