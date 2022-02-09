using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    [SerializeField] GameObject gameOverPanel;

    public static bool isGameStarted;
    [SerializeField] GameObject startingText;

    public static int numberOfCoins;

    [SerializeField] TextMeshProUGUI coinsText;

    void Start()
    {
        gameOver=false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfCoins = 0;
    }

    void Update()
    {
        if(gameOver){
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        coinsText.text = "" + numberOfCoins;

        if(SwipeManager.tap){
            isGameStarted = true;
            GameObject.Find("dogModelFinished").GetComponent<Animator>().Play("running");
            Destroy(startingText);
        }
    }
}
