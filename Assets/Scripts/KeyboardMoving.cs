using UnityEngine;

public class KeyboardMoving : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private int _runSpeed;
    [SerializeField] private float _jumpForce;
    private bool _isGrounded;
    [SerializeField] private Rigidbody _playerRigidBody;

    private void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
            _isGrounded = true;
    }
    private void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _playerRigidBody.AddForce(Vector3.up * _jumpForce);
            _isGrounded = false;
        }
    }
    private void Move()
    {
        float directionX = Input.GetAxis("Horizontal");
        float directionY = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3 (directionX, 0,  directionY);

        if (Input.GetKey(KeyCode.LeftShift))
            transform.Translate(moveDirection * _runSpeed * Time.fixedDeltaTime);
        else
            transform.Translate(moveDirection * _speed * Time.fixedDeltaTime);
    }
}
