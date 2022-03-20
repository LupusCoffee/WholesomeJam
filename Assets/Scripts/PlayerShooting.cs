using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : ShootingFunctions
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 22f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootingFunctions.Shoot(firePoint, bulletPrefab, bulletForce);
        }
    }
}
