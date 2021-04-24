using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public ReactValue<int> score { get; private set; } = new ReactValue<int>();
    public ReactValue<int> bestScore { get; private set; } = new ReactValue<int>();

    [SerializeField] private PongController _pongController;

    private List<IScoreCalculator> _scoreCalculators = new List<IScoreCalculator>();

    private const string _bestScorePrefsKey = "BestScore";

    private void Awake()
    {
        LoadBestScore();

        var bitCalculators = FindObjectsOfType<BitScoreCalculator>();
        foreach (var calculator in bitCalculators)
            _scoreCalculators.Add(calculator);
    }

    private void OnEnable()
    {
        _pongController.onGameLaunched += ResetCurrentScore;
        _pongController.onGameFinished += SaveBestScore;

        foreach (var calculator in _scoreCalculators)
            calculator.score.onValueChanged += UpdateScore;
    }

    private void OnDisable()
    {
        _pongController.onGameLaunched -= ResetCurrentScore;
        _pongController.onGameFinished -= SaveBestScore;

        foreach (var calculator in _scoreCalculators)
            calculator.score.onValueChanged -= UpdateScore;
    }

    private void UpdateScore()
    {
        int sum = 0;
        foreach (var calculator in _scoreCalculators)
            sum += calculator.score.val;

        score.val = sum;

        UpdateBestScore();
    }

    private void UpdateBestScore()
    {
        bestScore.val = Mathf.Max(bestScore.val, score.val);
    }

    private void SaveBestScore()
    {
        PlayerPrefs.SetInt(_bestScorePrefsKey, bestScore.val);
    }

    private void LoadBestScore()
    {
        bestScore.val = PlayerPrefs.GetInt(_bestScorePrefsKey, 0);
    }

    private void ResetCurrentScore()
    {
        foreach (var calculator in _scoreCalculators)
            calculator.score.val = 0;
    }
}
