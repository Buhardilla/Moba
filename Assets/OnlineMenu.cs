using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OnlineMenu : MonoBehaviour
{
    private Canvas canvas;
    Image image;
    public void Back(){
        GameObject tempObject = GameObject.Find("Canvas");
        canvas = tempObject.GetComponent<Canvas>();
        GameObject backimage = canvas.transform.Find("Background").gameObject;
        if(backimage!=null){
            image = backimage.GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>("MenuBackgrounds/MainMenu");
        }
        gameObject.transform.position = new Vector3(1500, 0, 0);
    }

    [SerializeField]
    private CreateRoomMenu _createRoomMenu;
    [SerializeField]
    private RoomListingsMenu _roomListingsMenu;

    private RoomsCanvases _roomsCanvases;
    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
        _createRoomMenu.FirstInitialize(canvases);
        _roomListingsMenu.FirstInitialize(canvases);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
