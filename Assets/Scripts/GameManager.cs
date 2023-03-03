using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Playables")]
    [SerializeField] private PlayerMove playerOne;
    [SerializeField] private PlayerMove playerTwo;
    [SerializeField] private Ball ball;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI playerOneScoreTxt;
    [SerializeField] private TextMeshProUGUI playerTwoScoreTxt;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject countDownPanel;

    private int playerOneScore = 0;
    private int playerTwoScore = 0;
    private int timer = 3;

    public AudioSource countSound;

    private void Start()
    {
        playerOneScore = 0;
        playerOneScoreTxt.text = playerOneScore.ToString();
        playerTwoScore = 0;
        playerTwoScoreTxt.text = playerTwoScore.ToString();
        StartCoroutine(CountDownTimer());
    }

    private void Update()
    {
        ResetGame();
        if(Input.GetKeyDown("q"))
        {
            Application.Quit();
            Debug.Log("Quit!");
        }
    }

    public void PlayerOneScored()
    {
        playerOneScore++;
        playerOneScoreTxt.text = playerOneScore.ToString();
        ResetPos();
    }

    public void PlayerTwoScored()
    {
        playerTwoScore++;
        playerTwoScoreTxt.text = playerTwoScore.ToString();
        ResetPos();
    }
    public void ResetPos()
    {
        playerOne.ResetStick();
        playerTwo.ResetStick();
        ball.ResetBall();
    }

    private void ResetGame()
    {
        if (playerOneScore == 10 || playerTwoScore == 10)
        {
            StartCoroutine(SceneReloader());
        }
    }

    private IEnumerator CountDownTimer()
    {
        Time.timeScale = 0f;
        countDownPanel.SetActive(true);
        while(timer > 0)
        {
            timerText.text = timer.ToString();
            timer--;
            yield return new WaitForSecondsRealtime(1f);
            countSound.Play();
        }
        Time.timeScale = 1f;
        countDownPanel.SetActive(false);
        yield return null;
    }

    private IEnumerator SceneReloader()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return null;

    }

}
