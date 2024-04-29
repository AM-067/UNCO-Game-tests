using UnityEngine;

public class BulletController : MonoBehaviour
{

    private void OnEnable()
    {
        Invoke("Disable",2f);
    }
    
    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
