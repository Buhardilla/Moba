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
        characterslist.Add(2, new List<string>(2){"Alfrog", "UI sprites/alfrog"});
        characterslist.Add(3, new List<string>(2){"BN4", "UI sprites/bn4"});
        characterslist.Add(4, new List<string>(2){"Cisma", "UI sprites/cisma"});
        characterslist.Add(5, new List<string>(2){"Rejj", "UI sprites/rejj"});
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
