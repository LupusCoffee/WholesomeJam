using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    public GameObject wall;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall")
        {
            wall = collision.gameObject;
        }
        else
        {
            wall = null;
        }
    }

    public GameObject GetWallObject()
    {
        return wall;
    }
}
