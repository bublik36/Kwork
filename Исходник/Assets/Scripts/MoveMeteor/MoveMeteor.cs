using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveMeteor : MoveObject
{
    public float speed;
    private Rigidbody2D _rigidbody2D;
    public bool GoRight;
    public bool GoLeft;
    public bool GoUp; 
    public bool GoDown;
    
    private void OnEnable()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(TimeDeath());
    }

    private void Update()
    {
        MoveObjectMeth(GoRight, GoLeft, GoUp, GoDown,_rigidbody2D,speed);
    }

    private IEnumerator TimeDeath()
    {
        yield return new WaitForSeconds(60f);
        Destroy(gameObject);
    }
}
