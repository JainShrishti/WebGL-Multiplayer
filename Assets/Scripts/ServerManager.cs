using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;


public class ServerManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject canvas;
    private GameObject spawnedPlayerPrefab;
    void Start()
    {
        ConnectToServer();
    }
    public void ConnectToServer()
    {
         PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        string roomName = "DefaultRoom";
        base.OnConnectedToMaster();
        // PhotonNetwork.JoinLobby();
        RoomOptions roomOptions = new RoomOptions();
        TypedLobby typedLobby = new TypedLobby(roomName, LobbyType.Default);
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, typedLobby);
    }

    public override void OnJoinedLobby()
    {
        string roomName = "DefaultRoom";
        base.OnJoinedLobby();
        Debug.Log("Joined the lobby");
        RoomOptions roomOptions = new RoomOptions();
        TypedLobby typedLobby = new TypedLobby(roomName, LobbyType.Default);
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, typedLobby);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom(); 
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("NetworkPlayer", transform.position, transform.rotation);
        canvas.SetActive(false);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        Destroy(spawnedPlayerPrefab);
    }
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
    }


}
