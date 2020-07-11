using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandman : MonoBehaviour
{
    private Globals globals;
    private bool isDreamingOfDirection = false;

    // Start is called before the first frame update
    void Start()
    {
        globals = GameObject.Find("GLOBALS").GetComponent<Globals>();

        InvokeRepeating("DetermineNextLocation", 5, 5);//Do this every [5] sec
    }

    // Update is called once per frame
    void Update()
    {
        //Moving animation to correct side

        globals.score.text = globals.currentDirection.ToString();

        //Change dreaming texture if user clicks on button
    }

    void DetermineNextLocation()
    {
        //Cancel if sandman is already thinking about 
        if (isDreamingOfDirection)
            return;

        isDreamingOfDirection = true;

        Debug.Log("......Sandman is dreaming of something");

        StartCoroutine(WaitForARandomAmountOfTime());//Waits a random amount of time before Sandman will change direction

        //TODO: SET TEXTURE OF WHAT HE IS THINKING ABOUT
    }

    IEnumerator WaitForARandomAmountOfTime()
    {
        yield return new WaitForSeconds(Random.Range(4, 8));//TODO: Edit randoms

        if (globals.directionChanged)//Use that direction
        {
            //TODO: If RANDOM, do RANDOM instead.

            globals.currentDirection = globals.newDirection;

            globals.directionChanged = false;//Reset the flag
        }
        else//RNG direction
        {
            globals.currentDirection = (Direction)Random.Range(0, 8);
        }

        isDreamingOfDirection = false;
    }
}
