using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;  If you use TextMeshPro in Canvas

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text coinsText;
    public Text livesText;
    public Text nutCoinsText;
    int score;
    int nutCoinsScore;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        coinsText.text = "X " + score.ToString();
    }

    public void ChangeNutCoinsScore(int coinValue)
    {
        nutCoinsScore += coinValue;
        nutCoinsText.text = " "+nutCoinsScore.ToString();
    }

    public void ChangeLives(int lives)
    {
        //Player player = GetComponent<Player>();
        //Debug.Log(player.lives);
        livesText.text = "X " + lives.ToString();
    }

}
