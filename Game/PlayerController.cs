using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;  // �������� ������������ �������
    public Transform cameraTransform; // ������, ������� ����� ��������� �� ��������
    public Vector3 cameraOffset;     // �������� ������ ������������ �������
    public float lookSpeed = 2.0f;   // �������� �������� ������

    private float yaw = 0.0f;        // �������� �� ��� Y
    private float pitch = 0.0f;      // �������� �� ��� X

    void Start()
    {
        // ������ ��������� �������� ������ ������������ �������
        if (cameraTransform != null)
        {
            cameraOffset = cameraTransform.position - transform.position;
        }

        // ��������� ���������� �������, ����� ���� ����������� ������� ������ ������
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // ���������� ��������� ������� � ������� ������ W, A, S, D
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // A, D
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;     // W, S

        // ���������� ������ ������/�����/�����/������
        Vector3 move = transform.forward * vertical + transform.right * horizontal;
        transform.position += move;

        // ��������� �������� ������ � ������� ����
        yaw += Input.GetAxis("Mouse X") * lookSpeed;
        pitch -= Input.GetAxis("Mouse Y") * lookSpeed;

        // ����������� ���� �������� �� ��� X (����� �� ���� ���������� ������)
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        // �������� ������ �� ���� Y � X
        cameraTransform.rotation = Quaternion.Euler(pitch, yaw, 0.0f);

        // ��������� ������� ������ � ������ �������� �������
        if (cameraTransform != null)
        {
            cameraTransform.position = transform.position + cameraOffset;
        }
    }
}
