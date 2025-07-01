using System.Collections;
using UnityEngine;

public class ScrapDeath : MonoBehaviour
{
    [SerializeField] private float TimeDeath;

    private void OnEnable()
    {
        StartCoroutine(Death());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<MoveMeteor>())
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(TimeDeath);
        Destroy(gameObject);
    }
}
