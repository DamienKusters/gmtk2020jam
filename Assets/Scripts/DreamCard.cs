using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamCard : MonoBehaviour
{
    public Sprite[] DreamCardSprites;

    private Image imageTexture;

    // Start is called before the first frame update
    void Start()
    {
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
}
