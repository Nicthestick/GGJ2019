using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetID : NetworkBehaviour {

    [SyncVar] public string PlayerName;
    private NetworkInstanceId playerNetID;
    private Transform trans;


    public override void OnStartLocalPlayer()
    {
        GetNetIdentity();
        setId();
    }


    // Start is called before the first frame update
    void Awake()
    {
        trans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(trans.name == "" || trans.name == "Player(Clone)")
        {
            setId();
        }
    }

    [Client]
    void GetNetIdentity()
    {
        playerNetID = GetComponent<NetworkIdentity>().netId;
        CmdTellServerID(MakeUniqueName());

    }

    void setId()
    {
        if(!isLocalPlayer)
        {
            trans.name = PlayerName;
        }
        else
        {
            trans.name = MakeUniqueName();
        }
    }


    string MakeUniqueName()
    {
        string UniquePlayerID = "Player" + playerNetID.ToString();
        return UniquePlayerID;
    }

    [Command]
    void CmdTellServerID(string name)
    {
        PlayerName = name;
    }

}
