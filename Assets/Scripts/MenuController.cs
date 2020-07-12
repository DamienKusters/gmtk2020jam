using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public Text highscoreText;
    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = "Previous Highscore: " + PlayerPrefs.GetInt("Highscore");
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
