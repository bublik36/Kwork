using UnityEngine;

public class ScrapGo : MoveObject
{
    public float speed;
    private Rigidbody2D _rigidbody2D;
    public bool GoRight;
    public bool GoLeft;
    public bool GoUp; 
    public bool GoDown;
    private void OnEnable()
    {
        speed = UnityEngine.Random.Range(30f, 40f);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveObjectMeth(GoRight, GoLeft, GoUp, GoDown,_rigidbody2D,speed);
    }
}
