using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoyVidioDialog2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void restartScene()
    {
        // ScoreTextScript.coinAmount = 0;
        SceneManager.LoadScene("GirlLVidioDialog3");
    //    SceneManager.UnloadScene("GirlVidioDialog2")
    }
}
