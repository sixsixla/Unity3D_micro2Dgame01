using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntoBossRoomArea : MonoBehaviour
{
    
        public GameObject cubeGate1,cubeGate2,cubeGate3;
    public GameObject BOSS;
    public GameObject BossHealthUI;// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        void OnTriggerExit2D(Collider2D other)
    {
        
        if(other.tag == "Player")
        {     Debug.Log("我出来了");
            cubeGate1.SetActive(true);
            cubeGate2.SetActive(true);
            cubeGate3.SetActive(true);
            BOSS.SetActive(true);
            BossHealthUI.SetActive(true);
            GameObject.Find("MissionUI").GetComponent<MissionUI>().showMissionHint("mission3");
            Gloables.ifInBOSSing = true;
            GameObject.Find("BackgroundMusic").GetComponent<BackMusicEnd>().setBackgroundMusic("MusicBoss");
        }
    }
}
