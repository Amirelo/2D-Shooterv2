using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private TextMeshProUGUI killText;
    private TextMeshProUGUI coinText;
    private GameObject gameOver;
    private PlayerManager playerManager;
    private 
    void Start()
    {
        killText = GameObject.Find("KillText").GetComponent<TextMeshProUGUI>();
        coinText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
        gameOver = GameObject.Find("GameOver");
        playerManager = GetComponent<PlayerManager>();

        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnGameFinish(){
        killText.text = playerManager.kill.ToString();
        coinText.text = playerManager.coins.ToString();
        gameOver.SetActive(true);
    }

    public void OnRetryPressed(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnGoBackPressed(){
        SceneManager.LoadScene(0);
    }

    public void OnPlayPressed(){
        SceneManager.LoadScene(1);
    }

    public void OnExitPressed(){
        Application.Quit();
    }
}
