using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameOverHandler _gameOverHandler; // Ссылка на скрипт управления поражением

    private void OnTriggerEnter(Collider other)
    {
        EnemyBullet bullet = other.GetComponent<EnemyBullet>(); // Получаем компонент снаряда врага

        if (bullet != null) // Если это снаряд врага
        {
            Die(); // Вызываем метод смерти
        }
    }

    private void Die()
    {
        _gameOverHandler.ShowGameOver(false); // Вызываем метод для показа поражения
        gameObject.SetActive(false); // Отключаем игрока
    }
}