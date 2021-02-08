using System;
using UnityEngine;

namespace Space_Shooter.Code.Scripts
{
    public class LaserController : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
            Destroy(this.gameObject,2f);
        }
    }
}
