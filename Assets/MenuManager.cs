using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private Text textComponent;
    private RectTransform textArea;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GameObject.Find("Title").GetComponent<Text>();
        textArea = GameObject.Find("Title").GetComponent<RectTransform>();

        textComponent.fontSize = 32;
        textComponent.text = "Area Game";
        textArea.sizeDelta = new Vector2(180, 50);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
       SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Bye");
        Application.Quit();
    }
}
