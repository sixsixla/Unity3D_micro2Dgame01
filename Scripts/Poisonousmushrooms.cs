using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Poisonousmushrooms : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject StateTextUI;
    public GameObject StateUI;
    public bool IntoArea = false;
    public bool OutArea = false;
    public bool ifFirstPoision = true;
    public float IntoPoisonTime = 5.0f;
    public float LeftTime;
    public float TohealthTime;
    void Start()
    {
        LeftTime = IntoPoisonTime;
        TohealthTime = IntoPoisonTime;
    }

    // Update is called once per frame
    void Update()
    {
        // LeftTime -= Time.deltaTime;
        if (IntoArea == true)
        {
            LeftTime -= Time.deltaTime;
            TohealthTime -= Time.deltaTime;
            Debug.Log("回复的剩余时间" + TohealthTime);
            Debug.Log("扣血的剩余时间" + LeftTime);
            if (LeftTime < 0 && TohealthTime > 0)
            {
                Gloables.ifPoisoned = true;
                Debug.Log("第一次中毒");
                InPosioning();
            }
            if (TohealthTime < 0)
            {
                OutPosioning();
            }
        }

    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
          if (other.tag == "Player")
        {
            Debug.Log("我被减速了");
            RubyController.instance.speed = 1.5f;
            IntoArea = true;
            StateUI.SetActive(true);
            StateTextUI.GetComponent<Text>().text = "减速";
            GameObject.Find("BackgroundMusic").GetComponent<BackMusic>().setBackgroundMusic("Music3");
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
           
            // Debug.Log("扣血的剩余时间" + LeftTime);
            TohealthTime += Time.deltaTime;
            // Debug.Log("回复的剩余时间" + TohealthTime);

            // if (LeftTime < 0)
            // {
            //     Gloables.ifPoisoned = true;
            // }

            // if (Gloables.ifPoisoned == true)
            // {
            //     InPosioning(IntoPoisonTime);
            // }

        }
    }

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RubyController.instance.speed = 3.0f;
            if(Gloables.ifPoisoned == true)
            StateTextUI.GetComponent<Text>().text = "中毒";
            else 
            StateUI.SetActive(false);
            Debug.Log("速度恢复了");
            GameObject.Find("BackgroundMusic").GetComponent<BackMusic>().setBackgroundMusic("Music2");

        }
    }

    public void InPosioning()
    {
        // if (Gloables.ifPoisoned == true)
         
            // GameObject.Find("StateUI").SetActive(true);
         
             Debug.Log("Ruby中毒了");
       
        
        // if (LeftTime < 0)
        {
            RubyController ruby = GameObject.Find("ruby").GetComponent<RubyController>();
            ruby.ChangeHealth(-1);
            Debug.Log("Ruby中毒了");
            if(ifFirstPoision == true)
            {
             StateTextUI.GetComponent<Text>().text = "减速  中毒";
             ifFirstPoision = false;
            }
            LeftTime = IntoPoisonTime;
        }
    }

    public void OutPosioning()
    {
        Gloables.ifPoisoned = false;
        StateUI.SetActive(false);
        IntoArea = false;
        ifFirstPoision = true;
        LeftTime = IntoPoisonTime;
        TohealthTime = IntoPoisonTime;

    }

}
