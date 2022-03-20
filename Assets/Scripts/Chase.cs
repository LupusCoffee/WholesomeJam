using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    Transform target;
    Transform mapMiddle;
    Transform wallTransform;
    Rigidbody2D body;

    float speedAdjuster = 20f;
    float speed;
    float moveSpeed;
    float groupSize;
    float maxDistanceFromEnemy = 15;

    Vector2 movement;

    bool fleeing;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        mapMiddle = GameObject.Find("mid").transform;
    }

    void Update()
    {
        groupSize = this.gameObject.transform.GetChild(1).gameObject.GetComponent<GroupSizeChecker>().subjectsInInfluenceArea.Count;
        wallTransform = this.gameObject.transform.GetChild(1).gameObject.GetComponent<WallDetector>().GetWallTransform();
        speed = -groupSize + speedAdjuster;

        target = this.gameObject.transform.GetChild(3).gameObject.GetComponent<StateMachine>().GetClosestEnemy();

        if(target != null)
        {
            if (target.parent.tag == "enemy")
            {
                if (groupSize <= target.gameObject.GetComponent<GroupSizeChecker>().subjectsInInfluenceArea.Count * 0.7f)
                {
                    if(wallTransform == null)
                    {
                        fleeing = true;
                    }
                    else
                    {
                        fleeing = false;
                        target = wallTransform;
                    }
                    moveSpeed = -speed;
                }
            }
        }
        else if(target == null || target == mapMiddle)
        {
            fleeing = false;
            moveSpeed = speed;

            target = this.gameObject.transform.Find("SubjectDitector").gameObject.GetComponent<SearchForSubject>().GetClosestSubject();
            if (target == null)
            {
                target = mapMiddle;
            }
        }

        //move towards enemy
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        body.rotation = angle;
        movement = direction;


        //keep distance
        if (!fleeing && wallTransform == null)
        {
            if (Vector3.Distance(target.position, transform.position) <= maxDistanceFromEnemy)
            {
                moveSpeed = 0;
            }
            else
            {
                moveSpeed = speed;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2(movement.x, movement.y).normalized;
        body.velocity = targetVelocity * moveSpeed;
    }
}
