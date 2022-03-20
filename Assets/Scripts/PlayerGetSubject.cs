using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetSubject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "subject")
        {
            collision.gameObject.AddComponent<PlayerAiming>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "subject")
        {
            Destroy(collision.gameObject.GetComponent<PlayerAiming>());
        }
    }
}
