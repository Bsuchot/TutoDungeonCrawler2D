using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1.5f;

    public int damage = 10;

    public SpriteRenderer spriteRenderer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformAttack();
        }
    }

    void PerformAttack()
    {
        Vector2 attackDirection = spriteRenderer.flipX ? Vector2.left : Vector2.right;

        Collider2D[] hitCollider = Physics2D.OverlapCircle(transform.position, attackRange);

        foreach (Collider2D collider in hitCollider)
        {
            if (collider.CompareTag("Enemy"))
            {
                Vector2 directionEnemy = (collider.transform.position - transform.position).normalized;

                if(Vector2.Dot(attackDirection, directionEnemy) > 0)
                {
                    Debug.log("L'attaque a touché l'ennemi");
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
