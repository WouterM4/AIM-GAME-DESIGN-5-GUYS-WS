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
            var pickable = hit.transform.GetComponent<PickableItem>();

            if (pickable)
            {
                Debug.Log("PickUp item:" + pickable);
                PickItem(pickable);
                return;
            }

            if (hit.collider.gameObject.tag.Equals("Disposable")
                && pickedItem != null)
            {
                pickedItem.GameObject().SetActive(false);
            }
            // Debug.DrawLine(playerCamera.transform.position, hit.point, Color.orange, 1);
            // desiredLocation = hit.point;
        }
        Debug.Log("interacted");
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
