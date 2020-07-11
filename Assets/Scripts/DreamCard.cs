using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamCard : MonoBehaviour
{
    private Globals globals;
    private Image image;
    private Direction direction;

    public Sprite up, up_right, right, down_right, down, down_left, left, up_left, random;


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

        switch (rand)
        {
            case 0:
                image.sprite = up;
                break;
            case 1:
                image.sprite = up_right;
                break;
            case 2:
                image.sprite = right;
                break;
            case 3:
                image.sprite = down_right;
                break;
            case 4:
                image.sprite = down;
                break;
            case 5:
                image.sprite = down_left;
                break;
            case 6:
                image.sprite = left;
                break;
            case 7:
                image.sprite = up_left;
                break;
            case 8:
                image.sprite = random;
                break;
        }

        direction = (Direction)rand;
    }

    public void onClick()
    {
        globals.direction = direction;
        globals.directionChanged = true;

        Debug.Log(direction.ToString());
    }

    
}