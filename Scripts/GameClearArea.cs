using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearArea : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MissionUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            if(Gloables.ifGmaeClear == true)
            {
                // GameObject.Find("MissionUI").GetComponent<MissionUI>().showMissionHint("GameClear");
                MissionUI.GetComponent<MissionUI>().showMissionHint("GameClear");
                Debug.Log("恭喜通关了");
                SceneManager.LoadScene("EndScene");

            }
        }
    }
}
