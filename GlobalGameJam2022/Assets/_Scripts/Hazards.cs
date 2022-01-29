using UnityEngine;

public class Hazards : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collided with {collision.gameObject.tag}");

        if (collision.gameObject.tag == "Player")
        {
            MenuManager.Instance.UpdateResourceBar("anger", 100);
            GameManager.Instance.UpdateGameState(GameState.GameOver);
        }
    }
}
