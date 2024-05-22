using UnityEngine;
using UnityEngine.UI;

public class IncreaseFriendship : MonoBehaviour
{
    public Button button;
    public Enemy enemy;
    public Player player; // Reference to the player script

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        enemy.IncreaseFriendship(enemy.friendshipIncrease);

        // Assuming increasing friendship makes the player gain health
        player.ModifyHealth(enemy.playerHealthIncrease);
    }
}