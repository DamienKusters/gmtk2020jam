using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamCardManager : MonoBehaviour
{
    private Globals globals;
    private bool[] slotRecord;

    public GameObject slot_1, slot_2, slot_3;
    public GameObject DreamCardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        globals = GameObject.Find("GLOBALS").GetComponent<Globals>();
        AddDreamCard();//Debug?
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDreamCard()
    {
        if(slot_1.transform.childCount <= 0)
            Instantiate(DreamCardPrefab, slot_1.transform);
        else if (slot_2.transform.childCount <= 0)
            Instantiate(DreamCardPrefab, slot_2.transform);
        else if (slot_3.transform.childCount <= 0)
            Instantiate(DreamCardPrefab, slot_3.transform);
    }
}
