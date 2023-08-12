using UnityEngine;

public class EnemyDestroyOnHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, если столкнувшийся объект является снарядом
        PlayerBullet playerBullet = collision.collider.GetComponent<PlayerBullet>();
        if (playerBullet != null)
        {
            // Уничтожаем врага и снаряд
            Destroy(gameObject);
            Destroy(playerBullet.gameObject);
        }
    }
}