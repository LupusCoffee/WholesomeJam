using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontalMovement;
    float verticalMovement;

    float speedAdjuster = 25f;
    float runSpeed;
    float groupSize;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        groupSize = this.gameObject.transform.GetChild(1).gameObject.GetComponent<GroupSizeChecker>().subjectsInInfluenceArea.Count;
        runSpeed = -groupSize+speedAdjuster; //y = -x + 25

        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontalMovement * runSpeed, verticalMovement * runSpeed);
    }
}
