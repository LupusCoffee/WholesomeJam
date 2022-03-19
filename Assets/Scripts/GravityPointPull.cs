using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPointPull : MonoBehaviour
{
    public Transform gravityPoint;
    public float gravityForcePower = 1000f;
    Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "AreaOfInfluence")
        {
            Vector3 direction = gravityPoint.position - body.transform.position;
            body.AddForceAtPosition(direction * gravityForcePower, gravityPoint.position);
        }
    }
}
