using UnityEngine;

namespace GMPR2512.Lesson04
{
    public class DeathZone : MonoBehaviour
    {

        public int _year = 1000;
        protected int _frameCounter = 0;
        protected float _numSeconds = 0;

        void Awake()
        {
            Debug.Log("I'm awake! and its the year " + _year);
            _year += 1025;
        }

        void Start()
        {
            Debug.Log($"Let's get started! Its finally the year {_year}");
        }

        // Update is called once per frame
        void Update()
        {
            _numSeconds += Time.deltaTime;
            //Debug.Log($"This scene has been running for {_numSeconds:F2}");

            //Debug.Log($"The time that has passed since the last call to Update is {Time.deltaTime}");
            //Debug.Log($"Frame Number {_frameCounter++}");
            if (_frameCounter > 60)
            {
                _frameCounter = 0;
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log($"KACHOOW!");

            //collision.collider = represents the collider of the game object that bumped into us
            //collision.otherCollider represents the colliders of the game object
            //to which this script is attached

            
            Destroy(collision.collider.gameObject);
            Destroy(gameObject); 
        }
    }
}
