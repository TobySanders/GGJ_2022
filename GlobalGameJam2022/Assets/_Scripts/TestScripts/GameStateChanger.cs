using UnityEngine;
using UnityEngine.UI;

public class GameStateChanger : MonoBehaviour
{
    public Button gameStateButton;
    public GameState state;

    void Start()
    {
        Button btn = gameStateButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log($"GameState updated to {state}");

        GameManager.Instance.UpdateGameState(state);
    }
}

