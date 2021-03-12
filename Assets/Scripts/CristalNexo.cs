using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalNexo : MonoBehaviour
{
    public float minPos;
    public float maxPos;
    public float speed;
    private bool goingup;
    
    // Start is called before the first frame update
    void Start()
    {
        goingup = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(goingup){
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }
        else{
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);       
        }

        if(transform.position.y > maxPos){
            goingup = false;
        } 
        else if(transform.position.y < minPos){
            goingup = true;
        }
    }
}
