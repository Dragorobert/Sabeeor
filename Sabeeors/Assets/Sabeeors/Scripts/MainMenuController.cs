using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public GameObject controls;
    bool active = true; //para que el primer click encienda
    
    public void Play()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void Controles()
    {
        controls.SetActive(active);
        active = !active;
    }
}
