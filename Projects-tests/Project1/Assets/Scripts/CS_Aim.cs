using UnityEngine;

public class NewAimSystem : MonoBehaviour
{
    public Transform PlayerCameraTransform;
    public float AimSpeed = 10f;
    public float MaxFieldOfView = 60f;
    public float MinFieldOfView = 30f;
    public float ZoomSpeed = 20f;

    private Vector3 _normalPosition;
    private Vector3 _aimPosition;
    private float _normalFieldOfView;
    private bool _isAiming = false;

    void Start()
    {
      
        _normalPosition = transform.localPosition;
        _aimPosition = new Vector3(_normalPosition.x, _normalPosition.y, _normalPosition.z + 1f);
        _normalFieldOfView = PlayerCameraTransform.GetComponent<Camera>().fieldOfView;
    }

    void Update()
    {
        HandleAiming();
    }

    void HandleAiming()
    {
        if (Input.GetMouseButton(1))
        {
            
            transform.localPosition = Vector3.Lerp(transform.localPosition, _aimPosition, AimSpeed * Time.deltaTime);

      
            PlayerCameraTransform.GetComponent<Camera>().fieldOfView = Mathf.Lerp(PlayerCameraTransform.GetComponent<Camera>().fieldOfView, MinFieldOfView, ZoomSpeed * Time.deltaTime);

          
            _isAiming = true;
        }
        else
        {
       
            transform.localPosition = Vector3.Lerp(transform.localPosition, _normalPosition, AimSpeed * Time.deltaTime);

         
            PlayerCameraTransform.GetComponent<Camera>().fieldOfView = Mathf.Lerp(PlayerCameraTransform.GetComponent<Camera>().fieldOfView, _normalFieldOfView, ZoomSpeed * Time.deltaTime);

        
            _isAiming = false;
        }
    }

    public bool IsAiming()
    {
        return _isAiming;
    }
}