using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private int baseValue;
    private float scale;

    public int getStat()
    {
        return baseValue;
    }

    public float getScale(){
        return scale;
    }
    public void setScale(float value){
        scale = value;
    }
}
