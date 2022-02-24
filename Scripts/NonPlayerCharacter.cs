using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 5.0f;
    // 显示时间
    public GameObject dialogBox;
    public GameObject Text;
    //NPC对话框
    // public Transform transform;
   
    public GameObject MissionUI;
    //显示已经修复的机器人个数的UI

    public GameObject KeyUI;
    //显示钥匙
    float timerDisplay;
    public string NPCDialog0, NPCDialog1,NPCDialog2,NPCDialog3;
    void Start()
    {
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
        // transform = GetComponent<Transform>();
        NPCDialog0 = "哇,是活人！我好久没见到活人了。以前这还是有很多人，但那一天后，大家都消失了，却多了许多吵闹的机器人，我想修好他们，但我太弱小了，你帮帮我吗？";
        NPCDialog1 = "你是冒险家吧，帮帮我吧，呜呜呜，修好它们，我就能进城找我的家人了";
        NPCDialog2 = "哇，太感谢你了，冒险家先生，你居然修好了这么多机器人。嗯，这是很久以前妈妈给我的进城钥匙，你拿着去城内吧。妈妈......";
        NPCDialog3 = "进城后，能帮我找找妈妈吗，妈妈好像是这的女王，但很小的时候我们就分开了。妈妈，我好想你......";
    }

    void Update()
    {
        if (timerDisplay >= 0)
        {   //倒计时
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;

        //根据任务状态显示不同的对话框
        if (Gloables.ifInMission == false)
        {
            Text.GetComponent<Text>().text = NPCDialog0;
            Debug.Log("显示不同的语言");
            Gloables.ifInMission = true;
            MissionUI.SetActive(true);

        }
        else if(Gloables.FixedRobots < Gloables.NeedFixedRobotsNum)
        {
            Text.GetComponent<Text>().text = NPCDialog1;
        }
        else if(Gloables.TreasureKey == 0)
        {
            Text.GetComponent<Text>().text = NPCDialog2;
            GameObject.Find("BackpackUI").GetComponent<BackpackUI>().showKey(1);
            KeyUI.SetActive(true);
            GameObject.Find("MissionUI").GetComponent<MissionUI>().showMissionHint("mission2");
        }
        else 
        {
            Text.GetComponent<Text>().text = NPCDialog3;
        }
         
        dialogBox.SetActive(true);



    }
}
