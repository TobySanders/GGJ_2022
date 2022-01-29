using UnityEngine;

public class EndGoal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.UpdateGameState(GameState.Victory);
        }
    }
}
