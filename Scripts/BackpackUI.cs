using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackUI : MonoBehaviour
{
    // Start is called before the first frame update
     public GameObject Text,Text2;
    void Start()
    {
        Text.GetComponent<Text>().text = "草莓:"+ Gloables.StrawberryNum;
        if(Gloables.TreasureKey != 0)
        Text2.SetActive(true);
        Text2.GetComponent<Text>().text = "钥匙:" + Gloables.TreasureKey;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public  void showStrawberrydNum(int i)
    {
       Gloables.StrawberryNum += i;
       Text.GetComponent<Text>().text = "草莓:"+ Gloables.StrawberryNum;
    }

    public void showKey(int i )
    {
        Gloables.TreasureKey += i ;
        Text2.GetComponent<Text>().text = "钥匙:  " + Gloables.TreasureKey;
    }
}
