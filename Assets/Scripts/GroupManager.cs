using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupManager : MonoBehaviour
{
    float groupSize;
    public static float speed;
    public static CircleCollider2D thisAreaOfInfluence;

    private void Start()
    {
        thisAreaOfInfluence = this.gameObject.transform.GetChild(1).gameObject.GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (Time.frameCount >= 60)
        {
            groupSize = GroupSizeChecker.subjectsInInfluenceArea.Count;
            thisAreaOfInfluence.radius = Mathf.Sqrt(((groupSize)+1.9f)/(0.83f*13/Mathf.Pow(0.5f, 2)));

            if (groupSize <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
