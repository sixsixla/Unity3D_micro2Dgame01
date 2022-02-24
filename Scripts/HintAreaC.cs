                                                                                                                                                                                    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintAreaC : MonoBehaviour
{
    public GameObject hitDialog;
    // Start is called before the first frame update 
    private void OnTriggerEnter2D(Collider2D other) {
       
       if(other.tag =="Player")
       {
        //    GloableParameters gloableParameters = new GloableParameters();
        if(Gloables.ifHintDialogC != true)
        {
           Vector2 vector2 = RubyController.instance.transform.position;
           GameObject HintDialog = Instantiate(hitDialog,vector2 + Vector2.up*1.0f,Quaternion.identity);
           HintDialog.GetComponent<HitDialog>().showHint("C");
           Gloables.ifHintDialogC = true;
        }
        else return;
       }
   }
}
