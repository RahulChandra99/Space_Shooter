using System;
using UnityEngine;

namespace Space_Shooter.Code.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]private float _speed;
        [SerializeField]private float _upwardsSpeed;
        [SerializeField] private GameObject _laserPrefab;
        [SerializeField] private Vector2 offset;
        [SerializeField] private float _fireRate;
        private float _canFire = 0f;
        
        
        
        
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            MovePlayer(new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")));

            if (Input.GetKey(KeyCode.Space) && Time.time > _canFire)
            {
                FireLaser();
            }
        }

        private void FixedUpdate()
        {
            MoveUpwards();

            CheckPlayerBounds();
            
            
        }

        void MovePlayer(Vector2 direction)
        {
            //_rb.MovePosition((Vector2)transform.position + (direction * _speed * Time.deltaTime));
            transform.Translate(direction * _speed * Time.deltaTime);
        }

        void MoveUpwards()
        {
            _rb.velocity = Vector2.up * _upwardsSpeed * Time.fixedDeltaTime;
        }

        void CheckPlayerBounds()
        {
            if (transform.position.x < -2.8f)
            {
                transform.position = new Vector2(2.8f, transform.position.y);
            }
            else if (transform.position.x > 2.8f)
            {
                transform.position = new Vector3(-2.8f,transform.position.y);
            }
            
        }

        void FireLaser()
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, (Vector2) transform.position + offset, Quaternion.identity);
        }
        
    }
}
