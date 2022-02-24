using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintAreaPosion : MonoBehaviour
{
    public GameObject hitDialog;
    private void OnTriggerEnter2D(Collider2D other) {
       
       if(other.tag =="Player")
       {
    
        if(Gloables.ifHintDialogPosion != true)
        {
           Vector2 vector2 = RubyController.instance.transform.position;
           GameObject HintDialog = Instantiate(hitDialog,vector2 + Vector2.up*1.0f,Quaternion.identity);
           HintDialog.GetComponent<HitDialog>().showHint("Poision");
           Gloables.ifHintDialogPosion = true;
        }
        else return;
       }
   }
}
