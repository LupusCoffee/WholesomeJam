using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    Transform target;
    Transform mapMiddle;
    Rigidbody2D body;

    float speedAdjuster = 20f;
    float speed;
    float moveSpeed;
    float groupSize;

    Vector2 movement;

    float maxDistanceFromEnemy = 15;


    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        mapMiddle = GameObject.Find("mid").transform;
        moveSpeed = speed;
    }

    void Update()
    {
        groupSize = this.gameObject.transform.GetChild(1).gameObject.GetComponent<GroupSizeChecker>().subjectsInInfluenceArea.Count;
        speed = -groupSize + speedAdjuster;

        target = this.gameObject.transform.GetChild(3).gameObject.GetComponent<StateMachine>().GetClosestEnemy();

        //target conditions
        if(target == null || target == mapMiddle) //or is much stronger than you
        {
            target = this.gameObject.transform.Find("SubjectDitector").gameObject.GetComponent<SearchForSubject>().GetClosestSubject();
            if(target == null)
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
        if (Vector3.Distance(target.position, transform.position) <= maxDistanceFromEnemy)
        {
            moveSpeed = -speed;
        }
        else
        {
            moveSpeed = speed;
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(movement.x * moveSpeed * Time.fixedDeltaTime, movement.y * moveSpeed * Time.fixedDeltaTime);
    }
}
