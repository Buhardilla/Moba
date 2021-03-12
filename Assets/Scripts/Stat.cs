using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private int baseValue;
    
    private float scale;

    [SerializeField]
    private int statObjs;

    public int getStat()
    {
        return baseValue;
    }

    public void setStat(int value){
        baseValue = value;
    }

    public int getStatObj()
    {
        return statObjs;
    }

    public void setStatObj(int value){
        statObjs = value;
    }

    public float getScale(){
        return scale;
    }

    public void setScale(float value){
        scale = value;
    }

    
}