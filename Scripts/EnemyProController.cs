using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProController : MonoBehaviour
{  
    public float speed;
    public bool vertical;
    public float changeTime = 1.0f;

    public float shootTime = 2.0f;
    float shootTimer;
    public ParticleSystem smokeEffect;

    public AudioClip Hitemeny;
    // 放音频

    //audiosource变量
    private AudioSource audioSource;

    Rigidbody2D rigidbody2d;
    float timer;
    int direction = 1;
    bool broken = true;
    // 代表机器人是否损坏

    Animator animator;
    GameObject ruby;


    public GameObject projectilePrefab;
    // 设置gameobject变量用于存放飞弹的预制件

    // 在第一次帧更新之前调用 Start
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        // GameObject ruby = GameObject.Find("ruby");
    }
    // 播放音频函数
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    void Update()
    {
        if (!broken)
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
        if (!broken)
        {
            return;
        }

        Vector2 position = GetComponent<Rigidbody2D>().position;

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

        GetComponent<Rigidbody2D>().MovePosition(position);
        
         GameObject ruby = GameObject.Find("ruby");
        //按发射时间间隔发射
        shootTimer -= Time.deltaTime;
        //判断是否在射程内
        if (CalculateDistance(ruby, position) < 15)
        {
            if (shootTimer < 0)
            {   
                Launch(DecideDireciton(ruby,position));
                //    Debug.Log("发射方向是:"+ DirectionPositon);
                shootTimer = shootTime;
                //    Debug.Log(Time.deltaTime);
            }
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
        Vector2 vector2 = ruby.transform.position;
        positionDirection = vector2 - thisposition;
        positionDirection.Normalize();

        return positionDirection;
    }

    //算与主角的距离
    public float CalculateDistance(GameObject ruby, Vector2 thisposition)
    {
        Vector2 vector2 = ruby.transform.position;
        float Distance = (vector2 - thisposition).sqrMagnitude;
        return Distance;
    }



    public void Fix()
    {
        broken = false;
        GetComponent<Rigidbody2D>().simulated = false;

        animator.SetTrigger("Fixed");
        audioSource.PlayOneShot(Hitemeny);
        smokeEffect.Stop();
        // 停止烟雾
        audioSource.Stop();
        // 停止音乐
        GameObject missionUI = GameObject.Find("MissionUI");
        MissionUI mission = missionUI.GetComponent<MissionUI>();
        mission.showFixedNum(1);
    }

    void Launch(Vector2 DirectionPositon)
    {
        GameObject projectileObject = Instantiate(projectilePrefab, GetComponent<Rigidbody2D>().position + Vector2.up * 0.5f, Quaternion.identity);

        AttackFromBoss attackFromBoss = projectileObject.GetComponent<AttackFromBoss>();

        attackFromBoss.Launch(DirectionPositon, 300);

        Debug.Log("shoot success");
        // PlaySound(shootClip);
        // 播放发射音乐
        //  animator.SetTrigger("Launch");
    }
    public void LaunchThis(Vector2 direction,float force)
    {
          rigidbody2d = GetComponent<Rigidbody2D>();
        // boxCollider2D = GetComponent<BoxCollider2D>();
          rigidbody2d.AddForce(direction * force);
          Debug.Log("机器人发射的方向"+ direction*force);
       
    }
}
