using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Menu2 : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
}
