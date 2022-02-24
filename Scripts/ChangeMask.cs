using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; 
//引入命名空间

public class ChangeMask : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Image;
    void Start()
    {
        // gameObject.SetActive(true);
        //  Image.GetComponent<Image>().DOFade(1,0);
        Image.GetComponent<Image>().color = new Color(255,255,255,1);
        Invoke("Dochange",1.0f);
        //  Image.GetComponent<Image>().DOFade(1,2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeAlpha()
    {
        // DG.Tweening.DOTween.SetTweensCapacity(tweenersCapacity:2000, sequencesCapacity:2000);
       float KeepTime = 1.0f;
       float timer;
        var s = DOTween.Sequence();
        // Image image =  Image.GetComponent<Image>();
       Image.GetComponent<Image>().color = new Color(255,255,255,1);
       Invoke("Dochange",1.0f);
       
        // image.Alpha = 1;
        // s.Append(image.DOFade(0,2));
        // tweener.SetAutoKill(bool autoKillOnCompletion = true)
        // Image.GetComponent<Image>().DOFade(0,2);
    }
     void Dochange()
       {
         Image.GetComponent<Image>().DOFade(0,1);
       }
}
