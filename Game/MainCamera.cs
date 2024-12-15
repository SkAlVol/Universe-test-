using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AttachedCameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private Vector3 initialOffset; // Исходное смещение камеры
    public float moveSpeed = 10.0f;
    public float lookSpeed = 2.0f;
    private bool cursorLocked = true;
    private bool cameraFixed = false; // Флаг для фиксации камеры
    private Quaternion cameraRotation;
    public Button pauseButton;
    public Button toggleButton;
    private bool isPaused = false;
    private bool isButtonVisible = false;
    public float minY = -10f;
    public float maxY = 10f;
    public float playerSpeed = 5.0f;
    public float jumpForce = 5.0f;
    private Rigidbody targetRigidbody;
    public int maxJumps = 2;
    private int currentJumps;
    private bool isGrounded = false;

    private Vector3 fixedPosition; // Сохранённая позиция камеры

    void Start()
    {
        if (target != null)
        {
            offset = transform.position - target.position;
            initialOffset = offset; // Сохраняем исходное смещение
            targetRigidbody = target.GetComponent<Rigidbody>();
        }

        LockCursor(true);
        cameraRotation = transform.rotation;

        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(TogglePause);
        }

        if (toggleButton != null)
        {
            toggleButton.gameObject.SetActive(false);
        }

        currentJumps = maxJumps;
        isGrounded = false;
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ToggleCameraLock(); // Переключаем фиксацию камеры
            ToggleButtonVisibility(); // Переключаем видимость UI
        }

        if (!cameraFixed && target != null && cursorLocked && !isPaused)
        {
            transform.position = target.position + offset;

            float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
            float mouseY = -Input.GetAxis("Mouse Y") * lookSpeed;

            transform.RotateAround(target.position, Vector3.up, mouseX);
            transform.RotateAround(target.position, transform.right, mouseY);

            offset = transform.position - target.position; // Обновляем смещение
        }
        else if (cameraFixed)
        {
            // Удерживаем фиксированную позицию
            transform.position = fixedPosition;
        }

        if (Input.GetKey(KeyCode.Q)) // Перемещение вверх
        {
            MoveTargetVertically(1.0f * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey(KeyCode.E)) // Перемещение вниз
        {
            MoveTargetVertically(-1.0f * Time.deltaTime * moveSpeed);
        }

        if (!isPaused)
        {
            HandleMovement();
        }
    }

    private void ToggleCameraLock()
    {
        cameraFixed = !cameraFixed; // Переключаем состояние фиксации камеры

        if (cameraFixed)
        {
            // Сохраняем текущую позицию, чтобы зафиксировать камеру
            fixedPosition = transform.position;

            // Разблокируем курсор и делаем его видимым
            LockCursor(false);
        }
        else
        {
            // Возвращаем камеру в исходную позицию и смещение
            offset = initialOffset;
            transform.position = target.position + offset;
            transform.rotation = cameraRotation; // Восстанавливаем изначальный угол

            // Скрываем курсор
            LockCursor(true);
        }
    }

    public void MoveUp()
    {
        if (!isPaused)
        {
            Vector3 newPosition = transform.position + Vector3.up * moveSpeed * Time.deltaTime;
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
            transform.position = newPosition;
        }
    }

    public void MoveTargetVertically(float deltaY)
    {
        if (target == null) return;

        // Ограничиваем новое положение в диапазоне minY и maxY
        float newY = Mathf.Clamp(target.position.y + deltaY, minY, maxY);

        // Перемещаем объект
        target.position = new Vector3(target.position.x, newY, target.position.z);
    }

    private void HandleMovement()
    {
        if (targetRigidbody == null) return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = transform.forward * vertical + transform.right * horizontal;
        direction.y = 0;
        targetRigidbody.MovePosition(target.position + direction * playerSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || currentJumps > 0) && !IsPointerOverUI())
        {
            targetRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            currentJumps--;
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            currentJumps = maxJumps;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private bool IsPointerOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private void ToggleButtonVisibility()
    {
        if (toggleButton != null)
        {
            isButtonVisible = !isButtonVisible;
            toggleButton.gameObject.SetActive(isButtonVisible);
        }
    }

    private void LockCursor(bool isLocked)
    {
        if (isLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
