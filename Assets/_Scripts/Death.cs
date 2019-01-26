using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Death : NetworkBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private PlayerMovement playerMvt;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerMvt = col.gameObject.GetComponent<PlayerMovement>();
            playerMvt.speed = 0f;
            playerMvt.jumpSpeed = 0f;
            StartCoroutine(Delay(col));

        }
    }

    IEnumerator Delay(Collider col)
    {
        print(Time.time);
        yield return new WaitForSeconds(2);
        col.transform.position = Vector3.zero;
        playerMvt.speed = 20f;
        playerMvt.jumpSpeed = 15f;
    }
}
