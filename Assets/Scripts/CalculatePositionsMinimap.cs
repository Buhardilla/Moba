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
    //GameObject[] Minions;
    List<GameObject> icons;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Allies = GameObject.FindGameObjectsWithTag("Ally");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Minions = GameObject.FindGameObjectsWithTag("Enemy");
        icons = new List<GameObject>();

        MapWidth = BottomRight.transform.position.x - TopLeft.transform.position.x;
        MiniWidth = Minimap.GetComponent<RectTransform>().rect.width;
        CalculatedCenter = TopLeft.transform.position + ((BottomRight.transform.position - TopLeft.transform.position)/2);

        for (int i = 0; i < Allies.Length; i++)
        {
            icons.Add(Instantiate(iconPrefab, new Vector3(0, 0, 0), Quaternion.identity));
            icons[i].transform.SetParent(Minimap.transform);
            icons[i].GetComponent<RawImage>().color = Color.blue;
            icons[i].GetComponent<RectTransform>().localPosition = WorldtoMapPosition(Allies[i].transform.position);
        }

        int length = Allies.Length;

        for (int i = 0; i < Enemies.Length; i++)
        {
            icons.Add(Instantiate(iconPrefab, new Vector3(0, 0, 0), Quaternion.identity));
            icons[length + i].transform.SetParent(Minimap.transform);
            icons[length + i].GetComponent<RawImage>().color = Color.red;
            icons[length + i].GetComponent<RectTransform>().localPosition = WorldtoMapPosition(Enemies[i].transform.position);
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
    }
}
