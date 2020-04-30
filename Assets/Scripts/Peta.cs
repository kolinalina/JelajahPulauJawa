using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Peta : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CharacterSelection()
    {
        //ScoreTextScript.coinAmount = 0;
        SceneManager.LoadScene("CharacterSelection");
    }

    public void Home()
    {
        //ScoreTextScript.coinAmount = 0;
        SceneManager.LoadScene("MainMenu");
    }

    public void Girl()
    {
        SceneManager.LoadScene("Peta");
    }
}
