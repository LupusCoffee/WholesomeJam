using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D body;
    PolygonCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        collider = this.gameObject.AddComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
