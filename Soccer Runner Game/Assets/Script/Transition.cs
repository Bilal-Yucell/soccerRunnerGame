using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Transition: MonoBehaviour
{
    public void LoadFinalScene()
    {
        SceneManager.LoadScene("FinalScene");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
