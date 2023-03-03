using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ball;
    [SerializeField] private float speed = 10f;
    private float initVel;

    private void Start()
    {
        ResetBall();
    }

    public void LaunchBall()
    {
        float x = Random.Range(0, 2) == 0? -1:1; // 2 is not included
        float y = Random.Range(0, 2) == 0? -1:1;
        ball.velocity = new Vector2(speed * x, speed * y);
        initVel = ball.velocity.magnitude;
    }

    private void Update()
    {
        if(Input.GetKeyDown("r"))
        {
            ResetBall();
        }
    }

    private void FixedUpdate()
    {
        if(ball.velocity.magnitude > initVel)
        {
           ball.velocity = Vector2.ClampMagnitude(ball.velocity, initVel);
        }
        if(ball.velocity.magnitude < initVel)
        {
            ball.velocity = ball.velocity.normalized * initVel;
        }
    }
    public void ResetBall()
    {
        ball.transform.position = Vector3.zero;
        ball.velocity = Vector3.zero;
        Invoke(nameof(LaunchBall), 0.5f);
    }

    

}
