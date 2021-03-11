using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    public RoomInfo RoomInfo { get; private set; }


    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        _text.text = roomInfo.MaxPlayers + "," + roomInfo.Name;
    }
     
    public void OnClick_Button()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
        GameObject tempObject2 =  GameObject.FindGameObjectWithTag("OnlineMenu");
        tempObject2.transform.position = new Vector3(1500, 0, 0);
    }
}
