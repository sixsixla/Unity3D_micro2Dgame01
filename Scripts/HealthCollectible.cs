using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{

    public AudioClip collectedClip;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Object that entered the trigger : " + other);
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
                //    GameObject projectileObject = Instantiate(healthEffect, controller.position + Vector2.down * 0.5f, Quaternion.identity);

                controller.PlaySound(collectedClip);
                //    播放音频
            }
            else if(controller.health == controller.maxHealth)
            {
                GameObject BackpackUI = GameObject.Find("BackpackUI");
                BackpackUI.GetComponent<BackpackUI>().showStrawberrydNum(1);
                Destroy(gameObject);
            }
        }
    }
}
