using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Store : MonoBehaviour
{

    private enum move
    {
        right = 0,
        left = 1,
        up = 2,
        down = 3
    }
    public Vector2Int posStore;

    public int storeSizeY;

    public int[] rowsizes = {3,8,6,4,8,4}; //{4,8,4,6,8,3};
    public List<GameObject> buttons;

    public Sprite[] sprites;

    public GameObject Player;
    public GameObject Objs;
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
        /*  por que c****** no es esto una matriz cuadrada
            ahora me toca hacer calculitos >:(
        posStore.x = (posStore.x < 0)           ? storeSize.x - 1   : posStore.x; 
        posStore.x = (posStore.x >= storeSize.x) ? 0                 : posStore.x; 
        posStore.y = (posStore.y < 0)           ? storeSize.y - 1   : posStore.y; 
        posStore.y = (posStore.y >= storeSize.y) ? 0                 : posStore.y; 
        Debug.Log(posStore.y);
        */

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

    void buy(){
        CharacterStats playerStats = Player.GetComponent<CharacterStats>();
        Objects objsComp = Objs.GetComponent<Objects>();
        int posAr = getPositionArray();
        if(playerStats.money  >= objsComp.objs[posAr].Price){
            Debug.Log(playerStats.IdObjs[0]);
            for (int i = 0; i < 4; i++)
            {
                if(playerStats.IdObjs[i] != -1){
                    playerStats.IdObjs[i] = posAr;
                    playerStats.money -= objsComp.objs[posAr].Price;
                    break;
                }
            }
        }
    }

    void updateSprite(){
        
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].GetComponent<Image>().sprite = sprites[0];
        }
        //Debug.Log(posStore.x + pos);
        buttons[getPositionArray()].GetComponent<Image>().sprite = sprites[1];
    }
    void moveSelection(move direction){
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

    void updateStore(){
        if(Input.GetKeyDown("right"))   moveSelection(move.right);
        if(Input.GetKeyDown("left"))    moveSelection(move.left);
        if(Input.GetKeyDown("up"))      moveSelection(move.up);
        if(Input.GetKeyDown("down"))    moveSelection(move.down);
        if(Input.GetKeyDown(KeyCode.Return))   buy();
    }

    void Start()
    {
        posStore = new Vector2Int(0,5);
        updateSprite();
    }

    

    // Update is called once per frame
    void Update()
    {
        updateStore();
    }
}
