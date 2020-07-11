using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public bool directionChanged = false;//The sandman script will get this value: true = grab the direction specified in globals, false = generate random
    public Direction direction = Direction.RIGHT;
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
