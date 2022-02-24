using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossEnemy : MonoBehaviour
{
    public float speed = 2;
    public bool vertical;
    public float ShootTime = 2.0f;
    float timer;
    public ParticleSystem smokeEffect;

    public AudioClip Hitemeny;
    // 放音频

    public GameObject projectileFromBoss;
    // 设置gameobject变量用于存放飞行武器的预制件

    //二阶段时发射的路障
    public GameObject DamageArea;
    //路障
    public GameObject EnemyPro;

    public GameObject EndTressure;
    public GameObject GameClearArea;

    public GameObject BossHealthUI;

    //audiosource变量
    private AudioSource audioSource;

    Rigidbody2D rigidbody2D;

    // int direction = 1;
    // bool broken = true;
    // // 代表机器人是否损坏

    public int maxBossHealth = 30;

    public int health { get { return currentHealth; } }
    int currentHealth;
    public float timeInvincible = 1.0f;
    // 设置无敌时间
    bool isInvincible;
    // 布尔类型，默认为TURE，表示是否处于无敌
    //是否是二阶段
    bool isSecondStep = false;
    float invincibleTimer;
    // 剩余的无敌时间
    Animator animator;
    Transform transform;

    Vector2 DirectionPositon;
    //面朝的方向

    public int smallRobotsFromBoss = 4;
    // 在第一次帧更新之前调用 Start

    public GameObject backgroundMusic;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = ShootTime;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        currentHealth = maxBossHealth;
        transform = GetComponent<Transform>();
        // Vector2 positiontest;
        // positiontest.x = 1;
        // positiontest.y = 1;
        // // Launch(positiontest);
        smokeEffect.Stop();

    }
    // 播放音频函数
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    //通过主角位置判断行走方向
    public Vector2 DecideDireciton(GameObject ruby, Vector2 thisposition)
    {
        Vector2 positionDirection;
        // if (ruby.transform.position.y > thisposition.y + 0.5)
        // {
        //     positionDirection.y = 1;
        // }
        // else if (ruby.transform.position.y < thisposition.y - 0.5)
        //     positionDirection.y = -1;
        // else positionDirection.y = 0;

        // if (ruby.transform.position.x > thisposition.x + 0.5)
        // {
        //     positionDirection.x = 1;
        // }
        // else if (ruby.transform.position.x < thisposition.x - 0.5)
        //     positionDirection.x = -1;
        // else positionDirection.x = 0;
        Vector2 vector2;
        vector2.x = ruby.transform.position.x;
        vector2.y = ruby.transform.position.y;
        positionDirection = vector2 - thisposition;
        positionDirection.Normalize();

        return positionDirection;
    }

    void Update()
    {
        //     GameObject ruby = GameObject.Find("ruby");
        //     Vector2 position = rigidbody2D.position;
        //     Vector2 DirectionPositon = DecideDireciton(ruby, position);
        //     timer -= Time.deltaTime;

        //     if (timer < 0)
        //    {
        //        Launch(DirectionPositon);
        //        timer = ShootTime;
        //        Debug.Log(Time.deltaTime);
        //    }
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        if (currentHealth == 0 && Gloables.ifGmaeClear == false)
        {
            // Destroy(gameObject);
            Fix();
            // if(transform.FindChild())
            // if (Gloables.FixedInBOSSRoom == smallRobotsFromBoss)
            {
                GameObject.Find("MissionUI").GetComponent<MissionUI>().showMissionHint("missionEnd");
                Gloables.ifGmaeClear = true;
                EndTressure.SetActive(true);
                GameClearArea.SetActive(true);
                // GameObject.Find("BossHealthUI").SetActive(false);
                BossHealthUI.SetActive(false);
                GameObject.Find("BackgroundMusic").GetComponent<BackMusicEnd>().setBackgroundMusic("MusicEnd");


            }
        }

    }



    void FixedUpdate()
    {
        // if (!broken)
        // {
        //     return;
        // }
        GameObject ruby = GameObject.Find("ruby");
        Vector2 position = rigidbody2D.position;
        DirectionPositon = DecideDireciton(ruby, position);

        // if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * DirectionPositon.y;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", DirectionPositon.y);
        }
        // else
        {
            position.x = position.x + Time.deltaTime * speed * DirectionPositon.x;
            animator.SetFloat("Move X", DirectionPositon.x);
            animator.SetFloat("Move Y", 0);
        }

        rigidbody2D.MovePosition(position);
        //  Launch(DirectionPositon);
        //  if(Input.GetKeyDown(KeyCode.V))    
        timer -= Time.deltaTime;
        if (timer < 0 && currentHealth > 0)
        {
            Launch(DirectionPositon);
            //    Debug.Log("发射方向是:"+ DirectionPositon);
            timer = ShootTime;
            //    Debug.Log(Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }




    public void Fix()
    {
        //  broken = false;
        rigidbody2D.simulated = false;

        animator.SetTrigger("Fixed");
        // audioSource.PlayOneShot(Hitemeny);

        // 停止烟雾
        smokeEffect.Stop();
        audioSource.Stop();
        // 停止音乐

    }
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
            audioSource.PlayOneShot(Hitemeny);
            // 播放受伤音效
            // PlaySound(HurtClip);
        }
        // else
        // {
        //     Instantiate(healthEffect, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        // }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxBossHealth);
        Debug.Log("boss headlth:" + (float)currentHealth / (float)maxBossHealth);
        Debug.Log(currentHealth);
        BossUIhealthBar.instance.SetValue(currentHealth / (float)maxBossHealth);
        if (((float)currentHealth / (float)maxBossHealth) < 0.5 && !isSecondStep)
        // 半血后进入二阶段
        { //BossIntoSecondStep();
          //   Instantiate(smokeEffect, rigidbody2D.position + Vector2.up * 2.5f, Quaternion.identity,transform);
            BossIntoSecondStep(DirectionPositon);
            speed = speed * (float)1.5;
            ShootTime /= 2;
            isSecondStep = true;
            Debug.Log("BOSS半血了");
        }

    }

    public void BossIntoSecondStep(Vector2 DirectionPositon)
    {
        smokeEffect = Instantiate(smokeEffect, rigidbody2D.position + Vector2.up * 2.5f, Quaternion.identity, transform);
        Debug.Log("BOSS放烟雾了");

        System.Random rnd = new System.Random();
        //发射路障

        for (int i = 0; i < 7; i++)
        {
            GameObject projectile = Instantiate(DamageArea, rigidbody2D.position + Vector2.up * 2.5f, Quaternion.identity, transform);
            BossDamageArea damageArea = projectile.GetComponent<BossDamageArea>();
            Vector2 direction = new Vector2(rnd.Next(-100, 100), rnd.Next(-100, 100));
            Debug.Log("路障的方向是：" + direction);
            direction.Normalize();
            damageArea.Launch(direction, 400);
        }
        System.Random rnd1 = new System.Random();
        System.Random rnd2 = new System.Random();
         System.Random rnd3 = new System.Random();
        for (int i = 0; i < 5; i++)
        {
            GameObject projectile2 = Instantiate(EnemyPro, rigidbody2D.position + Vector2.up * 2.5f, Quaternion.identity);
            EnemyProController enemyPro = projectile2.GetComponent<EnemyProController>();
            Vector2 direction = new Vector2(rnd1.Next(-100, 100), rnd1.Next(-100, 100));
            direction.Normalize();
            //  Rigidbody2D Enemyprobody = projectile.GetComponent<Rigidbody2D>();
            //  Enemyprobody.AddForce(direction*300);
            enemyPro.LaunchThis(direction, 10000);
            enemyPro.vertical = (rnd2.NextDouble() > 0.5);
            Debug.Log("是否垂直："+ rnd2.NextDouble());
            enemyPro.speed = rnd3.Next(3,6);
            // Debug.Log("机器人发射的方向是：" + direction * 3000);
        }
        // for(int i=1;i <3;i++)
        {
            //创建小兵
            // Instantiate(EnemyPro,rigidbody2D.position+Vector2.left*5.0f,Quaternion.identity);
            //   //创建小兵
            // Instantiate(EnemyPro,rigidbody2D.position+Vector2.right*4.0f,Quaternion.identity);
            //   //创建小兵
            // Instantiate(EnemyPro,rigidbody2D.position+Vector2.up*5.0f,Quaternion.identity);
            //   //创建小兵
            // Instantiate(EnemyPro,rigidbody2D.position+Vector2.down*4.0f,Quaternion.identity);
        }

    }

    void Launch(Vector2 DirectionPositon)
    {
        GameObject projectileObject = Instantiate(projectileFromBoss, rigidbody2D.position, Quaternion.identity);

        AttackFromBoss attackFromBoss = projectileObject.GetComponent<AttackFromBoss>();

        attackFromBoss.Launch(DirectionPositon, 300);

        Debug.Log("shoot success");
        // PlaySound(shootClip);
        // 播放发射音乐
        //  animator.SetTrigger("Launch");
    }


}
