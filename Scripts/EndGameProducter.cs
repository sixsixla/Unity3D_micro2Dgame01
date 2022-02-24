using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; 
using UnityEngine.SceneManagement;

public class EndGameProducter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            string producter = "制作：sixsix(Z yt)\n\n资源：UnityHub， 网络";
         Text text = GetComponent<Text>();
         text.DOText(producter,2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
