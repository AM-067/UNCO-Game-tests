using UnityEngine;

public class RBMovement : MonoBehaviour
{
    private Vector3 _playerMovementInput;
    private Vector2 _playerMouseInput;
    private float _xRot;

    [SerializeField] private Transform feetTransform;
    [SerializeField] private LayerMask floorMask;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private float speed;
    [SerializeField] private float sensivity;
    [SerializeField] private float jumpSpeed;
    
    // Update is called once per frame
    void Update()
    {
        _playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        _playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        
        MovePlayer();
        MovePlayerCamera();
        
    }

    private void MovePlayer()
    {
        if (playerBody != null)
        {
            Vector3 MoveVector = transform.TransformDirection(_playerMovementInput) * speed;
            playerBody.velocity = new Vector3(MoveVector.x, playerBody.velocity.y, MoveVector.z);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Physics.CheckSphere(feetTransform.position,0.1f,floorMask))
                {
                    playerBody.AddForce(Vector3.up * jumpSpeed,ForceMode.Impulse);    
                }
            
            }
        }
        else
        {
            Debug.Log("PLayer not found!");
        }
       
    }

    private void MovePlayerCamera()
    {
        if (playerCamera != null)
        {
            _xRot -= _playerMouseInput.y * sensivity;
        
            transform.Rotate(0f,_playerMouseInput.x * sensivity,0f);
            playerCamera.transform.localRotation = Quaternion.Euler(_xRot,0f,0f);
        }
        else
        {
            Debug.Log("Cam not found!");
        }
       
    }
}
