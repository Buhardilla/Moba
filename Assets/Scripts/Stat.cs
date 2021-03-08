using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private int baseValue;
    private int scale;

    public int getStat()
    {
        return baseValue;
    }

    public int getScale(){
        return scale;
    }
}
