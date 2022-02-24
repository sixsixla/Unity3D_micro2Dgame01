using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageArea : MonoBehaviour
{
    // Start is called before the first frame update// Start is called before the first frame update

    Rigidbody2D rigidbody2d;
    BoxCollider2D boxCollider2D;

    public float flyTime = 10.0f;
    public float leftFlyTime;
    // 设置无敌时间
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        flyTime -=Time.deltaTime;

        if (flyTime <= 0 )
        {
             rigidbody2d.velocity = Vector2.zero;
             boxCollider2D.isTrigger = true;
              
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        RubyController controller = other.gameObject.GetComponent<RubyController>();
        BossEnemy bossEnemy = other.gameObject.GetComponent<BossEnemy>();
        if(bossEnemy != null)
        {
            return;
        }

        if (controller != null)
        {
            controller.ChangeHealth(-1);
        }
        //我们还增加了调试日志来了解飞弹触碰到的对象
        Debug.Log("Projectile Collision with " + other.gameObject);
        // 碰撞后设置速度为0，并变为触发器
        rigidbody2d.velocity = Vector2.zero;
        boxCollider2D.isTrigger = true;
        // Destroy(gameObject);
    }

        void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController >();

        if (controller != null)
        {
            controller.ChangeHealth(-1);
        }
    }

}
