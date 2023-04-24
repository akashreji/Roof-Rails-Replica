using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasController : MonoBehaviour
{

    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject retryMenu;
    [SerializeField] GameObject scoreBoard;

    //public GameObject scoreObject;
    public TMP_Text scoreText;
    //public TextMeshProUGUI textDisplay;

    private void Awake()
    {
        startMenu = GameObject.Find("StartMenu");
        retryMenu = GameObject.Find("RetryMenu");
        scoreBoard = GameObject.Find("Score");

       // textMeshPro = scoreObject.GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        GameHandler.current.gameHasStarted += GameHasStarted;
        GameHandler.current.gameHasEnded += GameHasEnded;
        Time.timeScale = 0;
        startMenu.gameObject.SetActive(true);
        retryMenu.gameObject.SetActive(false);
        scoreBoard.gameObject.SetActive(false);
    }

    private void Update()
    {
        ///textMeshPro.SetText(LogCutter.diamondsCollected.ToString());
        
    }
    public void GameHasStarted()
    {
        startMenu.gameObject.SetActive(false);
        scoreBoard.gameObject.SetActive(true);
        Time.timeScale = 1;
    }
    private void LateUpdate()
    {
        scoreText.text = LogCutter.diamondsCollected.ToString();
    }

   

    public void GameHasEnded()
    {
        retryMenu.gameObject.SetActive(true);
        scoreBoard.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void Retry()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
    private void OnDisable()
    {
        GameHandler.current.gameHasStarted -= GameHasStarted;
        GameHandler.current.gameHasEnded -= GameHasEnded;
    }

}
