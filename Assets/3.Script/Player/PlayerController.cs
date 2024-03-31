using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10f;
        turnSpeed = 20f;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        Turn();
    }

    void MoveForward()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }

    void Turn()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0f, - turnSpeed * Time.deltaTime, 0f));
            anim.SetBool("Left", true);
        }
        else
            anim.SetBool("Left", false);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0f, turnSpeed * Time.deltaTime, 0f));
            anim.SetBool("Right", true);
        }
        else
            anim.SetBool("Right", false);
    }

    void TurnLeft()
    {
        transform.Rotate(new Vector3(0f, - turnSpeed * Time.deltaTime, 0f));
    }

    void TurnRight()
    {
        transform.Rotate(new Vector3(0f, turnSpeed * Time.deltaTime, 0f));
    }
}
