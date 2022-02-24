using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameButton : MonoBehaviour
{
    public GameObject EndGameText;
    public  GameObject Thanks;
    public GameObject producter;
      public GameObject ButtonRestart;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button> ();
		btn.onClick.AddListener (OnClick);
        string Thanks = "感谢游玩/n/n";
        string producter = "制作：sixsix/n/n资源：UnityHub， 网络";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
           EndGameText.SetActive(false);
           Thanks.SetActive(true);
           producter.SetActive(true);
           ButtonRestart.SetActive(true);

    }
}
