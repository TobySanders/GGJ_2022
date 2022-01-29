using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
}

public enum GameState
{
    ObjectPlacementPhase,
    MovementPhase,
    Victory,
    GameOver
}