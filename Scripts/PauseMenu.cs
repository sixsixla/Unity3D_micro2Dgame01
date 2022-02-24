using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{   
    public bool isPause = false;
    public GameObject PauseUI;
     
    // Start is called before the first frame update
    void Start()
    {
        PauseUI.SetActive(false);
        isPause = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isPause == false)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {   
                PauseUI.SetActive(true);
                Time.timeScale = 0;
                isPause = true;
            }
        }
        else
        {
           if(Input.GetKeyDown(KeyCode.Escape))
           {
                PauseUI.SetActive(false);
                Time.timeScale = 1;
                isPause = false;
                Debug.Log("PauseUI disappear");
        
           }
        }
       
    }
}
