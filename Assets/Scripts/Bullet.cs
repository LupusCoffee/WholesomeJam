using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    PolygonCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = this.gameObject.AddComponent<PolygonCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            Physics.IgnoreLayerCollision(14, 16);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
}
