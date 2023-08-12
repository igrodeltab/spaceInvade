using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject _enemyBulletPrefab; // Префаб снаряда
    [SerializeField] private Transform _enemyShootPoint; // Точка, откуда вылетает снаряд
    [SerializeField] private float _shootInterval; // Интервал между выстрелами

    private float _shootTimer; // Таймер для отслеживания интервалов между выстрелами
    private PlayerMovement _playerMovement; // Ссылка на компонент движения игрока
    private RaycastHit _hitInfo; // Информация о столкновении

    private void Start()
    {
        _shootTimer = _shootInterval; // Начинаем с таймера, чтобы выстрел был доступен сразу

        _playerMovement = FindObjectOfType<PlayerMovement>(); // Находим компонент движения игрока
    }

    private void Update()
    {
        _shootTimer -= Time.deltaTime; // Уменьшаем таймер

        if (_shootTimer <= 0f)
        {
            Debug.Log("_shootTimer <= 0f : yes");
            Ray ray = new Ray(_enemyShootPoint.position, Vector3.down); // Создаем луч для определения столкновений

            // Проверяем столкновение вниз по направлению луча
            if (Physics.Raycast(_enemyShootPoint.position, Vector3.down, out _hitInfo, Mathf.Infinity))
            {
                Debug.Log("(Physics.Raycast(_enemyShootPoint.position, Vector3.down, out _hitInfo, Mathf.Infinity)) : yes");

                // Проверяем, что столкновение с врагом и игрок не находится снизу
                if (IsPlayer(_hitInfo.collider.gameObject))
                {
                    Debug.Log("(IsEnemy(_hitInfo.collider.gameObject)) : yes");
                    Shoot(); // Выстрел
                }
            }

            _shootTimer = _shootInterval; // Сбрасываем таймер
        }
    }

    // Проверяет, является ли объект врагом
    private bool IsPlayer(GameObject obj)
    {
        return obj.TryGetComponent(out PlayerMovement player);
    }

    // Создает снаряд в указанной точке
    private void Shoot()
    {
        Instantiate(_enemyBulletPrefab, _enemyShootPoint.position, Quaternion.identity);
    }
}