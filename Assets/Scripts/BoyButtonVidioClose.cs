using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoyButtonVidioClose : MonoBehaviour
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
        SceneManager.LoadScene("BoyVidio");
    }
}
