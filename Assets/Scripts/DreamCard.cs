using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamCard : MonoBehaviour
{
    private Globals globals;
    private Image image;
    private Direction direction;

    // Start is called before the first frame update
    void Start()
    {
        globals = GameObject.Find("GLOBALS").GetComponent<Globals>();

        image = gameObject.GetComponent<Image>();

        GenerateRandomDreamCard();
    }

    private void GenerateRandomDreamCard()
    {
        int rand = Random.Range(0, 9);

        direction = (Direction)rand;

        image.sprite = globals.GetSpriteBasedOnDirection(direction);
    }

    public void onClick()
    {
        globals.newDirection = direction;
        globals.directionChanged = true;

        //Todo: Play deflate sound.

        Destroy(gameObject);
    }

    
}