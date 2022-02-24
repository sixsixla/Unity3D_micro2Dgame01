using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintTreasure : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hitDialog;
    void Start()
    {
        
    }

    // Update is called once per frame
       private void OnTriggerEnter2D(Collider2D other) {
       
       if(other.tag =="Player")
       {
    
        if(Gloables.ifHintTreasure != true)
        {
           Vector2 vector2 = RubyController.instance.transform.position;
           GameObject HintDialog = Instantiate(hitDialog,vector2 + Vector2.up*1.0f,Quaternion.identity);
           HintDialog.GetComponent<HitDialog>().showHint("Treasure");
           Gloables.ifHintTreasure = true;
        }
        else return;
       }
   }
}
