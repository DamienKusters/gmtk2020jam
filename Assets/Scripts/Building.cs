using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    private Globals globals;

    public int value;

    // Start is called before the first frame update
    void Start()
    {
        globals = GameObject.Find("GLOBALS").GetComponent<Globals>();

        Invoke("Despawn", 30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Sandman")
            return;

        globals.AddScore(value);//Add score
        globals.dcm.AddDreamCard();

        //Despawn animation
        Despawn();
    }

    void Despawn()
    {
        Destroy(gameObject);
    }
}
