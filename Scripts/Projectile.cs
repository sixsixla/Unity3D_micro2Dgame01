using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{    
    public ParticleSystem HitEffect;
    // 存放击中时的例子特效
    
    // 存放击中音效
    public AudioClip HitEmenyClip;
    AudioSource audioSource;
     
    
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        // audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force)
{
    rigidbody2d.AddForce(direction * force);
}

void OnCollisionEnter2D(Collision2D other)
   {
    //我们还增加了调试日志来了解飞弹触碰到的对象
    // Debug.Log("Projectile Collision with " + other.gameObject);
   EnemyController e = other.collider.GetComponent<EnemyController>();
   EnemyProController epro = other.collider.GetComponent<EnemyProController>();
   BossEnemy bossEnemy = other.gameObject.GetComponent<BossEnemy>();
        if (e != null)
        {   
            Instantiate(HitEffect, rigidbody2d.position, Quaternion.identity);
            e.Fix();
            e.PlaySound(HitEmenyClip);
        }
         if (epro != null)
        {   
            Instantiate(HitEffect, rigidbody2d.position, Quaternion.identity);
            epro.Fix();
            epro.PlaySound(HitEmenyClip);
        }

        
        // BOSS扣血
        if(bossEnemy != null){
            bossEnemy.ChangeHealth(-1);
        }
         
        Destroy(gameObject);
   }
}
