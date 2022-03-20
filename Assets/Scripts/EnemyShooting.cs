using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 22f;

    //timer shiz
    public float FireRate;
    float lastfired;
 
    void Update()
    {
        if (this.gameObject.transform.GetChild(3).gameObject.GetComponent<StateMachine>().GetClosestEnemy() != null)
        {
            if (Time.time - lastfired > 1 / FireRate)
            {
                lastfired = Time.time;
                ShootingFunctions.Shoot(firePoint, bulletPrefab, bulletForce);
            }
        }
    }
}
