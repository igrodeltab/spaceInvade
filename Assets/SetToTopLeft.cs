using UnityEngine;

public class SetToTopLeft : MonoBehaviour
{
    [SerializeField] private float yOffset; // Сдвиг по вертикали относительно верхнего края

    private void Start()
    {
        // Получаем позицию левого верхнего угла экрана в экранных координатах
        Vector3 topLeftPosition = new Vector3(0, Screen.height, 0);

        // Преобразуем экранные координаты в мировые
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(topLeftPosition);

        // Применяем сдвиг по вертикали
        worldPosition.y += yOffset;

        // Устанавливаем X и Y координаты из мировых координат, а Z координату - 0
        transform.position = new Vector3(worldPosition.x, worldPosition.y, 0);
    }
}