using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resultText; // Ссылка на компонент текста для вывода сообщения о поражении
    [SerializeField] private TextMeshProUGUI _pressAnyKeyText; // Ссылка на компонент текста для вывода приглашения нажать любую клавишу
    [SerializeField] private int _resultTextPositionY; // Позиция по вертикали для текста поражения
    [SerializeField] private float _blinkInterval; // Интервал мерцания текста

    private bool _isGameOver = false; // Флаг, определяющий, было ли поражение
    private string _currentSceneName; // Имя текущей сцены
    private bool _isPressAnyKeyTextVisible = false; // Флаг для определения видимости текста "Press Any Key"
    [SerializeField] private float _blinkTimer = 0f; // Таймер для мерцания текста

    private void Start()
    {
        _currentSceneName = SceneManager.GetActiveScene().name; // Получаем имя текущей сцены
        _resultText.enabled = false; // Изначально текст поражения скрыт
        _pressAnyKeyText.enabled = false; // Изначально текст приглашения скрыт
    }

    private void Update()
    {
        if (_isGameOver)
        {
            _blinkTimer -= Time.deltaTime; // Уменьшаем таймер мерцания
            //Debug.Log("_blinkTimer = " + _blinkTimer);

            if (_blinkTimer <= 0f) // Если таймер закончился
            {
                _isPressAnyKeyTextVisible = !_isPressAnyKeyTextVisible; // Меняем состояние видимости
                _pressAnyKeyText.enabled = _isPressAnyKeyTextVisible; // Применяем видимость к тексту
                Debug.Log("_pressAnyKeyText.enabled = " + _pressAnyKeyText.enabled);

                _blinkTimer = _blinkInterval; // Сбрасываем таймер мерцания
                Debug.Log("_blinkTimer = _blinkInterval = " + _blinkTimer);
            }

            if (Input.GetKey(KeyCode.R)) // Если пользователь нажал клавишу
            {
                SceneManager.LoadScene(_currentSceneName); // Перезапускаем текущую сцену
            }
        }
    }

    public void ShowGameOver(bool isVictory)
    {
        _isGameOver = true; // Устанавливаем флаг завершения игры в true
        float resultTextPositionY;

        if (isVictory)
        {
            _resultText.SetText("You Win"); // Изменяем текст сообщения о победе с помощью метода SetText
            resultTextPositionY = _resultTextPositionY;
        }
        else
        {
            _resultText.SetText("You Lose"); // Изменяем текст сообщения о поражении с помощью метода SetText
            resultTextPositionY = -_resultTextPositionY;
        }

        _resultText.rectTransform.anchoredPosition = Vector3.zero + new Vector3(0, resultTextPositionY, 0);

        _resultText.enabled = true; // Показываем текст поражения
        _pressAnyKeyText.enabled = true; // Показываем текст приглашения нажать любую клавишу
    }
}