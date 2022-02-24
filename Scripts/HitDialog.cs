using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HitDialog : MonoBehaviour
{

    public float showTime = 4.0f;

    public GameObject Text;
    //存文字框
    private string Hintx = "靠近NPC后，按X可进行交互";
    private string HintC = "按C可发射飞行道具";
    private string HintSpace = "按住空格可加速";
    
    private string HintX= "地刺会扣血，草莓会回血,按Z可使用背包中的草莓";
    private string HintIntoPosionArea = "被严重污染的河流和土地，遍地都是毒蘑菇和垃圾。会降低移速并使人中毒，要小心探索";
    // Start is called before the first frame update
    private string HintGotoTreasure = "前面有个宝箱，靠近后按X";
    private string HintGetKey = "获得了钥匙！可以去建筑内了";
    private string HintStartBoss = "前有强大敌人，小心应对！";
    private string HintExitNoKey = "需要钥匙才能进入";
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        showTime -= Time.deltaTime;
        if (showTime <= 0)
        {
            DestroyImmediate(gameObject);
            Debug.Log("对话框被销毁了");
        }
    }

    public void showHint(string about)
    {
        Text text = Text.GetComponent<Text>();
        switch (about)
        {
            case "X":
                text.text = Hintx;
                text.fontSize = 30;
                break;
            case "C":
                text.text = HintC;
                text.fontSize = 30;
                break;
            case "Space":
                text.text = HintSpace;
                text.fontSize = 30;
                break;
            case "Poision":
                text.text = HintIntoPosionArea;
                break;
            case "Key":
                text.text = HintGetKey;
                break;
            case "Treasure":
                text.text = HintGotoTreasure;
                break;
            case "BOSS":
                text.text = HintStartBoss;
                text.fontSize = 30;
                break;
            case "Exit":
                text.text = HintExitNoKey;
                text.fontSize = 30;
                break;
            case "Z":
                text.text = HintX;
                text.fontSize = 25;
                break;
        }
    }
}
