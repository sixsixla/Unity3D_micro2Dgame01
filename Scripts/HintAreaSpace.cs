                                                                                                                                                                                    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintAreaSpace : MonoBehaviour
{
    public GameObject hitDialogX;
    // Start is called before the first frame update 
    private void OnTriggerEnter2D(Collider2D other) {
       
       if(other.tag =="Player")
       {
        //    GloableParameters gloableParameters = new GloableParameters();
        if(Gloables.ifHintDialogSpace != true)
        {
           Vector2 vector2 = RubyController.instance.transform.position;
        //    Vector2 vector2this;
        //    vector2this.x = vector3.x;
        //    vector2this.y = vector3.y;
           GameObject HintDialog = Instantiate(hitDialogX,vector2 + Vector2.up*1.0f,Quaternion.identity);
           HintDialog.GetComponent<HitDialog>().showHint("Space");
           Gloables.ifHintDialogSpace = true;
        }
        else return;
       }
   }
}
