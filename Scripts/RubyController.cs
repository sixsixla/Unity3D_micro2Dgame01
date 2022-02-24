using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RubyController : MonoBehaviour
{

    //设置主角为单例模式
    public static RubyController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
    }

    //进入新场景的密码
    public string ScenePasswrod;
    public float speed = 3.0f;

    public int maxHealth = 5;
    public float timeInvincible = 2.0f;
    // 设置无敌时间

    public GameObject projectilePrefab;
    // 设置gameobject变量用于存放飞弹的预制件

    public ParticleSystem healthEffect;
    // 存放例子特效

    public int health { get { return currentHealth; } }
    int currentHealth;

    public AudioClip shootClip, FootStepClip, HurtClip;
    // 存放发射齿轮的音频

    bool isInvincible;
    // 布尔类型，默认为TURE，表示是否处于无敌
    float invincibleTimer;
    // 剩余的无敌时间

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    Animator animator;
    // 动画变量
    Vector2 lookDirection = new Vector2(1, 0);
    // 观察方向（角色静止时面向哪个方向）的变量

    AudioSource audioSource, audioSourceFoot;
    // 音频私有变量
    // Vector2 ReburnPosition;
    // // 存储重生点位置

    public GameObject ChangeMask;
    public GameObject ReburnTree0, ReburnTree1, ReburnTree2;
    // 存储重生点位置
    // 在第一次帧更新之前调用 Start
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // currentHealth = maxHealth;
        currentHealth = Gloables.RubyHealth;
        Debug.Log("现在的血量是" + currentHealth);
        // ChangeHealth(0);
        // UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
        Transform transform = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
        // 获取音频组件


        // ReburnPosition = rigidbody2d.position;
    }

    // 播放音频的方法
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    // //  死亡后重生
    // public void Reburn(ref Vector2 position)
    // {
    //      position = ReburnPosition;
    //      ChangeHealth(5);

    // }

    // 每帧调用一次 Update
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // 如果无敌，计算剩余无敌时间，如果无敌时间变负，修改无敌状态
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }
        // 按住空格为跑动，速度翻倍
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed *= 2;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            speed /= 2;
        }

        // 对话模块
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                // Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                }
            }
        }

        //有草莓时，按Z消耗一个草莓回血
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (Gloables.StrawberryNum > 0 && currentHealth < maxHealth)
            {
                ChangeHealth(1);
                Instantiate(healthEffect, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
                GameObject BackpackUI = GameObject.Find("BackpackUI");
                BackpackUI.GetComponent<BackpackUI>().showStrawberrydNum(-1);

            }
        }


        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        //  如果血少于0,重新加载当前场景
        if (currentHealth <= 0)
        {
            //   ChangeMask.GetComponent<ChangeMask>().changeAlpha();
            if (Gloables.ifStartBoss == true)
            {
                GameObject gameObject = GameObject.Find("BackgroundMusic");
                Destroy(gameObject);
                Gloables.ifGmaeClear = false;
                SceneManager.LoadScene("BossScene");

                // transform.position = ReburnTree2.transform.position;
                Invoke("changePosition", 1.0f);


                Debug.Log("被BOSS打死了");
                //  ChangeMask.SetActive(true);

                //   Invoke("LoadBossScene",2.0f);
                // void LoadBossScene()
                // {   
                //  SceneManager.LoadScene("SampleScene"); 
                // }
            }
            else if (Gloables.ifIntoMainScene == true)
            {
                ChangeMask.GetComponent<ChangeMask>().changeAlpha();
                //调用黑屏动画
                transform.position = ReburnTree1.transform.position;
            }
            else
            {
                ChangeMask.GetComponent<ChangeMask>().changeAlpha();
                transform.position = ReburnTree0.transform.position;
            }
            ChangeHealth(5);
        }

    }

    void changePosition()
    {
        transform.position = ReburnTree2.transform.position;
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);

        // 播放脚步声
        // Debug.Log(horizontal);
        if (horizontal != 0 || vertical != 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
            // 播放受伤音效
            PlaySound(HurtClip);
        }
        else
        {
            Instantiate(healthEffect, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log("ruby health" + currentHealth + "/" + maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
        Gloables.RubyHealth = currentHealth;


    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
        Debug.Log("主角的发射方向" + lookDirection);
        PlaySound(shootClip);
        // 播放发射音乐
        animator.SetTrigger("Launch");
    }
}

