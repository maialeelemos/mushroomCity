using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryNow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Victory()

    {
        Debug.Log("victoryCalled");
        Invoke("NowWait", 3f);
    }


    public void NowWait()
    {
        Debug.Log("waitWasCalled");
        PlayItAgain("PlayAgain");
    }

    public void PlayItAgain(string PlayAgain)
    {
        Debug.Log("PlayAgainCalled");
        SceneManager.LoadScene(PlayAgain);

    }


}
