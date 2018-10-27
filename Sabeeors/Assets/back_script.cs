using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back_script : MonoBehaviour {

    public string web1;

 public void Back()
    {
        SceneManager.LoadScene("StartMenu");
    }
 public void Linkinternet(string name)
    {
        Application.OpenURL(name);
    }
   
}
