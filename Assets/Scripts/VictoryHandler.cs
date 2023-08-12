using UnityEngine;

public class VictoryHandler : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner; // Массив всех врагов на сцене
    [SerializeField] private GameOverHandler _gameOverHandler; // Ссылка на скрипт управления поражением

    private bool _hasDisplayedVictory = false; // Флаг, определяющий, была ли показана победа

    private void Update()
    {
        if (!_hasDisplayedVictory && IsAllEnemiesDestroyed()) // Проверяем, не показывалась ли победа и все враги уничтожены
        {
            _gameOverHandler.ShowGameOver(true); // Вызываем метод для показа поражения
            _hasDisplayedVictory = true; // Устанавливаем флаг победы
        }
    }

    private bool IsAllEnemiesDestroyed()
    {
        foreach (EnemyDestroyOnHit enemies in _enemySpawner.enemies)
        {
            if (enemies != null)
            {
                return false;
            }
        }
        return true;
    }
}