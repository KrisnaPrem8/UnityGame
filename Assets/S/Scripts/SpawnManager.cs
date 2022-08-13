using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRangeX = 3;
    private float spawnRangeZ = 11;
    private float spawnRangeY = 3.04f;
    public TextMeshProUGUI scoreText;
    private int score;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    private float spawnRate = 2.0f;
    public GameObject titleScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    IEnumerator SpawnRandomEnemy()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnRangeY, spawnRangeZ);
            Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
        }
    }
    
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnRandomEnemy());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }
}
