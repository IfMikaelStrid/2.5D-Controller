using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityController : MonoBehaviour
{
    public Rigidbody playerRig;
    public float speed, boost, acc;
    private float normalSpeed;
    private float x;
    public Vector3 playerVector = new Vector3(movementSpeed, jumpSpeed, 0);
    private bool isFalling = false;
    private static float movementSpeed, jumpSpeed;

    void Start()
    {
        playerRig = GetComponent<Rigidbody>();
        normalSpeed = speed;
        movementSpeed = jumpSpeed = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            playerRig.velocity = new Vector3(speed, 0, 0) * speed * Time.deltaTime * Mathf.Log(x);
            if (Mathf.Log(x) < 1) x = x + 0.05f;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            x = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            movementSpeed = -speed * speed * Time.deltaTime * Mathf.Log(x);
            playerRig.velocity = playerVector;
            if (Mathf.Log(x) < 1) x = x + 0.05f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            x = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
            speed = boost;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            speed = normalSpeed;


        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && !isFalling)
        {
            jumpSpeed = 6;
            playerRig.velocity = playerVector;
            isFalling = true;
        }
    }
    private void OnCollisionStay()
    {
        isFalling = false;
    }
}
