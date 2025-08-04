using UnityEngine;

public class VacantEyeBullet : MonoBehaviour
{
   public Vector3 direction;
   public float speed = 5f;
   
   private void Start()
   {
       Destroy(gameObject, 5f); // 5秒后销毁子弹
   }
    private void Update()
    {
         transform.position += direction * speed * Time.deltaTime;
    }
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized; // 设置方向并归一化
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 处理与玩家的碰撞
            Destroy(gameObject); // 销毁子弹
        }
        else if (other.CompareTag("Wall"))
        {
            // 处理与墙壁的碰撞
            Destroy(gameObject); // 销毁子弹
        }
    }
}
