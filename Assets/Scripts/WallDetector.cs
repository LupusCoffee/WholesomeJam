using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    public Transform wall;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "objectCollider")
        {
            wall = collision.gameObject.transform;
        }
        else
        {
            wall = null;
        }
    }

    public Transform GetWallTransform()
    {
        return wall;
    }
}
