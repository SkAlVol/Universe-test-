using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectController : MonoBehaviour
{
    public float jumpForce = 7.0f;            // Сила прыжка
    public float groundCheckDistance = 0.1f;  // Расстояние до земли для проверки
    public LayerMask groundLayer;             // Слой, представляющий землю

    private Rigidbody rb;                     // Ссылка на компонент Rigidbody
    private bool isGrounded;                  // Флаг, указывающий на то, что объект на земле

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Получаем компонент Rigidbody
    }

    void Update()
    {
        CheckGroundStatus();

        // Прыжок при нажатии пробела и если объект на земле
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void CheckGroundStatus()
    {
        // Проверка, находится ли объект на земле с использованием Raycast
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }

    private void Jump()
    {
        // Применяем импульс для прыжка
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Сбрасываем вертикальную скорость
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
