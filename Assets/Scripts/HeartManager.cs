using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartManager : MonoBehaviour
{
    public GameObject heart_1, heart_2, heart_3;

    public void InjureSandman()
    {
        if (heart_3.activeSelf)
            heart_3.SetActive(false);
        else if (heart_2.activeSelf)
            heart_2.SetActive(false);
        else if (heart_1.activeSelf)
        {
            heart_1.SetActive(false);


            SceneManager.LoadScene("menu");
        }
    }
}
