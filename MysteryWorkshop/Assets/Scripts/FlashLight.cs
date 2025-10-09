using UnityEngine;
using FishNet.Object;
using UnityEngine.InputSystem;
public class FlashLight : NetworkBehaviour
{

    [SerializeField] public GameObject on;
    [SerializeField] public GameObject Off;
    private bool _onState;
    void Start()
    {
        on.SetActive(false);
        Off.SetActive(true);
        _onState = false;
    }
    public override void OnStartClient()
    {
        if (IsOwner)
            GetComponent<PlayerInput>().enabled = true;
    }
    public void OnFlash(InputValue value)
    {
        if (!IsOwner)
            return;

        ToggleFlashlight(!_onState);
        ToggleFlashlightServer(!_onState);
    }

    [ServerRpc]
    private void ToggleFlashlightServer(bool newState)
    {
        ToggleFlashlightObservers(newState);
    }

    [ObserversRpc]
    private void ToggleFlashlightObservers(bool newState)
    {
        ToggleFlashlight(newState);
    }

    private void ToggleFlashlight(bool newState)
    {
        _onState = newState;
        on.SetActive(_onState);
        Off.SetActive(!_onState);
        Debug.Log($"Flashlight is now {(_onState ? "ON" : "OFF")}");
    }
    // Update is called once per frame
    void Update()
    {
        
        if (!IsOwner)
            return;
    }
}
