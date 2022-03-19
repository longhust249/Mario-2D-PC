using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    UIManager m_ui;
    public GameObject Obstacle;
    public float spawnTime;
    float m_spawnTime;
    bool m_isGameover;
    int m_score;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score: " + m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameover)
        {
            m_spawnTime = 0;
            m_ui.ShowGameoverPanel(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;
        if (m_spawnTime <= 0)
        {
            SpawnObstacle();
            m_spawnTime = spawnTime;
        }
    }
    public void SpawnObstacle()
    {
        float randYpos = Random.RandomRange(-2.2f, -1.2f);
        Vector2 spawnPos = new Vector2(12, randYpos);
        if (Obstacle)
        {
            Instantiate(Obstacle, spawnPos, Quaternion.identity);
        }
    }
    public void SetScore (int value)
    {
        m_score = value;
    }
    public int GetScore()
    {
        return m_score;
    }
    public void ScoreIncrement()
    {
        if (m_isGameover)
        {
            return;
        }
        m_score++;
        m_ui.SetScoreText("Score: " + m_score);
    }
    public bool IsGameover()
    {
        return m_isGameover;
    }
    public void SetGameoverState(bool state) 
    {
        m_isGameover = state;
    }
    public void Replay()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
