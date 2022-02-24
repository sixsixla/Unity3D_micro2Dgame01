using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; 
using UnityEngine.SceneManagement;

public class IntroduceSceneText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    
    Text text = GetComponent<Text>();
    string Introduce = "这是一个在大冒险家卢的名字还未响彻大陆时发生的故事。\n\n年轻的卢比在出海中遭遇海难，醒来时发现自己处在一个空无一人的小岛上，只有破损的机器不断发出吱吱的声响。从青蛙样的人口中，卢比得知了这小岛就是曾经举世闻名的金属岛。\n\n在这里，等待卢比的会是怎样的冒险呢？";
    text.DOText( Introduce, 5); //5秒时间将这段文字逐字显示
    text.DOColor(Color.green, 5); //颜色逐渐变绿
     Invoke("StartGame",5.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        GameObject gameObject = GameObject.Find("StartBgMusic");
         Destroy(gameObject);
        SceneManager.LoadScene("SampleScene");
    }

}
