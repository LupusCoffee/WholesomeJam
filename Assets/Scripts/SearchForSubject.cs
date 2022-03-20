using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForSubject : MonoBehaviour
{
    public List<Transform> listOfSubjects = new List<Transform>();

    //check for enemy
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "subject")
        {
            listOfSubjects.Add(collision.gameObject.transform);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "subject")
        {
            foreach (Transform potentialTarget in listOfSubjects)
            {
                if (!listOfSubjects.Contains(collision.gameObject.transform))
                {
                    listOfSubjects.Add(collision.gameObject.transform);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "subject")
        {
            listOfSubjects.Remove(collision.gameObject.transform);
        }
    }

    public Transform GetClosestSubject()
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = this.gameObject.transform.position;
        foreach (Transform potentialTarget in listOfSubjects)
        {
            if(potentialTarget.tag == "ownedSubject")
            {
                listOfSubjects.Remove(potentialTarget);
            }
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }
}
