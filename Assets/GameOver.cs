using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text scoreUI;
    bool gameOver;
    void Start()
    {
        FindAnyObjectByType<PlayerScript>().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    void OnGameOver() 
    {
        scoreUI.text =Mathf.RoundToInt(10 * Time.timeSinceLevelLoad).ToString();
        gameOverScreen.SetActive(true);
        gameOver = true;
    }

}
