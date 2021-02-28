using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
   
    // Start is called before the first frame update
   


    public void PlayGame()
    {
        Debug.Log("Play");
        UnityEngine.SceneManagement.SceneManager.LoadScene(1); //Main Game
    }

    public void Tutorial()
    {
        Debug.Log("Tutorial");
        UnityEngine.SceneManagement.SceneManager.LoadScene(2); //Main Game
    }

    public void Quit()
    {
        Application.Quit();
    }

}
