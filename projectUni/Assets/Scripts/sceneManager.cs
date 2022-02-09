using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
public  void playGameButton()
    {
        SceneManager.LoadScene(1);
    }
    public void quitGameButton()
    {
        Application.Quit();
    }
}
