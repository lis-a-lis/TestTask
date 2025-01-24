using UnityEngine;

namespace Project.Scripts.Items
{
    [RequireComponent(typeof(Rigidbody))]
    public class Item : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        public void PickUp()
        {
            _rigidbody.isKinematic = true;
        }

        public void Drop()
        {
            _rigidbody.isKinematic = false;
            _rigidbody.WakeUp();
        }
    }
}
