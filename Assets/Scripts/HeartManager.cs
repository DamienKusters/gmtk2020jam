using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    private Globals globals;

    public GameObject heart_1, heart_2, heart_3;

    // Start is called before the first frame update
    void Start()
    {
        globals = GameObject.Find("GLOBALS").GetComponent<Globals>();
    }

    public void InjureSandman()
    {
        if (heart_3.activeSelf)
            heart_3.SetActive(false);
        else if (heart_2.activeSelf)
            heart_2.SetActive(false);
        else if (heart_1.activeSelf)
        {
            heart_1.SetActive(false);
            //TODO: GAME OVER
            Debug.Log("TODO: RIP sandman");
        }
    }
}
