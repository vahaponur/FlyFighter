using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreBoard : MonoBehaviour
{
    #region Serialized Fields
    #endregion

    #region Private Fields
    private int _levelScore = 0;
    TextMeshProUGUI _scoreText;
    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods
    private void Awake()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        UpdateScore();
    }
    #endregion

    #region PublicMethods
    /// <summary>
    /// Increases the current player score by given amount
    /// </summary>
    /// <param name="increaseAmount">How much the score will increase</param>
    public void IncreaseScore(int increaseAmount)
    {
        _levelScore += increaseAmount;
        UpdateScore();

    }

    /// <summary>
    /// Decreases the current player score by given amount
    /// </summary>
    /// <param name="decreaseAmount">How much the scıore will decrease</param>
    public void DecreaseScore(int decreaseAmount)
    {
        _levelScore -= decreaseAmount;
        UpdateScore();
    }

    void UpdateScore()
    {
        string scoreText = "Score: " + _levelScore;
        _scoreText.text = scoreText;
    }
    #endregion

    #region PrivateMethods
    #endregion
}
