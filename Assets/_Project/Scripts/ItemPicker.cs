using Project.Scripts.Items;
using UnityEngine;

namespace Project
{
    public class ItemPicker : MonoBehaviour
    {
        [SerializeField] private float _pickUpDistance = 2;
        [SerializeField] private float _handsDistance = 1;

        private Item _pickedItem;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && _pickedItem == null)
                PickUpItem();
            else if (Input.GetMouseButton(1) && _pickedItem != null)
                DropItem();
        }

        private void DropItem()
        {
            _pickedItem.Drop();
            _pickedItem.transform.parent = null;
            _pickedItem = null;
        }

        private void PickUpItem()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, _pickUpDistance))
            {
                if (hit.collider.gameObject.TryGetComponent<Item>(out Item item))
                {
                    item.PickUp();
                    item.transform.SetParent(transform);
                    item.transform.position = transform.position + transform.forward * _handsDistance;
                    _pickedItem = item;
                }
            }
        }
    }
}