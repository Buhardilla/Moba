using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System.IO;

public class MyPhotonPlayer : MonoBehaviour
{
    PhotonView myPV;
    GameObject myPlayerAvatar;

    GameObject store;

    GameObject cameraplayer;

    Player[] allPlayers;
    int myNumberInRoom;

    void Awake()
    {
    
    }

    // Start is called before the first frame update
    void Start()
    {
        myPV = GetComponent<PhotonView>();

        allPlayers = PhotonNetwork.PlayerList;

        foreach(Player p in allPlayers)
        {
            if(p!= PhotonNetwork.LocalPlayer)
            {
                myNumberInRoom++;
            }
        }



        if (myPV.IsMine)
        {
            myPlayerAvatar = PhotonNetwork.Instantiate(Path.Combine("Prefab","Player"), SpawnManager.instance.spawnPoints[myNumberInRoom].position, Quaternion.identity);
            
            if(myNumberInRoom%2==0){
                gameObject.transform.SetParent(GameObject.Find("Player Dummy Ally").transform);
            }
            else
            {
                gameObject.transform.SetParent(GameObject.Find("Player Dummy Enemy").transform);
            }
        }

        store.GetComponent<Store>().Player = gameObject;
        cameraplayer.GetComponent<LookAtPlayer>().player = gameObject; 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
