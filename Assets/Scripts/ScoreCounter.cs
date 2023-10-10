using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter instance;
    public Text scoreText;
    
    int score = 0;
    
    const int startScore = 0;
    

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        score = startScore;
        scoreText.text = score.ToString();
        
    }

    public void AddPoint()
    {
        
        score += 1;
        scoreText.text = score.ToString();
        
        
    }
    public void SetPoints()
    {
        score = startScore;
        scoreText.text = score.ToString();
    }
}
