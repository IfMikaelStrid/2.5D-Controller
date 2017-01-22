using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {
    public Rigidbody playerRB;
    private bool isFalling = false;
    public Vector3 JumpHeight = new Vector3(0, 6, 0);
    private int doubleJump;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        doubleJump = 0;
    }

    void Update ()
    {
        if (Input.GetKey(KeyCode.Space) && !isFalling)
        {
            playerRB.velocity = JumpHeight;
            if(doubleJump > 1){
                isFalling = true;
            }
            doubleJump = doubleJump + 1;
        }
    }

    private void OnCollisionStay()
    {
        isFalling = false;
        doubleJump = 0;
    }
}
