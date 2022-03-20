using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupSizeChecker : MonoBehaviour
{
    public List<Collider2D> subjectsInInfluenceArea = new List<Collider2D>();

    //group size checker
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "subject")
        {
            if (!subjectsInInfluenceArea.Contains(collision))
            {
                subjectsInInfluenceArea.Add(collision);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "subject")
        {
            if (subjectsInInfluenceArea.Contains(collision))
            {
                subjectsInInfluenceArea.Remove(collision);
            }
        }
    }
}
