using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas canvas;
    Image image;

    public void PlayGameChange(){
        GameObject tempObject = GameObject.Find("Canvas");
        canvas = tempObject.GetComponent<Canvas>();
        GameObject backimage = canvas.transform.Find("Background").gameObject;
        if(backimage!=null){
            image = backimage.GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>("MenuBackgrounds/OnlineMenu");
        }
        GameObject tempObject2 = GameObject.Find("Canvas/OnlineMenu");
        tempObject2.transform.position = new Vector3(400, 335, 0);
    }

    public void HeroesTutorialChange(){
        GameObject tempObject = GameObject.Find("Canvas");
        canvas = tempObject.GetComponent<Canvas>();
        GameObject backimage = canvas.transform.Find("Background").gameObject;
        if(backimage!=null){
            image = backimage.GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>("MenuBackgrounds/HeroesTutorialMenu");
        }
    }

    public void CreditsChange(){
        GameObject tempObject = GameObject.Find("Canvas");
        canvas = tempObject.GetComponent<Canvas>();
        GameObject backimage = canvas.transform.Find("Background").gameObject;
        if(backimage!=null){
            image = backimage.GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>("MenuBackgrounds/Credits");
        }
    }

    public void QuitGame(){
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
