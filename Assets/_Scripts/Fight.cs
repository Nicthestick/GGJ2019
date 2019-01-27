using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Fight : NetworkBehaviour
{
    private int damage = 25;
    private float range = 200;
    [SerializeField] private Transform camTrans;
    private RaycastHit hit;


    private void Start()
    {
        
    }


    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {


    }

    void checkPillowHit()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            attack();
        }
    }

    void attack()
    {
        if(Physics.Raycast(camTrans.TransformPoint(0,0,0.5f), camTrans.forward, out hit, range))
        {
            Debug.Log(hit.transform.tag);

            if(hit.transform.tag == "Player")
            {
                string Uidentity = hit.transform.name;
                CmdTellServerHit(Uidentity, damage);
            }
        }
    }

    [Command]
    void CmdTellServerHit(string UniquePlayerID, int dmg)
    {
        GameObject go = GameObject.Find(UniquePlayerID);
        go.GetComponent<Health>().DeductHealth(dmg);
        //tells server who has been hit.
    }

}
