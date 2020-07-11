using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Globals : MonoBehaviour
{
    public bool directionChanged = false;//The sandman script will get this value: true = grab the direction specified in globals, false = generate random
    public Direction newDirection = Direction.RIGHT;
    public Direction currentDirection = Direction.RIGHT;

    public Sprite up, up_right, right, down_right, down, down_left, left, up_left, random;

    public Text time;
    public Text score;

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
