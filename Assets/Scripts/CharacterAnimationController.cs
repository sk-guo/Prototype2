using UnityEngine;
using UnityEngine.UI;

public class CharacterAnimationController : MonoBehaviour
{
    public Animator animator; // Assign this in the inspector
    public Button attackButton; // Assign this in the inspector

    void Start()
    {
        attackButton.onClick.AddListener(Attack);
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }
}