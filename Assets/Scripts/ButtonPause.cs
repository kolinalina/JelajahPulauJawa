using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : MonoBehaviour
{
    public GameObject GamePause;
    public GameObject BtnPause;
    public GameObject GameOption;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void aktif()
    {
        Time.timeScale = 0;
        GamePause.SetActive(true);
        BtnPause.SetActive(false);
    }
    public void option()
    {
        GameOption.SetActive(true);
        GamePause.SetActive(false);
    }
    public void nonaktif()
    {
        Time.timeScale = 1;
        GamePause.SetActive(false);
        BtnPause.SetActive(true);
    }
    
}
