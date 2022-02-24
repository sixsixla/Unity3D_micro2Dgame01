using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; 
using UnityEngine.SceneManagement;
public class EndGameText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
           Text text = GetComponent<Text>();
    string Introduce = "打败巨型机器人后，卢比从巨大宝箱中找到了尘封已久的机械核心，也看到了金属岛不为人知的过去。\n金属岛本是一个矿产丰富，科技发达的小岛。但常年的工业污染，让岛上生态急剧恶化。\n或许是神的诅咒，女王诞下了一名变异的婴儿，外观似青蛙。为了掩人耳目，女王将婴儿放在小岛边缘，派人悄悄抚养。\n为了救自己的孩子，女王执行了机械核心计划，企图凭借全岛的资源和智慧，研发出传说中能让人摆脱血肉苦痛，实现机械飞升的机械核心，以此让孩子能改变丑陋的外观。而岛上的人们，也都被这核心所能带来的利益诱惑了，全力投入计划之中。\n多年以后，当研究人员以为终于要成功时，意外发生了。\n机械核心发出强烈的紫光，将全岛所有渴望飞升的居民变成了低能的机械，只有在岛边缘毫不知情的女王之子，保持了原有的样子，成为了这场灾难的唯一见证者。";
    text.DOText( Introduce, 8); //5秒时间将这段文字逐字显示
    // text.DOColor(Color, 5); //颜色逐渐变绿
    //  Invoke("StartGame",5.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
