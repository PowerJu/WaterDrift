using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController2 : MonoBehaviour
{
    public float speed = 10.0f;       // ���� �ӵ�
    public float rotationSpeed = 100.0f;  // ȸ�� �ӵ�

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ȭ��ǥ Ű�� ����� ȸ�� �Է�
        float rotationInput = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationInput, 0);  // Y�� ȸ��
    }

    void FixedUpdate()
    {
        // X�� �������� �׻� �����ϴ� ������
        Vector3 rightMove = transform.right * speed * Time.fixedDeltaTime;
        Vector3 newVelocity = rightMove / Time.fixedDeltaTime;

        // y-velocity�� �����Ͽ� �߷��� ������ ����
        newVelocity.y = rb.velocity.y;

        rb.velocity = newVelocity;
    }
}
