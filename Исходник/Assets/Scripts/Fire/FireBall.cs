using System.Collections;
using UnityEngine;

public class FireBall : MonoBehaviour
{   
    private Animator animator;
    [SerializeField] private int Damage;
    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(TimeDeath());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<Health>())
        {
            other.gameObject.GetComponent<Health>().TakeDamage(Damage);
            Death();
        }

        if (other.gameObject.GetComponent<ScrapGo>())
        {
            Destroy(other.gameObject);
            Death();
        }
        else
        {
            return;
        }
    }

    private IEnumerator TimeDeath()
    {
        yield return new WaitForSeconds(4f);
        animator.SetTrigger("Death");
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
