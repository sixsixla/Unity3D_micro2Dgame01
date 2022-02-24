using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroduceSkipButton : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start() {
        Button btn = this.GetComponent<Button> ();
		btn.onClick.AddListener (OnClick);
    }
    public void OnClick()
    {
        
         GameObject gameObject = GameObject.Find("StartBgMusic");
         Destroy(gameObject);
        SceneManager.LoadScene("SampleScene");
        Debug.Log("点击了跳过");
    }

}
