using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;


public class Objects : MonoBehaviour
{
    // Start is called before the first frame update
    
    [System.Serializable]
    public struct Object
    {
        public string Name;
        public int Price;
        public int AD; // Attack Damage
        public int ADpen; // Attack Damage Pen
        public int ADR; // Attack Damage Resistance
        
        public int AP; // Attack Power
        public int APpen; // Attack Power Penetration
        public int MR; // Magic Resistance

        public int AS; // Attack Speed
        public int VEL; // Velocity
        public int CDR; // Cool Down Reduction
        public int RNG; // Range

        public int health;
        public int regenHealth; 

        public int mana;
        public int regenMana;

        public int Crit;

        public int RV;

        public int ob1;
        public int ob2;

    }

    public List<Object> objs;

    public int ID;

    string jsonString;
    void Start()
    {
        jsonString = File.ReadAllText("Assets/Scripts/Objects.JSON");    
        JSONNode data = JSON.Parse(jsonString);
        foreach (JSONNode obj in data)
        {
            Object temp = new Object(); 
            temp.Name = (obj["Name"])?  obj["Name"].Value : "No-Name";
            temp.Price = (obj["Price"])?  obj["Price"].AsInt : 0;

            temp.AD = (obj["AD"])?  obj["AD"].AsInt : 0;
            temp.ADpen = (obj["ADpen"])?  obj["ADpen"].AsInt : 0;
            temp.ADR = (obj["ADR"])?  obj["ADR"].AsInt : 0;

            temp.AP = (obj["AP"])?  obj["AP"].AsInt : 0;
            temp.APpen = (obj["APpen"])?  obj["APpen"].AsInt : 0;
            temp.MR = (obj["MR"])?  obj["MR"].AsInt : 0;

            temp.AS = (obj["AS"])?  obj["AS"].AsInt : 0;
            temp.VEL = (obj["VEL"])?  obj["VEL"].AsInt : 0;
            temp.CDR = (obj["CDR"])?  obj["CDR"].AsInt : 0;
            temp.RNG = (obj["RNG"])?  obj["RNG"].AsInt : 0;

            temp.health = (obj["health"])?  obj["health"].AsInt : 0;
            temp.regenHealth = (obj["regenHealth"])?  obj["regenHealth"].AsInt : 0;

            temp.mana = (obj["mana"])?  obj["mana"].AsInt : 0;
            temp.regenMana = (obj["regenMana"])?  obj["regenMana"].AsInt : 0;

            temp.Crit = (obj["Crit"])?  obj["Crit"].AsInt : 0;

            temp.RV = (obj["RV"])?  obj["RV"].AsInt : 0;

            temp.ob1 = (obj["Item 1"])?  obj["Item 1"].AsInt : -1;
            temp.ob2 = (obj["Item 2"])?  obj["Item 2"].AsInt : -1;

            objs.Add(temp);
            
        }
    }
}