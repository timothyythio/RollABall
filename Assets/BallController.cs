using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody sphereRigidbody;
    [SerializeField] private float ballSpeed = 2f;
    [SerializeField] private bool onGround; 


    public void MoveBall(Vector2 input)
    {
        
        Vector3 inputXZPlane = new Vector3(input.x, 0, input.y);
        // made it so that the ball can't be moved while on air, doesn't make a lot of sense
        if (onGround)
        {
            sphereRigidbody.AddForce(inputXZPlane * ballSpeed);
        }
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            sphereRigidbody.AddForce(Vector3.up * 10f, ForceMode.Impulse);
            onGround = false;
        }

    }

    //Adds gravity to make the jump and fall more realistic
    private void FixedUpdate()
    {
        sphereRigidbody.AddForce(Physics.gravity * 5 * sphereRigidbody.mass);
    }

    void OnCollisionStay()
    {
        onGround = true;
    }

    void Start()
    {
        Debug.Log("Calling the Start method");
    }

    void Update()
    {
        
        
    }
}
