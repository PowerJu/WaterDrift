using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 20f;

    Animator anim;
    public Transform playerBoat;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerBoat = transform.GetChild(0);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        Turn();
    }

    void MoveForward()
    {
        Vector3 move = transform.right * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + move);
    }

    void Turn()
    {
        float turn = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turn = -turnSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            turn = turnSpeed;
        }
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0f, turn * Time.deltaTime, 0f));
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
