using UnityEngine;
using UnityEngine.UI;

public class IncreaseFriendship : MonoBehaviour
{
    public Button button;
    public Enemy enemy;

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        enemy.IncreaseFriendship(enemy.friendshipIncrease);
    }
}