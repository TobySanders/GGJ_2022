using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject _objectPlacementPanel;
    public GameObject _gameOverPanel, _victoryPanel;
    public GameObject _angerBar;

    public static MenuManager Instance;

    void Awake()
    {
        Instance = this;
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        _objectPlacementPanel.SetActive(state == GameState.ObjectPlacementPhase);
        _gameOverPanel.SetActive(state == GameState.GameOver);
        _victoryPanel.SetActive(state == GameState.Victory);
    }

    public void UpdateResourceBar(string bar, float amount)
    {
        if(bar == "anger")
        {
            _angerBar.GetComponent<Image>().fillAmount += amount;
        }
    }
}
