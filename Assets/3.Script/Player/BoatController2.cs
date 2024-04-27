using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController2 : MonoBehaviour
{
    public float speed = 10.0f;       // 전진 속도
    public float rotationSpeed = 100.0f;  // 회전 속도

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 화살표 키를 사용한 회전 입력
        float rotationInput = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationInput, 0);  // Y축 회전
    }

    void FixedUpdate()
    {
        // X축 방향으로 항상 전진하는 움직임
        Vector3 rightMove = transform.right * speed * Time.fixedDeltaTime;
        Vector3 newVelocity = rightMove / Time.fixedDeltaTime;

        // y-velocity를 유지하여 중력의 영향을 보존
        newVelocity.y = rb.velocity.y;

        rb.velocity = newVelocity;
    }
}
