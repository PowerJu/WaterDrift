using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float speed = 10.0f;       // ���� �ӵ�
    public float rotationSpeed = 40.0f;  // ȸ�� �ӵ�
    public float smoothTime = 0.3f;       // ȸ���� �ε巯�� ��ȯ ����

    private Rigidbody rb;
    private float targetYRotation;        // ��ǥ y�� ȸ�� ����
    private float rotationVelocity;       // ȸ�� �ӵ� (���ӵ��� �ƴ� ��ȭ��)

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true; // �߷� ���
        targetYRotation = transform.eulerAngles.y;
    }

    void Update()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(rotationInput) > 0.01f)
        {
            targetYRotation += rotationInput * rotationSpeed * Time.deltaTime;  // ��ǥ ȸ�� ���� ���
        }

        // ���� �������� ��ǥ ������ �ε巴�� ȸ��
        float yRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetYRotation, ref rotationVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void FixedUpdate()
    {
        // X�� �������� �׻� �����ϴ� ������
        Vector3 rightMove = transform.right * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + rightMove);
    }
}
