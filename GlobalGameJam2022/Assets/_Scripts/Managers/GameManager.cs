using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject Player;

    public GameState state;
    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        Instance = this;
        state = GameState.ObjectPlacementPhase;
    }

    void Start()
    {
        UpdateGameState(GameState.ObjectPlacementPhase);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.ObjectPlacementPhase:
                HandleObjectPlacement();
                break;
            case GameState.MovementPhase:
                HandleMovementPhase();
                break;
            case GameState.Victory:
                break;
            case GameState.GameOver:
                HandleGameOver();
                break;
            case GameState.Restart:
                HandleRestart();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleObjectPlacement()
    {
        Debug.Log("Entering ObjectPlacement phase");
    }

    private void HandleMovementPhase()
    {
        Debug.Log("Entering PlayerMovement phase");
    }

    private void HandleGameOver()
    {
        Debug.Log("Entering Game Over phase");
        Player.GetComponent<TestBabyController>().enabled = false;
    }
    private void HandleRestart()
    {
        SceneManager.LoadScene("Henry Test");
    }
}

public enum GameState
{
    ObjectPlacementPhase,
    MovementPhase,
    Victory,
    GameOver,
    Restart
}