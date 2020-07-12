using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    public GameObject endNotif;
    public void onClick()
    {
        endNotif.SetActive(false);
        SceneManager.LoadScene("menu");
    }
}
