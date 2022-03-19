using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPointPull : MonoBehaviour
{
    public float gravityForcePower = 1000f;
    Transform gravityPoint;
    Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "AreaOfInfluence")
        {
            gravityPoint = collision.transform.parent.transform.GetChild(0);
            Vector3 direction = gravityPoint.position - body.transform.position;
            body.AddForceAtPosition(direction * gravityForcePower, gravityPoint.position);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "AreaOfInfluence")
        {
            this.GetComponent<GravityPointPull>().gravityForcePower = -GetComponent<GravityPointPull>().gravityForcePower;
        }  
    }
}
