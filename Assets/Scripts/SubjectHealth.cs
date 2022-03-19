using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectHealth : MonoBehaviour
{
    float gravityForcePower;
    public float health;

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
        }
    }
}
