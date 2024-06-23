using UnityEngine;
using UnityEngine.UI;

public class CharacterAnimationControllerWithBomb : MonoBehaviour
{
    public Animator animator; // Assign this in the inspector
    public Button attackButton; // Assign this in the inspector
    public Button BombButton;

    void Start()
    {
        attackButton.onClick.AddListener(Attack);
        BombButton.onClick.AddListener(Attack);
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }
}