using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Globals : MonoBehaviour
{
    public bool directionChanged = false;//The sandman script will get this value: true = grab the direction specified in globals, false = generate random
    public Direction newDirection = Direction.RIGHT;
    public Direction currentDirection = Direction.RIGHT;

    public Sprite up, up_right, right, down_right, down, down_left, left, up_left, random;

    public Text timeTxt;
    public Text scoreTxt;

    public AudioSource audioPlayer;

    public DreamCardManager dcm;
    public HeartManager heartManager;

    public Grid gameGrid;

    private int score = 0;

    public float timeRemaining = 180;
    public bool timerIsRunning = false;

    public GameObject endNotif;
    public Text finalScore;

    public int Score { get { return score; } }

    private void Awake()
    {
        score = 0;
        scoreTxt.text = "0";

        timeTxt.text = "3:00";
        timerIsRunning = true;

        Time.timeScale = 1;
    }

    private void Update()
    {

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        if (timeRemaining <= 0)
        {
            if(PlayerPrefs.GetInt("Highscore") < score)
                PlayerPrefs.SetInt("Highscore", score);

            finalScore.text = "Total Points: " + score;
            Time.timeScale = 0;
            endNotif.SetActive(true);
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public Sprite GetSpriteBasedOnDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.UP:
                return up;
            case Direction.UP_RIGHT:
                return up_right;
            case Direction.RIGHT:
                return right;
            case Direction.DOWN_RIGHT:
                return down_right;
            case Direction.DOWN:
                return down;
            case Direction.DOWN_LEFT:
                return down_left;
            case Direction.LEFT:
                return left;
            case Direction.UP_LEFT:
                return up_left;
            case Direction.RANDOM:
                return random;
            default:
                return null;
        }
    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreTxt.text = this.score.ToString();
    }

    public void HurtSandman()
    {
        heartManager.InjureSandman();
    }

    public void PlaySound(AudioClip audio)
    {
        audioPlayer.clip = audio;
        audioPlayer.Play();
    }

}
public enum Direction
{
    UP,
    UP_RIGHT,
    RIGHT,
    DOWN_RIGHT,
    DOWN,
    DOWN_LEFT,
    LEFT,
    UP_LEFT,
    RANDOM
}