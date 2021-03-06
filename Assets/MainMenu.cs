using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas canvas;
    Image image;
    public void PlayGame(){
        //SceneManager.LoadScene();
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
