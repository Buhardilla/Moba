using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroesTutorial : MonoBehaviour
{    
    public Canvas canvas;
    Image image;
    public void Back(){
        GameObject tempObject = GameObject.Find("Canvas");
        canvas = tempObject.GetComponent<Canvas>();
        GameObject backimage = canvas.transform.Find("Background").gameObject;
        if(backimage!=null){
            image = backimage.GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>("MenuBackgrounds/MainMenu");
        }
    }
}
