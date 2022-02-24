using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; 
using UnityEngine.SceneManagement;
public class EndGmaeThanks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text text = GetComponent<Text>();
         text.DOFade(1, 2); //2秒时间让A值变为1
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
