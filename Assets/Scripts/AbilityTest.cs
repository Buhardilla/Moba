using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTest : MonoBehaviour //abstract
{
    //EN EL PERSONAJE onbutton press pillar esta habilidad y lanzar CAST() 
    public Texture2D icon;
    public GameObject hitbox;
   // public Vector3 characterposition;
    //public Vector3 castdestination;
    public char tecla;
    public float cd;
    public float totaldmg;
    public float basedmg;
    public int lv;
    public float lvscaling;
    public float statscaling; //solo tenemos uno porque no hay habilidades de escalado dual
    //public bool ScalingIsTotal; // si es False, se calcula el escalado de manera que solo statscaling*stats, de lo contrario, stat+suma
    public enum typecast {AREA,PROJECTILE,SELF};
    public typecast tipocasteo;
    float abTimer = 0;
    public float ab1CDTime;
    public void CreateAbility(float cd, float basedmg,float lvscaling,float statscaling,string tipo,GameObject hitbox)
    {
        this.cd = cd;
        this.totaldmg = 0;
        this.basedmg = basedmg;
        this.lv = 1;
        this.lvscaling = lvscaling;
        this.statscaling = statscaling;
        this.hitbox = hitbox;
       // this.ScalingIsTotal = isTotal; no creo que esto haga falta ya que se le pasa por parametro el stat y eso lo decide el character

        switch (tipo) {
            case "area":  tipocasteo = typecast.AREA; break;
            case "proyectil": tipocasteo = typecast.PROJECTILE; break;
            case "self": tipocasteo = typecast.SELF; break;
        }
    }

    public void cast(Vector3 characterposition,Vector3 castdestination) {

        print(tipocasteo);
        if (lv > 0) {

            print(tipocasteo);
            switch (tipocasteo) {
               //case typecast.AREA: tipocasteo = hitbox.GetComponent<AreaOfEffect>().CastAOE(hitbox,castposition,totaldmg,statuseffect); break;
               case typecast.PROJECTILE:
                    hitbox.GetComponent<Projectile>().FireProjectile(characterposition, castdestination,totaldmg) ; break;
               // case typecast.SELF: tipocasteo = ????????; break;
            }
            //set CD al valor inicial
        }

    }
    
    void setinGUI() {
        //si habilidad QWER posicion
    }
    void UpdateLevelUp()
    {
        if (this.lv<5) {
            this.lv++;
            this.basedmg += lvscaling * lv;
        }
    }
    void UpdateDMGOnItemChange(float stat) {
        this.basedmg += statscaling * stat;
    }
    void UpdateCDOnItemChange(float cdr) {
        this.cd -= cd * cdr;
    }
}
