using System;
using UnityEngine;

public class BitScoreCalculator : MonoBehaviour, IScoreCalculator
{
    public ReactValue<int> score { get; private set; } = new ReactValue<int>();

    public void ResetScore()
    {
        score.val = 0;
    }

    private int _score;
    private const int _scoreForBallCollision = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
            score.val += _scoreForBallCollision;
    }
}
