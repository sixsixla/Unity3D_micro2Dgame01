using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
     public void PlayGame()
     {
        //    GameObject gameObject = GameObject.Find("BackgroundMusic");
        //  Destroy(gameObject);
          SceneManager.LoadScene("IntroduceScene");
       

     }
     public void QuitGame()
     {
         Application.Quit();
     }
     public void GoToSettingMenu()
     {
         SceneManager.LoadScene("SettingScene");
     }

      public void GoToMainMenu()
     {
         SceneManager.LoadScene("StartScene");
        //  PauseUI.SetActive(false);
         Time.timeScale = 1;
          GameObject gameObject = GameObject.Find("StartBgMusic");
         Destroy(gameObject);
        //  isPause = false;
     }
}
