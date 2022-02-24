                                                                                                                                                                                    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintAreaX : MonoBehaviour
{
    public GameObject hitDialog;
    // Start is called before the first frame update 
    private void OnTriggerEnter2D(Collider2D other) {
       
       if(other.tag =="Player")
       {
        //    GloableParameters gloableParameters = new GloableParameters();
        if(Gloables.ifHintDialogX != true)
        {
           Vector2 vector2 = RubyController.instance.transform.position;
           GameObject HintDialog = Instantiate(hitDialog,vector2 + Vector2.up*1.0f,Quaternion.identity);
           HintDialog.GetComponent<HitDialog>().showHint("X");
           Gloables.ifHintDialogX = true;
        }
        else return;
       }
   }
}
