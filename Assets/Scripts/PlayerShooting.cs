using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private PlayerBullet _playerBulletPrefab; // Префаб пули, который мы хотим создать
    [SerializeField] private Transform _playerShootPoint; // Точка, где пуля будет создаваться

    private PlayerBullet _currentBullet; // Текущая активная пуля
    private Transform _transform; // Кэшированный компонент Transform объекта

    private void Awake()
    {
        _transform = GetComponent<Transform>(); // Получаем и кэшируем компонент Transform
    }

    private void Update()
    {
        // Если игрок нажимает клавишу "Space" и в данный момент нет активных пуль, происходит выстрел
        if (Input.GetKeyDown(KeyCode.Space) && _currentBullet == null)
        {
            Shoot(); // Вызываем метод Shoot()
        }
    }

    // Метод для создания пули
    private void Shoot()
    {
        // Создаем новую пулю и сохраняем ссылку на нее
        _currentBullet = Instantiate(_playerBulletPrefab, _playerShootPoint.position, _transform.rotation);

        // Передаем ссылку на текущий объект PlayerShooting в пулю
        _currentBullet.Owner = this;
    }

    // Метод для сброса текущей пули (вызывается пулей при ее уничтожении)
    public void ResetBullet()
    {
        _currentBullet = null;
    }
}