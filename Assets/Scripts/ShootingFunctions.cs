using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingFunctions : MonoBehaviour
{
    public static void Shoot(Transform firePoint, GameObject bulletPrefab, float bulletForce)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();

        bullet.transform.rotation = firePoint.rotation;
        bulletBody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
}
