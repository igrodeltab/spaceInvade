using UnityEngine;

public class EnemyMovementHandler : MonoBehaviour
{
    [SerializeField] private float _speed; // Скорость движения врагов
    [SerializeField] private float _dropDownDistance; // Расстояние перемещения вниз после достижения края экрана
    [SerializeField] private float _edgeOffset; // Отступ от края экрана

    private Vector3 _direction; // Текущее направление движения врагов
    private float _screenEdgeX; // Горизонтальная координата края экрана
    private EnemySpawner _enemySpawner; // Ссылка на скрипт EnemySpawner

    private void Start()
    {
        _enemySpawner = GetComponent<EnemySpawner>();
        _enemySpawner.SpawnEnemies(); // Создаем врагов
        _direction = Vector3.right; // Изначально двигаемся вправо

        float pixelsToUnits = Screen.height / Camera.main.orthographicSize;
        // Теперь pixelsToUnits представляет соотношение пикселей к мировым координатам в вашем проекте.

        // Рассчитываем горизонтальную координату края экрана
        _screenEdgeX = _direction.x > 0 ? (Screen.width / pixelsToUnits) - _edgeOffset : _edgeOffset;
    }

    private void Update()
    {
        MoveEnemies(); // Двигаем врагов

        if (AnyEnemyIsAtEdge()) // Проверяем, достигли ли края экрана
        {
            ChangeDirection(); // Меняем направление движения
        }
    }

    private void MoveEnemies()
    {
        transform.position += _direction * (_speed * Time.deltaTime);
    }

    private void ChangeDirection()
    {
        // Изменяем направление движения по горизонтали
        _direction = new Vector3(-_direction.x, 0f, 0f);
    }

    private bool AnyEnemyIsAtEdge()
    {
        // Проверяем, достиг ли какой-либо враг горизонтальной координаты края экрана
        foreach (Transform enemy in transform)
        {
            if (_direction.x > 0 && enemy.position.x > _screenEdgeX - _edgeOffset)
            {
                return true;
            }
            else if (_direction.x < 0 && enemy.position.x < -_screenEdgeX + _edgeOffset)
            {
                return true;
            }
        }
        return false;
    }
}