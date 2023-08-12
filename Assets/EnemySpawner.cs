using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab; // Префаб врага для создания
    [SerializeField] private int _rows; // Количество рядов врагов
    [SerializeField] private int _columns; // Количество столбцов врагов
    [SerializeField] private float _spacing; // Расстояние между врагами

    public EnemyDestroyOnHit[] enemies; // Массив для хранения созданных врагов

    public void SpawnEnemies()
    {
        enemies = new EnemyDestroyOnHit[_rows * _columns]; // Инициализируем массив для хранения врагов

        for (int row = 0; row < _rows; row++)
        {
            for (int column = 0; column < _columns; column++)
            {
                // Вычисляем позицию для создания врага
                Vector3 spawnPosition = transform.position + new Vector3(column * _spacing, row * -_spacing, 0f);

                // Создаем врага в указанной позиции и делаем его дочерним объектом для EnemyController
                GameObject enemyObject = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity, transform);
                EnemyDestroyOnHit enemyComponent = enemyObject.GetComponent<EnemyDestroyOnHit>();

                enemies[row * _columns + column] = enemyComponent; // Добавляем врага в массив
            }
        }
    }
}