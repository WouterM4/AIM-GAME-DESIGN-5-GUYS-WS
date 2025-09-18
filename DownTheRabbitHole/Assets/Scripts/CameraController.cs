using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{

    // public GameObject player;
    // public float sensitivity;
    // private Vector3 positionOffset;
    // private Vector3 rotation;
    //
    //
    // // Start is called before the first frame update
    // void Start()
    // {
    //     positionOffset = transform.position - player.transform.position;
    // }
    //
    // // Update is called once per frame
    // void LateUpdate()
    // {
    //     transform.position = player.transform.position + positionOffset;
    // }
    //
    // void FixedUpdate()
    // {
    //     transform.RotateAround (player.transform.position, -Vector3.up, rotation.x * sensitivity);
    // }
    //
    // void OnLook(InputValue movementValue)
    // {
    //     float rotateHorizontal = movementValue.Get<Vector2>().x;
    //     float rotateVertical = movementValue.Get<Vector2>().y;
    //     rotation = new Vector3 (rotateHorizontal, 0.0f, rotateVertical);
    // }
}