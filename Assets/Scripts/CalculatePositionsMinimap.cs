using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculatePositionsMinimap : MonoBehaviour
{
    public GameObject TopLeft;
    public GameObject BottomRight;

    public Vector3 CalculatedCenter;
    private float MapWidth;
    public GameObject Minimap;
    private float MiniWidth;
    public GameObject iconPrefab;
    GameObject[] Allies;
    GameObject[] Enemies;
    GameObject[] EnemyTowers;
    GameObject[] AllyTowers;
    GameObject[] EnemyMinions;
    GameObject[] AllyMinions;

    List<GameObject> icons;
    List<GameObject> minionicons;
    List<GameObject> currentminions;
    int objectLenght;

    public void addMinion(GameObject minion){
        //currentminions.Add(minion);
        minionicons.Add(Instantiate(iconPrefab, new Vector3(0, 0, 0), Quaternion.identity));
        minionicons[minionicons.ToArray().Length -1].transform.SetParent(Minimap.transform);
        minionicons[minionicons.ToArray().Length -1].GetComponent<RectTransform>().localPosition = WorldtoMapPosition(minion.transform.position);
        minionicons[minionicons.ToArray().Length -1].GetComponent<RawImage>().enabled = false;
        if(minion.tag.Contains("Enemy")){
            minionicons[minionicons.ToArray().Length -1].GetComponent<RawImage>().color = Color.yellow;
        }
        else{

            minionicons[minionicons.ToArray().Length -1].GetComponent<RawImage>().color = Color.cyan;
        }
    }

    void Awake()
    {
        Allies = GameObject.FindGameObjectsWithTag("Ally");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        AllyTowers = GameObject.FindGameObjectsWithTag("AllyTower");
        EnemyTowers = GameObject.FindGameObjectsWithTag("EnemyTower");
        icons = new List<GameObject>();
        minionicons = new List<GameObject>();
        
        MapWidth = BottomRight.transform.position.x - TopLeft.transform.position.x;
        MiniWidth = Minimap.GetComponent<RectTransform>().rect.width;
        CalculatedCenter = TopLeft.transform.position + ((BottomRight.transform.position - TopLeft.transform.position)/2);

        ChangeIcon(Allies,0,Color.blue);
        ChangeIcon(Enemies,icons.ToArray().Length,Color.red);
        ChangeIcon(AllyTowers,icons.ToArray().Length,Color.cyan);
        ChangeIcon(EnemyTowers,icons.ToArray().Length,Color.magenta);
        objectLenght = icons.ToArray().Length;
    }
    private void ChangeIcon(GameObject[] array, int inicio, Color color){
        for (int i = 0; i < array.Length; i++)
        {
            icons.Add(Instantiate(iconPrefab, new Vector3(0, 0, 0), Quaternion.identity));
            icons[inicio + i].transform.SetParent(Minimap.transform);
            icons[inicio + i].GetComponent<RawImage>().color = color;
            icons[inicio + i].GetComponent<RectTransform>().localPosition = WorldtoMapPosition(array[i].transform.position);
        }
    }
    private Vector3 WorldtoMapPosition(Vector3 position){
        Vector3 minimapPos = position - CalculatedCenter;
        Vector3 vectorunitario = minimapPos/MapWidth;
        vectorunitario *= MiniWidth;

        return new Vector3(vectorunitario.x,vectorunitario.z,vectorunitario.y);
    }


    void LateUpdate()
    {
        //print()
        AllyMinions = GameObject.FindGameObjectsWithTag("AllyMinion");
        EnemyMinions = GameObject.FindGameObjectsWithTag("EnemyMinion");
        //ReuseIcon(AllyMinions, objectLenght, Color.green);
        //ChangeIcon(EnemyMinions,(objectLenght + AllyMinions.Length),Color.yellow);
        for (int i = 0; i < Allies.Length; i++)
        {
            icons[i].GetComponent<RectTransform>().localPosition = WorldtoMapPosition(Allies[i].transform.position);
        }

        int length = Allies.Length;

        for (int i = 0; i < Enemies.Length; i++)
        {
            ChangePositionAndVisibility(length + i, icons, Enemies, i);
        }
        
        length += Enemies.Length;
        for (int i = 0; i < AllyTowers.Length; i++)
        {
            icons[length + i].GetComponent<RawImage>().enabled = AllyTowers[i].GetComponent<MeshRenderer>().enabled;
        }
        length += AllyTowers.Length;
        for (int i = 0; i < EnemyTowers.Length; i++)
        {
            icons[length + i].GetComponent<RawImage>().enabled = EnemyTowers[i].GetComponent<MeshRenderer>().enabled;
        }
        
        for (int i = 0; i < AllyMinions.Length; i++)
        {
            ChangePositionAndVisibility(i, minionicons ,AllyMinions, i);
        }
        //length += AllyMinions.Length;
        //print("Minions "+ AllyMinions.Length + " Icons " + minionicons.ToArray().Length);
        //for (int i = 0; i < EnemyMinions.Length; i++)
        //{
        //    ChangePositionAndVisibility(length + i,minionicons, EnemyMinions, i);
        //}
        //length += EnemyMinions.Length;
    
    }

    private void ChangePositionAndVisibility(int iconIndex,List<GameObject> iconarray, GameObject[] objectArray, int objectIndex){
        
        iconarray[iconIndex].GetComponent<RawImage>().enabled = objectArray[objectIndex].GetComponent<MeshRenderer>().enabled;
        if(!objectArray[objectIndex].activeSelf){
            
            iconarray[iconIndex].GetComponent<RawImage>().enabled = false;
        }
        iconarray[iconIndex].GetComponent<RectTransform>().localPosition = WorldtoMapPosition(objectArray[objectIndex].transform.position);
    }

}
