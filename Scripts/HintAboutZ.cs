using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintAboutZ : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hitDialog;
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
        //    GloableParameters gloableParameters = new GloableParameters();
        if(Gloables.ifHintAboutZ != true)
        {
           Vector2 vector2 = RubyController.instance.transform.position;
           GameObject HintDialog = Instantiate(hitDialog,vector2 + Vector2.up*1.0f,Quaternion.identity);
           HintDialog.GetComponent<HitDialog>().showHint("Z");
           Gloables.ifHintAboutZ = true;
        }
    }
}
}
