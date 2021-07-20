using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //private const int WIDTH = 8;
    //private const int HEIGHT = 6;

    private const int TILE_WIDTH = 100;
    private const int TILE_HEIGTH = 100;

    private int resources = 1000;
    private int income = 0;

    public Text resourcesText;
    public Text incomeText;

    //private GameObject[,] gameField = new GameObject[WIDTH, HEIGHT];
    private List<Tile> tiles;
    private Dictionary<Coordinates, Tile> tileMap;
    public GameObject grasslandsPrefab;
    public GameObject notificationPrefab;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        tiles = new List<Tile>();
        tileMap = new Dictionary<Coordinates, Tile>();
        CreateTile(0, 0);
        CreateSurrounding(0, 0);

        foreach (Tile t in tiles)
        {
            Debug.Log("Tile index: " + t.index);
        }
        //CreateInitial();

        //Debug.Log(tileMap[new Coordinates(0,0)]);

        /*
        for (int i = 0; i < WIDTH; i++)
        {
            for(int j = 0; j < HEIGHT; j++)
            {
                gameField[i,j] = DrawTile(((float) i - WIDTH / 2)*100, ((float) j - HEIGHT / 2)*100);
                tiles.Add(DrawTile(((float)i - WIDTH / 2) * 100, ((float)j - HEIGHT / 2) * 100));
                tileMap.Add
            }
        }
        */


        resourcesText.text = resources.ToString();
        incomeText.text = income.ToString();

        //InvokeRepeating("Harvest", 1.0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        resourcesText.text = resources.ToString();
        incomeText.text = income.ToString();
        //Debug.Log(gameField[2, 5].GetComponent<Tile>().Timer);
    }

    private Tile DrawTile(float x, float y)
    {
        GameObject newTile = Instantiate(grasslandsPrefab, new Vector2(x, y), Quaternion.identity);
        newTile.GetComponent<Tile>().gm = this;
        return newTile.GetComponent<Tile>();
    }

    private void CreateTile(int x, int y)
    {
        Tile tile = DrawTile(x * TILE_WIDTH, y * TILE_HEIGTH);
        tiles.Add(tile);
        tileMap.Add(new Coordinates(x, y), tile);
    }

    private void CreateSurrounding(int x, int y)
    {
        for (int i = x - 1; i < x + 2; i++)
        {
            for (int j = y - 1; j < y + 2; j++)
            {
                if (!tileMap.ContainsKey(new Coordinates(i, j)))
                {
                    CreateTile(i, j);
                }
            }
        }
    }


    public void Harvest(Tile tile)
    {
        //foreach (GameObject tile in gameField)
        //{
        int yield = tile.GetComponent<Tile>().Harvest();
        resources += yield;
        string message = "+" + yield;
        Debug.Log("Kurwa" + tile.GetComponent<Transform>().position.x);
        SpawnMessage(tile.GetComponent<Transform>().position.x, tile.GetComponent<Transform>().position.y, message);
        //}
    }

    public void TileClicked(Tile tile)
    {
        if (resources >= tile.Cost)
        {
            resources -= tile.Cost;
            income += tile.Purchase();
        }
        else
        {
            SpawnMessage(tile.transform, "Not enough resources");
        }
    }

    public void SpawnMessage(float x, float y, string message)
    {
        notificationPrefab.GetComponent<Notification>().Create(x, y, message);
    }

    public void SpawnMessage(Transform transformer, string message)
    {
        SpawnMessage(transformer.position.x, transformer.position.y, message);
    }

}
