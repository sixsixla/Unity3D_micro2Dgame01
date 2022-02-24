using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitArea : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EntranceArea;
    public GameObject hitDialog;
    public GameObject ChangeMask;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag =="Player")
        {    
            Debug.Log("我进入了大门区域");
            if(Gloables.TreasureKey != 0)
            {
               ChangeMask.GetComponent<ChangeMask>().changeAlpha();
            //    RubyController.instance.transform.position = EntranceArea.transform.position;
                 SceneManager.LoadScene("BossScene");
                 

            }
            else
            {
                 Vector2 vector2 = RubyController.instance.transform.position;
           GameObject HintDialog = Instantiate(hitDialog,vector2 + Vector2.up*1.0f,Quaternion.identity);
           HintDialog.GetComponent<HitDialog>().showHint("Exit");
          
            }
        }
    }
}
