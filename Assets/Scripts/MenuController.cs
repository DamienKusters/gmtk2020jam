using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        SceneManager.LoadScene("game");
    }

    public void onClick_close()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
