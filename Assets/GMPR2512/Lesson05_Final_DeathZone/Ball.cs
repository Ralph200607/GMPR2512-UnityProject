using UnityEngine;

namespace GMPR2512.Lesson05_Final_DeathZone
{
    public class Ball : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private void Awake()
        {
            //The GetCOmponent method is expensive, so we dont want to call it every update.'
            //Therefore, we get a reference to the component in Awake, and store it as a data member.
            _rb = this.GetComponent<Rigidbody2D>();
            if (_rb == null)
            {
                Debug.LogError("Ball class requires a RigidBody2D on the same GameObject.");
            }
        }
        // Update is called once per frame
        void Update()
        {

        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            string nameOfObjectIBumpedInto = collision.collider.name; //Storing DeathZOne name to nameOfObjectBumpedInto
            Debug.Log($"Ball collided with {nameOfObjectIBumpedInto}");
        }
    }
}
