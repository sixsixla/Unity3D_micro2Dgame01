using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossArea : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hitDialog;
    public GameObject cubeGate1,cubeGate2;
    public GameObject BOSS;
    public GameObject BossHealthUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            if(Gloables.ifStartBoss != true)
        {
           Vector2 vector2 = RubyController.instance.transform.position;
           GameObject HintDialog = Instantiate(hitDialog,vector2 + Vector2.up*1.0f,Quaternion.identity);
           HintDialog.GetComponent<HitDialog>().showHint("BOSS");
           Gloables.ifStartBoss = true;
        }
        }
    }

    // /// <summary>
    // /// Sent when another object leaves a trigger collider attached to
    // /// this object (2D physics only).
    // /// </summary>
    // /// <param name="other">The other Collider2D involved in this collision.</param>
    // void OnTriggerExit2D(Collider2D other)
    // {
        
    //     // if(other.tag == "player")
    //     {     Debug.Log("我出来了");
    //         cubeGate1.SetActive(true);
    //         cubeGate2.SetActive(true);
    //         BOSS.SetActive(true);
    //         BossHealthUI.SetActive(true);
    //         GameObject.Find("MissionUI").GetComponent<MissionUI>().showMissionHint("mission3");
    //     }
    // }
}
