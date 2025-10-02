using Unity.VisualScripting;
using UnityEngine;

public class ItemGrabber : MonoBehaviour
{
    public Camera playerCamera;
    private Vector2 mousePosition;
    private Vector3 desiredLocation;
    
    [SerializeField] private Transform slot;

    private PickableItem pickedItem;

    private void OnInteract()
    {
        Ray clickRay = playerCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(clickRay, out hit))
        {
            
            if (hit.collider.gameObject.tag.Equals("pickup"))
            {
                var pickable = hit.transform.GetComponent<PickableItem>();
                PickItem(pickable);
                Debug.Log("item found");
            }

            if (hit.collider.gameObject.tag.Equals("Disposable")
                // && pickedItem != null
                )
            {
                pickedItem.GameObject().SetActive(false);
                Debug.Log("disposable found");
            }
            Debug.Log("Reached");
        }
    }
    
    private void PickItem(PickableItem item)
    {
        pickedItem = item;

        item.Rb.isKinematic = true;
        item.Rb.linearVelocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;

        item.transform.SetParent(slot);

        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;
    }

    private void DropItem(PickableItem item)
    {
        pickedItem = null;

        item.transform.SetParent(null);

        item.Rb.isKinematic = false;

        item.Rb.AddForce(item.transform.forward * 2, ForceMode.VelocityChange);
    }
}
