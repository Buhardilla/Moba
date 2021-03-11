using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelector : MonoBehaviour
{
    public int selectedCharId;

    public Dictionary<int, List<string>> characterslist = new Dictionary<int, List<string>>();

    void Start()
    {
        selectedCharId = 0;
        characterslist.Add(0, new List<string>(2){"Shakke", "UI sprites/shakke"});
        characterslist.Add(1, new List<string>(2){"Tiana", "UI sprites/tiana"});
    }

    public void OnClick_Right()
    {
        int length = characterslist.Count;
        if(selectedCharId == (length-1))
        {
            selectedCharId = 0;
        }
        else{
            selectedCharId++;
        }

        GameObject tempobj = GameObject.Find("CharacterName");
        TextMeshProUGUI tempobj2 = tempobj.GetComponent<TextMeshProUGUI>();
        tempobj2.text = characterslist[selectedCharId][0];
        tempobj = GameObject.Find("CharacterImage");
        Image image1 = tempobj.GetComponent<Image>();
        image1.sprite = Resources.Load<Sprite>(characterslist[selectedCharId][1]);
    }
    public void OnClick_Left()
    {
        int length = characterslist.Count;
        if(selectedCharId == 0)
        {
            selectedCharId = length-1;
        }
        else{
            selectedCharId--;
        }

        GameObject tempobj = GameObject.Find("CharacterName");
        TextMeshProUGUI tempobj2 = tempobj.GetComponent<TextMeshProUGUI>();
        tempobj2.text = characterslist[selectedCharId][0];
        tempobj = GameObject.Find("CharacterImage");
        Image image1 = tempobj.GetComponent<Image>();
        image1.sprite = Resources.Load<Sprite>(characterslist[selectedCharId][1]);
    }
}
