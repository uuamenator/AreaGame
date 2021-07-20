using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Grasslands : Tile
{
    private const string BASE_NAME = "Grasslands";
    private float x;
    private float y;

    public Sprite unoccupiedSprite;
    public Sprite occupiedSprite;

    
    

    private void Awake()
    {
        base.Awake();
        x = this.GetComponent<Transform>().position.x;
        y = this.GetComponent<Transform>().position.y;
        TileName = string.Format("{0} {1} {2}", BASE_NAME, x, y);
        Yield = 1;
        Cost = 10;
        //     Debug.Log("Awake Grasslands");
    }

    private void OnMouseEnter()
    {
        //Debug.Log("huj");
        this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnMouseExit()
    {
        this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnMouseDown()
    {
//        Debug.Log(TileName + " " + IsOccupied.ToString());
        if (!IsOccupied)
        {
            gm.TileClicked(this);
        }
    }

    public void Update()
    {
        base.Update();
    }

    public override int Purchase()
    {
        Debug.Log(base.Purchase());
        this.GetComponent<SpriteRenderer>().sprite = occupiedSprite;
        return Yield;

    }
}
