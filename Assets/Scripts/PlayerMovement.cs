using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed; // Скорость движения игрока
    private Rigidbody _playerRigidbody; // Ссылка на компонент Rigidbody
    private float _leftBoundary; // Левая граница экрана
    private float _rightBoundary; // Правая граница экрана
    private float _horizontalInput; // Значение горизонтального ввода

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>(); // Получаем ссылку на компонент Rigidbody

        // Получаем ширину коллайдера игрока
        float objectWidth = GetComponent<Collider>().bounds.extents.x;

        // Вычисляем границы экрана
        _leftBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, _playerRigidbody.position.z)).x + objectWidth;
        _rightBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, _playerRigidbody.position.z)).x - objectWidth;
    }

    private void Update()
    {
        // Получаем горизонтальное ввод (стрелка влево или вправо)
        _horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        // Вычисляем новую позицию игрока, не выходящую за границы экрана
        float newPosX = Mathf.Clamp(_playerRigidbody.position.x + _horizontalInput * _moveSpeed * Time.fixedDeltaTime, _leftBoundary, _rightBoundary);

        // Применяем новую позицию к Rigidbody
        _playerRigidbody.position = new Vector3(newPosX, _playerRigidbody.position.y, _playerRigidbody.position.z);
    }
}