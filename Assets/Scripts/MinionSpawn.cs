using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawn : MonoBehaviour
{

    public GameObject MinionPrefab;
    List<GameObject> misMinions = new List<GameObject>();
    public bool game = true;
    public int numerominions;
    public Vector3 offset;
    public float delayInicial;
    public float delayOleadas;
    public float delayMinions;

    // Start is called before the first frame update
    void Start()
    {
        generarMinions();
        StartCoroutine(manejarMinions());

    }

    // Update is called once per frame
    void Update()
    {
        //nos puede servir para cortar el spawn
    }

    public void generarMinions() { //se generan 4 oleadas de minions y se ponen a FALSE
        for (int i = 0; i < numerominions*4;i++)
        {
            misMinions.Add(Instantiate(MinionPrefab, gameObject.transform.position+offset, Quaternion.Euler(0, 0, 0)) as GameObject);
            misMinions[misMinions.ToArray().Length - 1].GetComponent<MinionAI>();
            misMinions[misMinions.ToArray().Length - 1].SetActive(false);
        }

    }
    public IEnumerator manejarMinions()
    {

        yield return new WaitForSeconds(delayInicial);
        int cont = 0;
        while (game)
        {
            cont = 0;
            foreach (GameObject minion in misMinions) {
                if (cont < numerominions && !minion.activeSelf) {
                    minion.transform.position = gameObject.transform.position + offset;
                    minion.SetActive(true);
                    cont++;
                    yield return new WaitForSeconds(delayMinions);
                }
            }
            yield return new WaitForSeconds(delayOleadas);
        }
    }
}
