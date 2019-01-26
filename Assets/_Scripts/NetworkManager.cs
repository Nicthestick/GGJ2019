using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    private const string typeName = "UniqueGameName";
    private const string gameName = "RoomName";

    private void StartServer()
    {

    }

    void OnServerInitialized()
    {
        Debug.Log("Server Initializied");
    }
}
