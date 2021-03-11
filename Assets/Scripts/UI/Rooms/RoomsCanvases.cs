using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCanvases : MonoBehaviour
{
    [SerializeField]
    private OnlineMenu _onlineMenu;
    public OnlineMenu OnlineMenu {get { return _onlineMenu; } }

    [SerializeField]
    private CurrentRoomMenu _currentRoomMenu;
    public CurrentRoomMenu CurrentRoomMenu {get { return _currentRoomMenu; } }

    private void Awake()
    {
        FirstInitialize();
    }

    private void FirstInitialize()
    {
        OnlineMenu.FirstInitialize(this);
        CurrentRoomMenu.FirstInitialize(this);
    }
}
