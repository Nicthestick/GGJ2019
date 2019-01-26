using UnityEngine;


public class Follow : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed = 0.125f;
    public bool isPlayerFound = false;
    GameObject player;
    public Vector3 offset;
    public PlayerMovement playerMvt;



    private void LateUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMvt = player.GetComponent<PlayerMovement>();
        target = player.transform;
        if (player = null)
        {
            Debug.Log("Here");
            return;
        }

        


            if(playerMvt.isLocalPlayer == true) 
            {
                Vector3 desiredPos = target.position + offset;
                Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
                transform.position = smoothedPos;

            }



    }
}





