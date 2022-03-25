using UnityEngine;

namespace ANKU.Movements.Concretes
{
    public class MagicMovement : MonoBehaviour
    {
        [SerializeField] private float objectMoveSpeed;
        private Rigidbody _rb;

        private bool _objectSpawned;

        private void Awake()
        {
            _objectSpawned = true;
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (_objectSpawned)
            {
                _rb.velocity += Camera.main.transform.forward * (objectMoveSpeed * Time.deltaTime);
                _objectSpawned = false;
            }
            // _rb.AddForce(transform.TransformDirection(Camera.main.transform.forward) * (objectMoveSpeed * Time.deltaTime));
        }
    }
}