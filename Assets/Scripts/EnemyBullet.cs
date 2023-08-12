using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _enemyBulletSpeed; // Скорость снаряда
    private Rigidbody _enemyBulletRigidbody; // Кэшированный компонент Rigidbody пули
    private Transform _enemyBulletTransform; // Кэшированный компонент Transform объекта

    private void Awake()
    {
        // Получаем и кэшируем компоненты Rigidbody и Transform
        _enemyBulletRigidbody = GetComponent<Rigidbody>();
        _enemyBulletTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        // Задаем скорость пули в направлении ее верхней стороны
        _enemyBulletRigidbody.velocity = -_enemyBulletTransform.up * _enemyBulletSpeed;
    }

    private void Update()
    {
        // Получаем координату нижней границы экрана в мировых координатах
        float screenBottom = Camera.main.ViewportToWorldPoint(Vector3.zero).y;

        // Если снаряд вышел за границу экрана, уничтожаем его
        if (_enemyBulletTransform.position.y < screenBottom)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // При столкновении с другим объектом (игроком, стеной и т.д.) уничтожаем снаряд
        Destroy(gameObject);
    }
}