using UnityEngine;

// Этот атрибут автоматически добавляет компонент Rigidbody, если его нет
[RequireComponent(typeof(Rigidbody))]
public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float _playerBulletSpeed; // Скорость пули
    private Rigidbody _playerBulletRigidbody; // Кэшированный компонент Rigidbody пули
    private Transform _playerBulletTransform; // Кэшированный компонент Transform объекта

    // Ссылка на объект PlayerShooting, который создал эту пулю
    public PlayerShooting Owner { get; set; }

    private void Awake()
    {
        // Получаем и кэшируем компоненты Rigidbody и Transform
        _playerBulletRigidbody = GetComponent<Rigidbody>();
        _playerBulletTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        // Задаем скорость пули в направлении ее верхней стороны
        _playerBulletRigidbody.velocity = _playerBulletTransform.up * _playerBulletSpeed;
    }

    // Метод для уничтожения пули
    private void DestroyBullet()
    {
        // Сбрасываем ссылку на эту пулю в объекте PlayerShooting
        Owner.ResetBullet();

        // Уничтожаем этот объект
        Destroy(gameObject);
    }

    // Вызывается, когда пуля сталкивается с другим объектом
    private void OnCollisionEnter(Collision collision)
    {
        // Уничтожаем пулю
        DestroyBullet();
    }

    private void OnTriggerEnter(Collider other)
    {
        // При столкновении с другим объектом (игроком, стеной и т.д.) уничтожаем снаряд
        DestroyBullet();
    }

    // Вызывается, когда пуля выходит за пределы области видимости камеры
    private void OnBecameInvisible()
    {
        // Уничтожаем пулю
        DestroyBullet();
    }
}