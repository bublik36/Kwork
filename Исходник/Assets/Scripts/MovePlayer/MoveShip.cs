using UnityEngine;
using YG;
public class MoveShip : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float speed;
    public float speedOnPhone;
    [SerializeField] private Joystick joystick;
    [SerializeField] private GameObject joystickObject;
    [SerializeField] private GameObject fireButton;
    private Vector2 movementDirection;
    [SerializeField] private float speedRotation;
    private bool OnPlayZone;
    public bool CanMove;
    
    
    private void Awake()
    {
        CanMove = true;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (YG2.envir.isMobile && CanMove)
        {
            joystickObject.SetActive(true);
            fireButton.SetActive(true);
            float x = joystick.Horizontal;
            float y = joystick.Vertical;
            movementDirection = new Vector2(x, y).normalized;
            _rigidbody2D.velocity = movementDirection * speedOnPhone * Time.fixedDeltaTime;
            if (movementDirection != Vector2.zero)
            {
                Debug.Log("Rotate");
                float angle = Mathf.Atan2(x, -y) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speedRotation * Time.fixedDeltaTime);
            }
        }
        else if (YG2.envir.isDesktop && CanMove)
        {
            joystickObject.SetActive(false);
            fireButton.SetActive(false);
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            if (Input.GetMouseButton(0) && x == 0 && y == 0)
            {
                Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                movementDirection = new Vector2(MousePos.x - transform.position.x, MousePos.y - transform.position.y);
                _rigidbody2D.velocity = movementDirection * speed * Time.fixedDeltaTime;
                if (movementDirection != Vector2.zero)
                {
                    Debug.Log("Rotate");
                    float angle = Mathf.Atan2(movementDirection.x, -movementDirection.y) * Mathf.Rad2Deg;
                    Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speedRotation * Time.fixedDeltaTime);
                }
            }
            else if (x != 0 || y != 0)
            {
                movementDirection = new Vector2(x, y).normalized;
                _rigidbody2D.velocity = movementDirection * speedOnPhone * Time.fixedDeltaTime;
                if (movementDirection != Vector2.zero)
                {
                    Debug.Log("Rotate");
                    float angle = Mathf.Atan2(x, -y) * Mathf.Rad2Deg;
                    Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speedRotation * Time.fixedDeltaTime);
                }
            } 
        }
    
        // if (x > 0 && Input.GetKey(KeyCode.E) && transform.rotation.eulerAngles.z > 0)
        // {
        //     transform.Rotate(Vector3.forward * -speedRotation * Time.fixedDeltaTime);
        // }
        // else if (x < 0 && Input.GetKey(KeyCode.Q) && transform.rotation.eulerAngles.z > 0)
        // {
        //     transform.Rotate(Vector3.forward * speedRotation * Time.fixedDeltaTime);
        // }

    }
}