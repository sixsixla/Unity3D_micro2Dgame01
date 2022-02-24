using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MissionUI : MonoBehaviour
{
     public GameObject Text;
     public GameObject TextHint;
    void Update()
    {   
    }

    public  void showFixedNum(int i)
    {
       Gloables.FixedRobots += i;
       Text.GetComponent<Text>().text = "已修复的机器人:"+ Gloables.FixedRobots + "/30";
       if(Gloables.FixedRobots == Gloables.NeedFixedRobotsNum)
       {
           Text.GetComponent<Text>().fontSize = 13;
           TextHint.GetComponent<Text>().text = "任务完成！与NPC对话";

       }
       if(Gloables.ifInBOSSing == true)
       {
           Gloables.FixedInBOSSRoom += 1;
       }
    }
    public void showMissionHint(string about)
    {
         switch(about)
         {
             case "mission2":  TextHint.GetComponent<Text>().text = "前往小岛中心的城内";
             break;
             case "mission3": TextHint.GetComponent<Text>().text = "打败巨型机器人";
             break;
             case "missionEnd": TextHint.GetComponent<Text>().text = "前往巨大宝藏处";
             break;
            case "GameClear": TextHint.GetComponent<Text>().text = "恭喜你通关了，感谢游玩！";
             break;
         }
    }
}
