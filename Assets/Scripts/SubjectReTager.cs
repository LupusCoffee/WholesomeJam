using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectReTager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "AreaOfInfluence")
        {
            this.gameObject.tag = "ownedSubject";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "AreaOfInfluence")
        {
            this.gameObject.tag = "subject";
        }
    }
}
