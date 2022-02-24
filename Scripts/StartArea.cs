using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartArea : MonoBehaviour
{
    // Start is called before the first frame update 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("进入了开始区");
            GameObject.Find("BackgroundMusic").GetComponent<BackMusic>().setBackgroundMusic("Music1");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("出了开始区");
            GameObject.Find("BackgroundMusic").GetComponent<BackMusic>().setBackgroundMusic("Music2");
        }
    }
}
