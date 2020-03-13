using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballshoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int damage = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();       
        }
    }

    void Shoot()
    {
        
    }
}
