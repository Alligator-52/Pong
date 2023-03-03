using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public bool isPlayerOneGoal;
    public AudioSource goalSound;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ball"))
        {
            goalSound.Play();
            if(isPlayerOneGoal)
            {
                FindObjectOfType<GameManager>().PlayerTwoScored();
            }
            if(!isPlayerOneGoal)
            {
                FindObjectOfType<GameManager>().PlayerOneScored();
            }
        }
    }
}
