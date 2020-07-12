using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graveStone : MonoBehaviour
{
    private Globals globals;

    public int value;
    public AudioClip evilLaugh;

    // Start is called before the first frame update
    void Start()
    {
        globals = GameObject.Find("GLOBALS").GetComponent<Globals>();

        Invoke("Despawn", 40);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Sandman")
            return;

        globals.PlaySound(evilLaugh);
        globals.HurtSandman();

        //Despawn animation
        Despawn();
    }

    void Despawn()
    {
        Destroy(gameObject);
    }
}
