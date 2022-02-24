using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName;
    [SerializeField] private string newScenePassword;
   private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag =="Player")
       {    
        //    RubyController.instance.ScenePasswrod = newScenePassword;
        //    SceneManager.LoadScene(sceneName);   
        
        RubyController.instance.transform.position = transform.position * 3;

       }
   }
}
