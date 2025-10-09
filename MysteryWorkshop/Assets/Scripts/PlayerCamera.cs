using FishNet.Object;
using Unity.Cinemachine;
using UnityEngine;

// This script will be a NetworkBehaviour so that we can use the OnStartClient override.
public class PlayerCamera : NetworkBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;

    // This method is called on the client after the object is spawned in.
    public override void OnStartClient()
    {
        // Simply enable our local cinemachine camera on the object if we are the owner.
        cinemachineCamera = Instantiate(prefab, player.transform.position + offset, );
        cinemachineCamera.enabled = IsOwner;
        
        offset = cinemachineCamera.transform.position - player.transform.position;
    }
}