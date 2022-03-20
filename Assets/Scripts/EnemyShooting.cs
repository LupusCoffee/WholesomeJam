using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    //timer shiz
    public float FireRate;
    float lastfired;
 
    void Update()
    {
        if (Time.time - lastfired > 1 / FireRate)
        {
            lastfired = Time.time;
            ShootingFunctions.Shoot(firePoint, bulletPrefab, bulletForce);
        }
    }
}
