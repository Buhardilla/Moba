using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawn : MonoBehaviour
{

    public GameObject BasicMinionPrefab;
    public GameObject BigMinionPrefab;
    public GameObject LongDistanceMinionPrefab;
    public GameObject MiniMap;
    public float roty;
    List<GameObject> misMinions = new List<GameObject>();
    public bool game = true;
    public int numerominions;
    public Vector3 offset;
    public float delayInicial;
    public float delayOleadas;
    public float delayMinions;
    public int oleada = 0;

    // Start is called before the first frame update
    void Start()
    {
        generateMinions();
        StartCoroutine(manejarMinions());

    }

    // Update is called once per frame
    void Update()
    {
        //nos puede servir para cortar el spawn
    }
    
    public void generateMinions() { //se generan 4 oleadas de minions y se ponen a FALSE
        for (int i = 0; i < numerominions*4;i++)
        {
            if( i % 2 == 0){
                misMinions.Add(Instantiate(BasicMinionPrefab, gameObject.transform.position+offset, Quaternion.Euler(0, roty, 0)) as GameObject);
            }
            else{
                misMinions.Add(Instantiate(LongDistanceMinionPrefab, gameObject.transform.position+offset, Quaternion.Euler(0, roty, 0)) as GameObject);
            }
            misMinions[misMinions.ToArray().Length - 1].GetComponent<MinionAI>();
            misMinions[misMinions.ToArray().Length - 1].SetActive(false);
        }
        
        misMinions.Add(Instantiate(BigMinionPrefab, gameObject.transform.position+offset, Quaternion.Euler(0, roty, 0)) as GameObject);
        misMinions[misMinions.ToArray().Length - 1].GetComponent<MinionAI>();
        misMinions[misMinions.ToArray().Length - 1].SetActive(false);

        misMinions.Add(Instantiate(BigMinionPrefab, gameObject.transform.position+offset, Quaternion.Euler(0, roty, 0)) as GameObject);
        misMinions[misMinions.ToArray().Length - 1].GetComponent<MinionAI>();
        misMinions[misMinions.ToArray().Length - 1].SetActive(false);
    }

    public IEnumerator manejarMinions()
    {
        yield return new WaitForSeconds(delayInicial);
        int cont = 0;
        while (game)
        {
            cont = 0;
            ++oleada;
            foreach (GameObject minion in misMinions) {
                if (cont < numerominions && !minion.activeSelf) {
                    minion.transform.position = gameObject.transform.position + offset;
                    minion.SetActive(true);
                    cont++;
                    yield return new WaitForSeconds(delayMinions);
                }
            }
            if( oleada > 2 ){ 
                for (int i = misMinions.ToArray().Length-1; i >= 0; i--)
                {
                   if(!misMinions[i].activeSelf){
                        misMinions[i].transform.position = gameObject.transform.position + offset;
                        misMinions[i].SetActive(true);
                        misMinions[i].GetComponent<MinionAI>().state = MinionAI.MinionState.MOVING;
                        misMinions[i].GetComponent<MinionAI>().target = null;
                        if(misMinions[i].GetComponent<Disparar>()){
                            misMinions[i].GetComponent<Disparar>().temporizadordisparo = 0;
                        }
                       break;
                   } 
                }
                oleada = 0;
            }
            yield return new WaitForSeconds(delayOleadas);
        }
    }
}