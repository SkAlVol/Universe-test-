using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;  // Скорость передвижения объекта
    public Transform cameraTransform; // Камера, которая будет следовать за объектом
    public Vector3 cameraOffset;     // Смещение камеры относительно объекта
    public float lookSpeed = 2.0f;   // Скорость вращения камеры

    private float yaw = 0.0f;        // Вращение по оси Y
    private float pitch = 0.0f;      // Вращение по оси X

    void Start()
    {
        // Задаем начальное смещение камеры относительно объекта
        if (cameraTransform != null)
        {
            cameraOffset = cameraTransform.position - transform.position;
        }

        // Отключаем блокировку курсора, чтобы была возможность вращать камеру мышкой
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Управление движением объекта с помощью клавиш W, A, S, D
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // A, D
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;     // W, S

        // Перемещаем объект вперед/назад/влево/вправо
        Vector3 move = transform.forward * vertical + transform.right * horizontal;
        transform.position += move;

        // Свободное вращение камеры с помощью мыши
        yaw += Input.GetAxis("Mouse X") * lookSpeed;
        pitch -= Input.GetAxis("Mouse Y") * lookSpeed;

        // Ограничение угла вращения по оси X (чтобы не было переворота камеры)
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        // Вращение камеры по осям Y и X
        cameraTransform.rotation = Quaternion.Euler(pitch, yaw, 0.0f);

        // Обновляем позицию камеры с учетом движения объекта
        if (cameraTransform != null)
        {
            cameraTransform.position = transform.position + cameraOffset;
        }
    }
}
