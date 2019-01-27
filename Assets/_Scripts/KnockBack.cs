using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class KnockBack : NetworkBehaviour
{
    private Health healthscript;

    void Start()
    {
        healthscript = GetComponent<Health>();
        healthscript.EventKnock += PlayerKnockBack;
    }

    private void OnDisable()
    {
        healthscript.EventKnock -= PlayerKnockBack;
    }

    void PlayerKnockBack()
    {
         Transform trans = GetComponent<Transform>();
        trans.position = trans.position + new Vector3(2,0,0);


    }
}
