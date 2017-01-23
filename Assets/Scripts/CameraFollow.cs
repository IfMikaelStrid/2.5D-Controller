using UnityEngine;

public class CameraFollow : MonoBehaviour {
    //public Transform player;
    //float panConstantX, playerUpdatePos, posUpdate;
    public GameObject player;
    public float offset,offsetSmoothing;
    private Vector3 playerPosition;
    private void Start()
    {
        //transform.position = new Vector3(player.position.x, transform.position.y, -20);
        //panConstantX = Mathf.Abs(player.position.x) + 5;
        //playerUpdatePos = Mathf.Abs(player.position.x);
    }
    void Update() {
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
        //if (Mathf.Abs(player.position.x) > panConstantX)
        //{
        //    if (player.position.x > playerUpdatePos)
        //    {
        //        transform.position = new Vector3(player.position.x - 5, transform.position.y, -20);
        //        //if (player.position.x == posUpdate)
        //        //{

        //        //}
        //    }
        //    else if (player.position.x < playerUpdatePos)
        //    {
        //        transform.position = new Vector3(player.position.x + 5, transform.position.y, -20);
        //    }
        //}
        //posUpdate = player.position.x;
    }
}
