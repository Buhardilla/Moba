﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI _roomName;

    private RoomsCanvases _roomsCanvases;
    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }

    public void OnClick_CreateRoom()
    {
        if(!PhotonNetwork.IsConnected)
            return;
            
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 6;
        PhotonNetwork.JoinOrCreateRoom(_roomName.text, options, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room succesfully", this);
        _roomsCanvases.CurrentRoomMenu.Show();
        GameObject tempObject2 =  GameObject.FindGameObjectWithTag("OnlineMenu");
        tempObject2.transform.position = new Vector3(1500, 0, 0);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
         Debug.Log("Room creation failed: " + message, this);
    }
}
