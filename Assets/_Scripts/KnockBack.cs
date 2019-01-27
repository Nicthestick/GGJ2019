using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class KnockBack : NetworkBehaviour
{
    private Health healthscript;

    // Start is called before the first frame update
    void Start()
    {
        healthscript = GetComponent<Health>();
        healthscript.EventKnock += PlayerKnockBack;
    }

    private void OnDisable()
    {
        healthscript.EventKnock -= PlayerKnockBack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayerKnockBack()
    {

    }
}
