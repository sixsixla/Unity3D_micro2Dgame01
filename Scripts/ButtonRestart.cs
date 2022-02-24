using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonRestart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {

        GameObject gameObject = GameObject.Find("BackgroundMusic");
         Destroy(gameObject);
        SceneManager.LoadScene("StartScene");
    }
}
