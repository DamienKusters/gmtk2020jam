using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamCard : MonoBehaviour
{
    private Globals globals;
    private Image imageTexture;

    public Sprite[] DreamCardSprites;


    // Start is called before the first frame update
    void Start()
    {
        globals = GameObject.Find("GLOBALS").GetComponent<Globals>();

        imageTexture = gameObject.GetComponent<Image>();
        imageTexture.sprite = DreamCardSprites[GenerateRandomDreamCard()];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int GenerateRandomDreamCard()
    {
        return Random.Range(0, DreamCardSprites.Length);
    }

    public void onClick()
    {
        Debug.Log("Clicked");
    }
}
