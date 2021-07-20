using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class Tile : MonoBehaviour
{
    private string tileName;
    private int yield;
    private int cost;
    private bool isOccupied = false;
    public GameManager gm;
    private float timer = 0f;
    private const float timeToYield = 5.0f;
    public GameObject progressBar;
    public GameObject yieldText;
    public int index;
    public static int tilesCreated = 0;



    public string TileName { get => tileName; set => tileName = value; }
    public bool IsOccupied { get => isOccupied; set => isOccupied = value; }
    public int Yield { get => yield; set => yield = value; }
    public int Cost { get => cost; set => cost = value; }
    public float Timer { get => timer; set => timer = value; }

    public void Awake()
    {
        index = tilesCreated;
        tilesCreated++;
        Debug.Log(index);
    }

    public void Update()
    {
        if (isOccupied)
        {
            timer += Time.deltaTime;
            if (timer >= timeToYield)
            {
                timer = timer - timeToYield;
                Debug.Log(this.transform.position.x);
                gm.Harvest(this);
         
            }
            UpdateBar();
        }
    }


    public int Harvest()
    {
        return isOccupied ? yield : 0;
    }

    //public void GatherYield()
    //{
    //    Debug.Log(timer);
    //    timer += 0.1f;
    //    if (timer >= timeToYield)
    //    {
    //        timer = 0;
    //        gm.Harvest(this);
    //    }
    //}


    public virtual int Purchase()
    {
        ResetTimer();
        IsOccupied = true;
        progressBar.SetActive(true);
        return -1;
    }

    public void ResetTimer()
    {
        Timer = 0;

    }

    public void UpdateBar()
    {
        progressBar.GetComponent<Slider>().value = timer / timeToYield;
    }

    //public void StartHarvestAnimation()
    //{
    //    yieldText.GetComponent<Transform>().localPosition = new Vector2(0, 0);
    //    yieldText.GetComponent<Text>().enabled = true;
    //    yieldText.GetComponent<Text>().text = "+" + yield;
    //    harvestAnimationPlaying = true;
    //    UpdateHarvestAnimation();
    //}

    //public void UpdateHarvestAnimation()
    //{
    //    Debug.Log(yieldText.GetComponent<Transform>().localPosition.y);
    //    if (yieldText.GetComponent<Transform>().localPosition.y <= 80)
    //    {
    //        yieldText.GetComponent<Transform>().localPosition = new Vector2(0, yieldText.GetComponent<Transform>().localPosition.y + 2);
    //    }
    //    else
    //    {
    //        StopHarvestAnimation();
    //    }
    //}

    //public void StopHarvestAnimation()
    //{
    //    harvestAnimationPlaying = false;
    //    yieldText.GetComponent<Text>().enabled = false;
    //}

}
