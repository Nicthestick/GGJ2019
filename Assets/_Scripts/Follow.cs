using UnityEngine;
using UnityEngine.Networking;

public class Follow : NetworkBehaviour
{

    public Transform target;
    public float smoothSpeed = 0.125f;
    public bool isPlayerFound = false;
    GameObject player;
    public Vector3 offset;
    public PlayerMovement playerMvt;

    private void Update()
    {
        if (!this.transform.parent.GetComponent<NetworkIdentity>().isLocalPlayer)
        {
            gameObject.GetComponent<Camera>().enabled = false;
            gameObject.GetComponent<AudioListener>().enabled = false;
        }
    }

    private void LateUpdate()
    {
        playerMvt = player.GetComponent<PlayerMovement>();
        target = player.transform;
        if (player = null)
        {
            Debug.Log("Here");
            return;
        }

        


            if(isLocalPlayer) 
            {
                Vector3 desiredPos = target.position + offset;
                Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
                transform.position = smoothedPos;

            }



    }
}





