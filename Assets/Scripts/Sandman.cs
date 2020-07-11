using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandman : MonoBehaviour
{
    private Globals globals;
    private bool isDreamingOfDirection = false;
    private Direction dreamingDirection;

    private GameObject dreamingStem;
    private SpriteRenderer currentDream;

    public Animator animator;

    public float sandmanSpeed = 1.0f;
    public TileGenerator tileGenerator;

    // Start is called before the first frame update
    void Start()
    {
        globals = GameObject.Find("GLOBALS").GetComponent<Globals>();

        dreamingStem = transform.GetChild(0).gameObject;
        currentDream = dreamingStem.transform.GetChild(0).GetComponent<SpriteRenderer>();
        dreamingStem.SetActive(false);

        InvokeRepeating("DetermineNextLocation", 5, 5);//Do this every [5] sec
        tileGenerator.CreateTileInRequiredDirections();
    }

    // Update is called once per frame
    void Update()
    {


        if (globals.currentDirection == Direction.UP)
        {
            //Set new Coordinate and Update
            HandleMovementForSandman(globals.currentDirection);

            //Ensure correct animation plays
            animator.SetBool("IsForward", false);
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsRight", false);
        }
        else if(globals.currentDirection == Direction.RIGHT || globals.currentDirection == Direction.UP_RIGHT || globals.currentDirection == Direction.DOWN_RIGHT)
        {
            //Set new Coordinate and Update
            HandleMovementForSandman(globals.currentDirection);

            //Ensure correct animation plays
            animator.SetBool("IsForward", false);
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsRight", true);
        }
        else if (globals.currentDirection == Direction.LEFT || globals.currentDirection == Direction.UP_LEFT || globals.currentDirection == Direction.DOWN_LEFT)
        {
            //Set new Coordinate and Update
            HandleMovementForSandman(globals.currentDirection);

            //Ensure correct animation plays
            animator.SetBool("IsForward", false);
            animator.SetBool("IsLeft", true);
            animator.SetBool("IsRight", false);
        }
        else
        {
            //Set new Coordinate and Update
            HandleMovementForSandman(globals.currentDirection);

            //Ensure correct animation plays
            animator.SetBool("IsForward", true);
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsRight", false);
        }


        globals.score.text = globals.currentDirection.ToString();//DEBUG

        if (globals.directionChanged)//If player has manipulated his dream
        {
            if (!isDreamingOfDirection)
                DetermineNextLocation();
            isDreamingOfDirection = true;

            if (globals.newDirection == Direction.RANDOM)
                dreamingDirection = (Direction)Random.Range(0, 8);
            else
                dreamingDirection = globals.newDirection;

            Debug.Log("......Sandman's dream is changed: " + dreamingDirection);
            currentDream.sprite = globals.GetSpriteBasedOnDirection(dreamingDirection);

            globals.directionChanged = false;//Reset the flag
        }
    }

    void DetermineNextLocation()
    {
        //Cancel if sandman is already thinking about a dream
        if (isDreamingOfDirection)
            return;

        isDreamingOfDirection = true;

        dreamingStem.SetActive(true);

        dreamingDirection = (Direction)Random.Range(0, 8);

        currentDream.sprite = globals.GetSpriteBasedOnDirection(dreamingDirection);

        Debug.Log("......Sandman is dreaming of: " + dreamingDirection);

        StartCoroutine(WaitForARandomAmountOfTime());//Waits a random amount of time before Sandman will change direction
    }

    IEnumerator WaitForARandomAmountOfTime()
    {
        yield return new WaitForSeconds(Random.Range(4, 8));//TODO: Edit randoms

        globals.currentDirection = dreamingDirection;//Change direction
        tileGenerator.CreateTileInRequiredDirections();

        isDreamingOfDirection = false;

        dreamingStem.SetActive(false);
    }

    void HandleMovementForSandman(Direction currentDirection)
    {
        switch (currentDirection)
        {
            case Direction.UP:
                transform.position += Vector3.up * sandmanSpeed * Time.deltaTime;
                break;
            case Direction.UP_RIGHT:
                transform.position += Vector3.up * sandmanSpeed * Time.deltaTime;
                transform.position += Vector3.right * sandmanSpeed * Time.deltaTime;
                break;
            case Direction.RIGHT:
                transform.position += Vector3.right * sandmanSpeed * Time.deltaTime;
                break;
            case Direction.DOWN_RIGHT:
                transform.position += Vector3.right * sandmanSpeed * Time.deltaTime;
                transform.position += Vector3.down * sandmanSpeed * Time.deltaTime;
                break;
            case Direction.DOWN:
                transform.position += Vector3.down * sandmanSpeed * Time.deltaTime;
                break;
            case Direction.DOWN_LEFT:
                transform.position += Vector3.down * sandmanSpeed * Time.deltaTime;
                transform.position += Vector3.left * sandmanSpeed * Time.deltaTime;
                break;
            case Direction.LEFT:
                transform.position += Vector3.left * sandmanSpeed * Time.deltaTime;
                break;
            case Direction.UP_LEFT:
                transform.position += Vector3.left * sandmanSpeed * Time.deltaTime;
                transform.position += Vector3.up * sandmanSpeed * Time.deltaTime;
                break;
            case Direction.RANDOM:
                break;
            default:
                break;
        }
    }
}
