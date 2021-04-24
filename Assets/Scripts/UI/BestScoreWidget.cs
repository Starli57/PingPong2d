using UnityEngine;
using UnityEngine.UI;

public class BestScoreWidget : MonoBehaviour
{
    [SerializeField] private ScoreController _scoreController;
    [SerializeField] private Text _scoreValueTxt;

    private void OnEnable()
    {
        PrintScore();

        _scoreController.bestScore.onValueChanged += PrintScore;
    }

    private void OnDisable()
    {
        _scoreController.bestScore.onValueChanged -= PrintScore;
    }

    private void PrintScore()
    {
        _scoreValueTxt.text = _scoreController.bestScore.val.ToString();
    }
}
