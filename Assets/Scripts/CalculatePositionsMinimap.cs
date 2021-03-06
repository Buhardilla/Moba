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
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Allies = GameObject.FindGameObjectsWithTag("Ally");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        EnemyTowers = GameObject.FindGameObjectsWithTag("EnemyTower");
        AllyTowers = GameObject.FindGameObjectsWithTag("AllyTower");
        EnemyMinions = GameObject.FindGameObjectsWithTag("EnemyMinion");
        AllyMinions = GameObject.FindGameObjectsWithTag("AllyMinion");
        icons = new List<GameObject>();

        MapWidth = BottomRight.transform.position.x - TopLeft.transform.position.x;
        MiniWidth = Minimap.GetComponent<RectTransform>().rect.width;
        CalculatedCenter = TopLeft.transform.position + ((BottomRight.transform.position - TopLeft.transform.position)/2);

        ChangeIcon(Allies,0,Color.blue);
        ChangeIcon(Enemies,icons.ToArray().Length,Color.red);
        ChangeIcon(AllyMinions,icons.ToArray().Length,Color.green);
        ChangeIcon(EnemyMinions,icons.ToArray().Length,Color.yellow);
        ChangeIcon(AllyTowers,icons.ToArray().Length,Color.cyan);
        ChangeIcon(EnemyTowers,icons.ToArray().Length,Color.magenta);
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

        return new Vector3(vectorunitario.z,-vectorunitario.x,vectorunitario.y);
    }

    // Start is called before the first frame update
    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    void LateUpdate()
    {
        for (int i = 0; i < Allies.Length; i++)
        {
            icons[i].GetComponent<RectTransform>().localPosition = WorldtoMapPosition(Allies[i].transform.position);
        }

        int length = Allies.Length;

        for (int i = 0; i < Enemies.Length; i++)
        {
            icons[length + i].GetComponent<RawImage>().enabled = Enemies[i].GetComponent<MeshRenderer>().enabled;
            icons[length + i].GetComponent<RectTransform>().localPosition = WorldtoMapPosition(Enemies[i].transform.position);
        }
        
        length += Enemies.Length;
        for (int i = 0; i < AllyMinions.Length; i++)
        {
            icons[length + i].GetComponent<RawImage>().enabled = AllyMinions[i].GetComponent<MeshRenderer>().enabled;
            icons[length + i].GetComponent<RectTransform>().localPosition = WorldtoMapPosition(AllyMinions[i].transform.position);
        }
        length += AllyMinions.Length;
        for (int i = 0; i < EnemyMinions.Length; i++)
        {
            icons[length + i].GetComponent<RawImage>().enabled = EnemyMinions[i].GetComponent<MeshRenderer>().enabled;
            icons[length + i].GetComponent<RectTransform>().localPosition = WorldtoMapPosition(EnemyMinions[i].transform.position);
        }
        length += EnemyMinions.Length;
        for (int i = 0; i < AllyTowers.Length; i++)
        {
            icons[length + i].GetComponent<RawImage>().enabled = AllyTowers[i].GetComponent<MeshRenderer>().enabled;
        }
        length += AllyTowers.Length;
        for (int i = 0; i < EnemyTowers.Length; i++)
        {
            icons[length + i].GetComponent<RawImage>().enabled = EnemyTowers[i].GetComponent<MeshRenderer>().enabled;
        }
    }
}
