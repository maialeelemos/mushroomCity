using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKeyDown("y"))
        { 
            LoadGame("MainLevel");
        }
    }

    public void LoadGame(string MainLevel)
    {

        Debug.Log("sceneName to load: " + MainLevel);
        SceneManager.LoadScene(MainLevel);

    }

    
  

}
