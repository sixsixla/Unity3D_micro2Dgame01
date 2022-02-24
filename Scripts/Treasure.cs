using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject hitDialog;
   public GameObject Strawberry;
   public GameObject treasure;
 
 private void Update() 
 {
      // if (Input.GetKeyDown(KeyCode.X));
      // OnTriggerStay2D(RubyController);
      
 }
   private void OnTriggerStay2D(Collider2D other){
     if(other.tag == "Player")
     {   
        Debug.Log("进入了宝箱区域");
         if (Input.GetKeyDown(KeyCode.X))
         {
             
            //  //获得钥匙
            //  if(Gloables.TreasureKey == 0)
        // {
        //    Vector2 vector2 = RubyController.instance.transform.position;
        //    GameObject HintDialog = Instantiate(hitDialog,vector2 + Vector2.up*1.0f,Quaternion.identity);
        //    HintDialog.GetComponent<HitDialog>().showHint("Key");
        //    Gloables.TreasureKey = 1;
        // }
           Debug.Log("你开了个宝箱");
             for(int i =1;i<3;i++)
             {   Vector2 vector2 = transform.position;
                 Instantiate(Strawberry,vector2+Vector2.up*i*1.0f ,Quaternion.identity);
                 Instantiate(Strawberry,vector2+Vector2.left*i*1.0f ,Quaternion.identity);
                 Instantiate(Strawberry,vector2+Vector2.right*i*1.0f ,Quaternion.identity);
             }

             Destroy(treasure);
         }
     }
 }
 
}
