using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectHealth : MonoBehaviour
{
    float gravityForcePower;
    float health;
    public float maximumHealth;

    private void Start()
    {
        health = maximumHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.tag == "bullet")
        {
            health--;
            Destroy(collidedObject);
        }
    }

    void Update()
    {
        if(health <= 0)
        {
            this.GetComponent<GravityPointPull>().gravityForcePower = -GetComponent<GravityPointPull>().gravityForcePower;
            health = maximumHealth; //upon group entry, their health is full again
        }
    }
}
