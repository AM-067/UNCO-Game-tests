using UnityEngine;

public class CS_Aim : MonoBehaviour
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
    private Camera _mainCam;

    void Start()
    {
      
        _normalPosition = transform.localPosition;
        _aimPosition = new Vector3(_normalPosition.x, _normalPosition.y, _normalPosition.z + 1f);
        if (PlayerCameraTransform != null)
        {
            _mainCam = PlayerCameraTransform.GetComponent<Camera>(); 
        }
        else
        {
            Debug.Log("Cam not Found!");
        }
        
        _normalFieldOfView = _mainCam.fieldOfView;
    }

    void Update()
    {
        HandleAiming();
    }

    void HandleAiming()
    {
        if (_mainCam != null)
        {
            if (Input.GetMouseButton(1))
            {
            
                transform.localPosition = Vector3.Lerp(transform.localPosition, _aimPosition, AimSpeed * Time.deltaTime);


                _mainCam.fieldOfView = Mathf.Lerp(_mainCam.fieldOfView, MinFieldOfView, ZoomSpeed * Time.deltaTime);
            
          
                _isAiming = true;
            }
            else
            {
       
                transform.localPosition = Vector3.Lerp(transform.localPosition, _normalPosition, AimSpeed * Time.deltaTime);

         
                _mainCam.fieldOfView = Mathf.Lerp(_mainCam.fieldOfView, _normalFieldOfView, ZoomSpeed * Time.deltaTime);
        
                _isAiming = false;
            }
        }
        else
        {
            Debug.Log("Cam destroyed!");
        }
        
    }

    public bool IsAiming()
    {
        return _isAiming;
    }
}