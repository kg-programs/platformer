using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    public void quit()
    {
        Application.Quit(); 
    }
    public void tryAgain()
    {
        SceneManager.LoadScene("Scene1");
    }
}
