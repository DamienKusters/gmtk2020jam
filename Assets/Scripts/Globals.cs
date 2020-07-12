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

    public DreamCardManager dcm;

    public Grid gameGrid;

    private int score = 0;
    private float timeLeft = 330.0f;

    private void Awake()
    {
        score = 0;
        scoreTxt.text = "0";

        timeTxt.text = "3:00";
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;

        string min = "", sec = "";
        int curr = (int)Mathf.Round(timeLeft);

        if (curr / 60 > 0)
        {
            curr = curr / 60;

            min = curr.ToString();sec = "help, i lost my sanity";
        }
        else
        {
            min = "0";
            sec = curr.ToString();
        }

        timeTxt.text = (min + ":" + sec).ToString();

        if (timeLeft < 0)
        {
            SceneManager.LoadScene("menu");
        }
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