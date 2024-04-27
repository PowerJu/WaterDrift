using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float speed = 10.0f;       // 전진 속도
    public float rotationSpeed = 40.0f;  // 회전 속도
    public float smoothTime = 0.3f;       // 회전의 부드러운 전환 정도

    private Rigidbody rb;
    private float targetYRotation;        // 목표 y축 회전 각도
    private float rotationVelocity;       // 회전 속도 (각속도가 아닌 변화율)

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true; // 중력 사용
        targetYRotation = transform.eulerAngles.y;
    }

    void Update()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(rotationInput) > 0.01f)
        {
            targetYRotation += rotationInput * rotationSpeed * Time.deltaTime;  // 목표 회전 각도 계산
        }

        // 현재 각도에서 목표 각도로 부드럽게 회전
        float yRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetYRotation, ref rotationVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void FixedUpdate()
    {
        // X축 방향으로 항상 전진하는 움직임
        Vector3 rightMove = transform.right * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + rightMove);
    }
}
