using System;
using System.Collections.Generic;
using UnityEngine;

public class PongController : MonoBehaviour
{
    public Ball ball { get; private set; }

    public Action onGameLaunched;
    public Action onGameFinished;

    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private List<BallData> _ballConfigurations;

    [Space]
    [SerializeField] private ScreenLimits _screenLimits;
    
    private void Awake()
    {
        StartGame();
    }

    private void OnDisable()
    {
        FinishGame();
    }

    private void Update()
    {
        if (IsBallOutside())
            ResetGame();
    }

    private void StartGame()
    {
        SpawnBallIfEmpty();
        InitializeBall();
        onGameLaunched?.Invoke();
    }

    private void FinishGame()
    {
        onGameFinished?.Invoke();
    }

    private void ResetGame()
    {
        FinishGame();
        StartGame();
    }

    private void SpawnBallIfEmpty()
    {
        if (ball == null)
            ball = Instantiate(_ballPrefab, Vector3.zero, Quaternion.identity);
    }

    private void InitializeBall()
    {
        int configIndex = UnityEngine.Random.Range(0, _ballConfigurations.Count);
        ball.Initialize(_ballConfigurations[configIndex]);
    }

    private bool IsBallOutside()
    {
        return _screenLimits.IsOutOfScreenLimits(ball.transform.position);
    }
}
