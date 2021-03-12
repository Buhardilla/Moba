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
    GameObject[] EnemyNexus;
    GameObject[] AllyNexus;

    private List<GameObject> icons;
    public List<Texture> playerIcons;
    public List<Color> colors;

    void Start()
    {
        Allies = GameObject.FindGameObjectsWithTag("Ally");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        AllyTowers = GameObject.FindGameObjectsWithTag("AllyTower");
        EnemyTowers = GameObject.FindGameObjectsWithTag("EnemyTower");
        AllyNexus  = GameObject.FindGameObjectsWithTag("AllyNexus");
        EnemyNexus = GameObject.FindGameObjectsWithTag("EnemyNexus");

        print(EnemyTowers.Length);
        icons = new List<GameObject>();

        MapWidth = BottomRight.transform.position.x - TopLeft.transform.position.x;
        MiniWidth = Minimap.GetComponent<RectTransform>().rect.width;
        CalculatedCenter = TopLeft.transform.position + ((BottomRight.transform.position - TopLeft.transform.position)/2);

        ChangeIcon(Allies,0, colors[0], playerIcons[0], 18f);
        ChangeIcon(Enemies,icons.ToArray().Length, colors[1], playerIcons[1], 18f);
        ChangeIcon(AllyTowers,icons.ToArray().Length, colors[2], playerIcons[2], 10f);
        ChangeIcon(EnemyTowers,icons.ToArray().Length, colors[3], playerIcons[2], 10f);
        ChangeIcon(AllyNexus,icons.ToArray().Length, colors[4], playerIcons[3], 10f);
        ChangeIcon(EnemyNexus,icons.ToArray().Length, colors[5], playerIcons[3], 10f);
    }
    private void ChangeIcon(GameObject[] array, int inicio, Color color, Texture texture, float size){
        for (int i = 0; i < array.Length; i++)
        {
            icons.Add(Instantiate(iconPrefab, new Vector3(0, 0, 0), Quaternion.identity));
            icons[inicio + i].transform.SetParent(Minimap.transform);
            icons[inicio + i].GetComponent<RawImage>().color = color;
            icons[inicio + i].GetComponent<RawImage>().texture = texture;
            icons[inicio + i].GetComponent<RectTransform>().localPosition = WorldtoMapPosition(array[i].transform.position);
            icons[inicio + i].GetComponent<RectTransform>().sizeDelta = new Vector2(size,size);
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
        for (int i = 0; i < Allies.Length; i++)
        {
            icons[i].GetComponent<RectTransform>().localPosition = WorldtoMapPosition(Allies[i].transform.position);
        }
        int length = Allies.Length;

        for (int i = 0; i < Enemies.Length; i++)
        {
            ChangePositionAndVisibility( length + i, Enemies, i);
        }
        length += Enemies.Length;
    }

    private void ChangePositionAndVisibility(int iconIndex,GameObject[] objectArray, int objectIndex){
        icons[iconIndex].GetComponent<RawImage>().enabled = objectArray[objectIndex].GetComponent<MeshRenderer>().enabled;
        icons[iconIndex].GetComponent<RectTransform>().localPosition = WorldtoMapPosition(objectArray[objectIndex].transform.position);
    }
}
