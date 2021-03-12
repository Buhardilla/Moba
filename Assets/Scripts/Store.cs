using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Store : MonoBehaviour
{

    public enum move
    {
        right = 0,
        left = 1,
        up = 2,
        down = 3
    }
    private Vector2Int posStore;

    public GameObject tienda;
    private int posInv;

    public int storeSizeY;

    private int[] rowsizes = {3,8,6,4,8,4}; //{4,8,4,6,8,3};
    public List<GameObject> buttons;
    public List<GameObject> inventory;

    public List<GameObject> iconosObj;

    public GameObject[] textos;

    public GameObject dineroPers;


    public Sprite[] sprites;
    public Sprite emptySlot;

    public GameObject[] shopInv;
    public GameObject[] objTree;

    public GameObject Player;
    public GameObject Objs;

    public GameObject Alerta;
    private bool ableToBuy;
    // Start is called before the first frame update

    int getPositionArray(){
        int pos = 0;
        for (int i = 0; i < posStore.y; i++)
        {
            pos += rowsizes[i];
        }
        return pos + posStore.x;
    }

    void checkLegalPositions(bool changeY){
        if(posStore.y < 0)
            posStore.y = storeSizeY-1;
        if(posStore.y >= storeSizeY)
            posStore.y = 0;
        if(posStore.x < 0)
            posStore.x = rowsizes[posStore.y] - 1;
        if(posStore.x >= rowsizes[posStore.y])
            if(changeY)
                posStore.x = rowsizes[posStore.y] - 1;
            else
                posStore.x = 0;
       

    }

    public void buy(){
        if(ableToBuy){
            CharacterStats playerStats = Player.GetComponent<CharacterStats>();
            Objects objsComp = Objs.GetComponent<Objects>();
            int posAr = getPositionArray();
            int obj1, obj2;
            obj1 = obj2 = -1;
            int discount = 0;
            for (int i = 0; i < playerStats.IdObjs.Length; i++)
            {
                if(obj1 == -1 && objsComp.objs[posAr].ob1 != -1 && playerStats.IdObjs[i] == objsComp.objs[posAr].ob1){
                    obj1 = i;
                    discount += objsComp.objs[objsComp.objs[posAr].ob1].Price;
                } 
                else if(obj2 == -1 &&objsComp.objs[posAr].ob2 != -1 && playerStats.IdObjs[i] == objsComp.objs[posAr].ob2){
                    obj2 = i;
                    discount += objsComp.objs[objsComp.objs[posAr].ob2].Price;
                }
            }
            
            if(playerStats.money + discount >= objsComp.objs[posAr].Price){
                if(obj1 != -1) playerStats.IdObjs[obj1] = -1;
                if(obj2 != -1) playerStats.IdObjs[obj2] = -1;
                for (int i = 0; i < 4; i++)
                {
                    if(playerStats.IdObjs[i] == -1){
                        playerStats.IdObjs[i] = posAr;
                        playerStats.money += discount;
                        playerStats.money -= objsComp.objs[posAr].Price;
                        break;
                    }
                }
            }
            updateSprite();
        }
    }

    public void sell(){
        if(ableToBuy){
            CharacterStats playerStats = Player.GetComponent<CharacterStats>();
            Objects objsComp = Objs.GetComponent<Objects>();

            if(playerStats.IdObjs[posInv] != -1 ){
                playerStats.money += objsComp.objs[playerStats.IdObjs[posInv]].Price * 2 / 3;
                playerStats.IdObjs[posInv] = -1;
            }
            updateSprite();
        }
    }

    void updateSprite(){ // Y bueno, todo ...
        
        int posAr = getPositionArray();
        CharacterStats playerStats = Player.GetComponent<CharacterStats>();

        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].GetComponent<Image>().sprite = sprites[0];
        }

        buttons[posAr].GetComponent<Image>().sprite = sprites[1];

        for (int i = 0; i < inventory.Count; i++)
        {
            inventory[i].GetComponent<Image>().sprite = sprites[0];
        }

        inventory[posInv].GetComponent<Image>().sprite = sprites[1];

        for (int i = 0; i < shopInv.Length; i++)
        {
            if(Player.GetComponent<CharacterStats>().IdObjs[i] != -1)
                shopInv[i].GetComponent<Image>().sprite = iconosObj[Player.GetComponent<CharacterStats>().IdObjs[i]].GetComponent<Image>().sprite;
            else
                shopInv[i].GetComponent<Image>().sprite = emptySlot;
        }
        objTree[0].GetComponent<Image>().sprite = iconosObj[posAr].GetComponent<Image>().sprite;

        Objects objsComp = Objs.GetComponent<Objects>();
        if(posAr >= 0 && posAr < objsComp.objs.Count && objsComp.objs[posAr].ob1 != -1){
            objTree[1].GetComponent<Image>().sprite = iconosObj[objsComp.objs[posAr].ob1].GetComponent<Image>().sprite;
            if(objsComp.objs[posAr].ob2 != -1){
                objTree[2].GetComponent<Image>().sprite = iconosObj[objsComp.objs[posAr].ob2].GetComponent<Image>().sprite;
            }
            else
            {
                objTree[2].GetComponent<Image>().sprite = emptySlot;
            }
        }
        else
        {
            objTree[1].GetComponent<Image>().sprite = emptySlot;
            objTree[2].GetComponent<Image>().sprite = emptySlot;
        }

        if(posAr >= 0 && posAr < objsComp.objs.Count){
            textos[0].GetComponent<UnityEngine.UI.Text>().text = objsComp.objs[posAr].Name;
            string txt = "";
            if(objsComp.objs[posAr].AD != 0) txt += objsComp.objs[posAr].AD.ToString() + " AD. \n";
            if(objsComp.objs[posAr].ADpen != 0) txt += objsComp.objs[posAr].ADpen.ToString() + " AD Penetration. \n";
            if(objsComp.objs[posAr].ADR != 0) txt += objsComp.objs[posAr].ADR.ToString() + " AD Resistance. \n";
            if(objsComp.objs[posAr].AP != 0) txt += objsComp.objs[posAr].AP.ToString() + " AP. \n";
            if(objsComp.objs[posAr].APpen != 0) txt += objsComp.objs[posAr].APpen.ToString() + " AP Penetration. \n";
            if(objsComp.objs[posAr].MR != 0) txt += objsComp.objs[posAr].MR.ToString() + " MR. \n";
            if(objsComp.objs[posAr].AS != 0) txt += objsComp.objs[posAr].AS.ToString() + " Attack Speed. \n";
            if(objsComp.objs[posAr].VEL != 0) txt += objsComp.objs[posAr].VEL.ToString() + " Speed. \n";
            if(objsComp.objs[posAr].CDR != 0) txt += objsComp.objs[posAr].CDR.ToString() + " Cooldown Reduction. \n";
            if(objsComp.objs[posAr].RNG != 0) txt += objsComp.objs[posAr].RNG.ToString() + " Range. \n";
            if(objsComp.objs[posAr].health != 0) txt += objsComp.objs[posAr].health.ToString() + " Health. \n";
            if(objsComp.objs[posAr].regenHealth != 0) txt += objsComp.objs[posAr].regenHealth.ToString() + " Health Regeneration. \n";
            if(objsComp.objs[posAr].mana != 0) txt += objsComp.objs[posAr].mana.ToString() + " Mana. \n";
            if(objsComp.objs[posAr].regenMana != 0) txt += objsComp.objs[posAr].regenMana.ToString() + " Mana Regeneration. \n";
            if(objsComp.objs[posAr].Crit != 0) txt += objsComp.objs[posAr].Crit.ToString() + " Crit. \n";
            if(objsComp.objs[posAr].RV != 0) txt += objsComp.objs[posAr].RV.ToString() + " LifeSteal. \n";

            int obj1, obj2, discount;
            obj1 = obj2 = -1;
            discount = 0;

            for (int i = 0; i < playerStats.IdObjs.Length; i++)
            {
                if(obj1 == -1 && objsComp.objs[posAr].ob1 != -1 && playerStats.IdObjs[i] == objsComp.objs[posAr].ob1){
                    obj1 = i;
                    discount += objsComp.objs[objsComp.objs[posAr].ob1].Price;
                } 
                else if(obj2 == -1 &&objsComp.objs[posAr].ob2 != -1 && playerStats.IdObjs[i] == objsComp.objs[posAr].ob2){
                    obj2 = i;
                    discount += objsComp.objs[objsComp.objs[posAr].ob2].Price;
                }
            }

            textos[1].GetComponent<UnityEngine.UI.Text>().text = txt; 
            textos[2].GetComponent<UnityEngine.UI.Text>().text = (objsComp.objs[posAr].Price - discount).ToString();
        }

        dineroPers.GetComponent<UnityEngine.UI.Text>().text = playerStats.money.ToString();
    }

    public void moveSelection(move direction){
        Vector2Int currentPos = posStore;
        bool changeY = false;
        switch (direction)
        {
            case move.right:
                posStore.x += 1;
                break;

            case move.left:
                posStore.x -= 1;
                break;

            case move.up:
                posStore.y += 1;
                changeY = true;
                break;

            case move.down:
                posStore.y -= 1;
                changeY = true;
                break;
        }

        checkLegalPositions(changeY);
        updateSprite();
    }

    public void moveInv(move direction){
        
        switch (direction)
        {
            case move.right:
                posInv += 1;
                break;

            case move.left:
                posInv -= 1;
                break;
        }

        if(posInv < 0) posInv = inventory.Count - 1;
        if(posInv >= inventory.Count) posInv = 0;

        updateSprite();

    }

    void updateStore(){
        if(Input.GetKeyDown(KeyCode.B)){
            print("cierro tienda");
            tienda.GetComponent<Canvas>().enabled = !tienda.GetComponent<Canvas>().enabled;
        }

        if(this.enabled){
            if(Vector3.Distance(GameObject.FindGameObjectWithTag(Player.tag+"Nexus").transform.position, Player.transform.position) < 20){
                Alerta.SetActive(false);
                ableToBuy = true;
            }
            else{
                Alerta.SetActive(true);
                ableToBuy = false;
            }

            if(Input.GetKeyDown("right"))   moveSelection(move.right);
            if(Input.GetKeyDown("left"))    moveSelection(move.left);
            if(Input.GetKeyDown("up"))      moveSelection(move.up);
            if(Input.GetKeyDown("down"))    moveSelection(move.down);
            if(Input.GetKeyDown(KeyCode.P))    moveInv(move.right);
            if(Input.GetKeyDown(KeyCode.O))    moveInv(move.left);
            if(Input.GetKeyDown(KeyCode.Return))   buy();
            if(Input.GetKeyDown(KeyCode.Backspace))  sell();

        }
        
    }

    void Start()
    {
        posStore = new Vector2Int(0,5);
        posInv = 0;
        updateSprite();
    }

    

    // Update is called once per frame
    void Update()
    {
        updateStore();
    }
}