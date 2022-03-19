using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    Color thisColor = Color.white;

    private void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            this.gameObject.transform.GetChild(0).transform.GetChild(i).GetComponent<SpriteRenderer>().color = thisColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "AreaOfInfluence")
        {
            thisColor = collision.gameObject.GetComponent<SpriteRenderer>().color;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "AreaOfInfluence")
        {
            thisColor = Color.white;
        }
    }
}
