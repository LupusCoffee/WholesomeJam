using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public GameObject enemy;
    public List<Transform> listOfEnemies = new List<Transform>();

    //check for enemy
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "group")
        {
            listOfEnemies.Add(collision.gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "group")
        {
            listOfEnemies.Remove(collision.gameObject.transform);
        }
    }

    public Transform GetClosestEnemy()
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = this.gameObject.transform.position;
        foreach (Transform potentialTarget in listOfEnemies)
        {
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
