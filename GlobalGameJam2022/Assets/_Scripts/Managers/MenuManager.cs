using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject _objectPlacementPannel;

    void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        _objectPlacementPannel.SetActive(state == GameState.ObjectPlacementPhase);
    }
}
