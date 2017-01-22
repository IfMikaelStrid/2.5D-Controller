using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMOVE : MonoBehaviour {

    public Transform playertrn;
    public Rigidbody playaH;
    public float speed, boost, acc;
    private float normalSpeed;
    private float x;
    bool isCollided;
    void Start ()

    {
        playertrn = GetComponent<Transform>();
        normalSpeed = speed;
        x = 1;
        isCollided = false;
	}
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playertrn.Translate(new Vector3(speed, 0, 0) * speed * Time.deltaTime * Mathf.Log(x));
            if (Mathf.Log(x) < 1) x = x + 0.05f;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            x = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playertrn.Translate(new Vector3(-speed, 0, 0) * speed * Time.deltaTime * Mathf.Log(x));
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
    }
    void OnCollisionEnter(Collision collision)
    {
        playaH.velocity = Vector3.zero;
    }
}
