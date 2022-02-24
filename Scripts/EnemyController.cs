using System.Collections;
using System.Collections.Generic;
using UnityEngine;

﻿public class EnemyController : MonoBehaviour
{
    public float speed =1;
    public bool vertical;
    public float changeTime = 1.0f;
    public ParticleSystem smokeEffect;

    public AudioClip Hitemeny;
    // 放音频
    
    //audiosource变量
   private AudioSource audioSource; 

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    bool broken = true;
    // 代表机器人是否损坏

    Animator animator;
  
    public GameObject projectilePrefab;
    // 设置gameobject变量用于存放飞弹的预制件
    
    // 在第一次帧更新之前调用 Start
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
       // 播放音频函数
    public void PlaySound(AudioClip clip)
    {
       audioSource.PlayOneShot(clip);
    }

    void Update()
    {   
        if(!broken)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    
    void FixedUpdate()
    {   
        if(!broken)
        {
            return;
        }

        Vector2 position = rigidbody2D.position;
        
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        
        rigidbody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController >();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
     
     public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;
         
        animator.SetTrigger("Fixed");
        // audioSource.PlayOneShot(Hitemeny);
        smokeEffect.Stop();
        // 停止烟雾
        audioSource.Stop();
        // 停止音乐
         GameObject missionUI = GameObject.Find("MissionUI");
         MissionUI mission = missionUI.GetComponent<MissionUI>();
         mission.showFixedNum(1);
    }

}
