using UnityEngine;
using UnityEngine.UI;

public class CurrentScoreWidget : MonoBehaviour
{
    [SerializeField] private ScoreController _scoreController;
    [SerializeField] private Text _scoreValueTxt;

    private void OnEnable()
    {
        PrintScore();

        _scoreController.score.onValueChanged += PrintScore;    
    }

    private void OnDisable()
    {
        _scoreController.score.onValueChanged -= PrintScore;
    }

    private void PrintScore()
    {
        _scoreValueTxt.text = _scoreController.score.val.ToString();
    }
}
