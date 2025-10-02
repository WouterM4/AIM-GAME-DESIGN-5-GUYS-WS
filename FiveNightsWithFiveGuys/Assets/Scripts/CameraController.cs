using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float MinPitch = -80f;
    private const float MaxPitch = 80f;
    
    [SerializeField] private Transform player;
    private Vector3 _offset;
    
    private void Start()
    {
        _offset = transform.position - player.position;
    }

    
    private void Update()
    {
        UpdatePosition();
        UpdateRotation();
    }

    private void UpdatePosition()
    {
        transform.position = player.position + _offset;
    }

    private void UpdateRotation()
    {
        var eulerAngles = transform.eulerAngles;
        transform.rotation = Quaternion.Euler(eulerAngles.x, player.eulerAngles.y, eulerAngles.z);
    }

    public void RotateVertically(float rotation)
    {
        transform.Rotate(Vector3.right, -rotation);
    }
}
