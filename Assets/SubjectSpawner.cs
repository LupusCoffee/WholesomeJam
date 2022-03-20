using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectSpawner : MonoBehaviour
{
    public List<Transform> listOfSubjects = new List<Transform>();
    public float maximumSubjects;

    BoxCollider2D myCollider;
    public GameObject subjectPrefab;

    float lastfired;
    float FireRate;

    private void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }

    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

    private void Update()
    {
        if(listOfSubjects.Count <= maximumSubjects)
        {
            FireRate = Random.Range(0, 0.5f);
            if (Time.time - lastfired > 1 / FireRate)
            {
                lastfired = Time.time;
                GameObject subject = Instantiate(subjectPrefab, RandomPointInBounds(myCollider.bounds), Quaternion.identity);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "subject")
        {
            listOfSubjects.Add(collision.gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "subject")
        {
            listOfSubjects.Remove(collision.gameObject.transform);
        }
    }
}
