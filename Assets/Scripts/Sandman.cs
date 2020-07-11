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

    // Start is called before the first frame update
    void Start()
    {
        globals = GameObject.Find("GLOBALS").GetComponent<Globals>();

        dreamingStem = transform.GetChild(0).gameObject;
        currentDream = dreamingStem.transform.GetChild(0).GetComponent<SpriteRenderer>();
        dreamingStem.SetActive(false);

        InvokeRepeating("DetermineNextLocation", 5, 5);//Do this every [5] sec
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Moving animation to correct side

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

        isDreamingOfDirection = false;

        dreamingStem.SetActive(false);
    }
}
