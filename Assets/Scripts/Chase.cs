using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    Transform targetedEnemy;
    Rigidbody2D body;

    public float speedAdjuster = 0.5f;
    float speed;
    float moveSpeed;
    float groupSize;

    Vector2 movement;

    float maxDistanceFromEnemy = 10;


    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        moveSpeed = speed;
    }

    void Update()
    {
        groupSize = this.gameObject.transform.GetChild(1).gameObject.GetComponent<GroupSizeChecker>().subjectsInInfluenceArea.Count;
        speed = -0.08f*groupSize*speedAdjuster;

        targetedEnemy = this.gameObject.transform.GetChild(3).gameObject.GetComponent<StateMachine>().GetClosestEnemy();

        //move towards enemy
        Vector3 direction = targetedEnemy.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        body.rotation = angle;
        movement = direction;


        //keep distance
        if (Vector3.Distance(targetedEnemy.position, transform.position) <= maxDistanceFromEnemy)
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
        body.MovePosition((Vector2)transform.position + (movement * moveSpeed * Time.fixedDeltaTime));
    }
}
