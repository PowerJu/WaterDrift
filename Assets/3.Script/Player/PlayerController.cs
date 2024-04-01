using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;

    Animator anim;
    public Transform playerBoat;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10f;
        turnSpeed = 20f;

        anim = GetComponent<Animator>();
        playerBoat = transform.GetChild(0);
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
            TurnLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            TurnRight();
        }
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            TurnIdle();
    }

    void TurnLeft()
    {
        transform.Rotate(new Vector3(0f, - turnSpeed * Time.deltaTime, 0f));
        if (playerBoat.localEulerAngles.y > 150)
            playerBoat.Rotate(new Vector3(0f, - turnSpeed * Time.deltaTime, 0f));
    }

    void TurnRight()
    {
        transform.Rotate(new Vector3(0f, turnSpeed * Time.deltaTime, 0f));
        if (playerBoat.localEulerAngles.y < 210)
            playerBoat.Rotate(new Vector3(0f, turnSpeed * Time.deltaTime, 0f));
    }

    void TurnIdle()
    {
        if (playerBoat.localEulerAngles.y < 180)
            playerBoat.Rotate(new Vector3(0f, turnSpeed * Time.deltaTime, 0f));
        else 
            playerBoat.Rotate(new Vector3(0f, - turnSpeed * Time.deltaTime, 0f));

    }
}
