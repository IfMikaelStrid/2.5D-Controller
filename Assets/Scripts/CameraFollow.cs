using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform player;
    float panConstantX, playerUpdatePos, posUpdate;
    private void Start()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, -20);
        panConstantX = Mathf.Abs(player.position.x) + 5;
        playerUpdatePos = Mathf.Abs(player.position.x);
    }
    void Update() {
        if (Mathf.Abs(player.position.x) > panConstantX)
        {
            if (player.position.x > playerUpdatePos)
            {
                transform.position = new Vector3(player.position.x - 5, transform.position.y, -20);
                //if (player.position.x == posUpdate)
                //{

                //}
            }
            else if (player.position.x < playerUpdatePos)
            {
                transform.position = new Vector3(player.position.x + 5, transform.position.y, -20);
            }
        }
        posUpdate = player.position.x;
    }
}
