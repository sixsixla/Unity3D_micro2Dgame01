using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFromBoss : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rigidbody2d;
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
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
        Destroy(gameObject);
    }

}
