using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D stick;
    [SerializeField] private bool isPlayerOne;
    [SerializeField] private float stickSpeed = 5f;
    private float movement;
    private Vector2 startPos;
    public AudioSource stickSound;

    private void Start()
    {
        stick = GetComponent<Rigidbody2D>();
        startPos = stick.transform.position;
    }

    private void Update()
    {
        if(isPlayerOne)
        {
            movement = Input.GetAxisRaw("Vertical");
        }
        if(!isPlayerOne)
        {
            movement = Input.GetAxisRaw("Vertical2");
        }
    }
    private void FixedUpdate()
    {
        stick.velocity = new Vector2(stick.velocity.x, stickSpeed * movement);
    }

    public void ResetStick()
    {
        stick.velocity = Vector2.zero;
        stick.transform.position = startPos;

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            stickSound.Play();
        }
    }
}
                                                                                                                                            