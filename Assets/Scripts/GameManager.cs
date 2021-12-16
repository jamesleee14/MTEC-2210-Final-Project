using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshPro scoretext;

    void Start()
    {
        
    }

    void Update()
    {
        scoretext.text = score.ToString("0000-Press R to restart.");
        
    }

    public void IncreaseScore(int value)
    {
        score += value;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}