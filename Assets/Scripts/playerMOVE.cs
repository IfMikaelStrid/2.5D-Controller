using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMOVE : MonoBehaviour {

    public Transform playertrn;
    public Rigidbody playerRB;
    public float speed, boost, acc;
    private bool isFalling = false;
    public Vector3 JumpHeight = new Vector3(0, 6, 0);

    private float normalSpeed;
    private float x;
    void Start ()
    {
        playertrn = GetComponent<Transform>();
        playerRB = GetComponent<Rigidbody>();
        normalSpeed = speed;
        x = 1;
	}
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            playertrn.Translate(new Vector3(speed, 0, 0) * speed * Time.deltaTime * Mathf.Log(x));
            if (Mathf.Log(x) < 1) x = x + 0.05f;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            x = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            playertrn.Translate(new Vector3(-speed, 0, 0) * speed * Time.deltaTime * Mathf.Log(x));
            if (Mathf.Log(x) < 1) x = x + 0.05f; 
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            x = 1;
        }

        if ((Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.W))&& !isFalling)
        {
            playerRB.velocity = JumpHeight;
            isFalling = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
            speed = boost;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            speed = normalSpeed;
    }

    private void OnCollisionStay()
    {
        isFalling = false;
    }
}
