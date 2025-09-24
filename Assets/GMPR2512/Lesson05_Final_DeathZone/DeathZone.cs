using System.Collections;
using UnityEngine;

namespace GMPR2512.Lesson05_Final_DeathZone
{
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        /* 
            If at least one of two game objects has a Rigidbody2D, and they both have Collider2Ds,
            when they collide the following three methods will be executed, if they exist, on both game ojects:
            OnCollisionEnter2D
            OnCollisionStay2D
            OnCollisionExit2D
        */

        void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log($"HIT!");

            //collision.collider = represents the collider of the game object that bumped into us
            //collision.otherCollider represents the colliders of the game object
            //to which this script is attached

            /*Destroy(collision.gameObject); <--- Parent object* */
            /* Destroy(collision.collider.gameObject); <--- Destroys the child object that collides with the object this file is attached to */
            /* Destroy(gameObject); // <--- Destroys the object itself the file is attached to */


            //what if we only want to destroy it if its a ball?
            //we can give the ball a "tag"

            if (collision.collider.CompareTag("Ball"))
            {
                // If your Ball has momentum, it might keep flying after respawning. You can reset its velocity like this:
                GameObject ball = collision.collider.gameObject;
                StartCoroutine(RespawnBall(ball));
                
            }

        }
        private IEnumerator RespawnBall(GameObject ball)
        {
            Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
            ballRb.linearVelocity = Vector2.zero;
            ballRb.angularVelocity = 0;
            //Or we could write it in one line
            //ball.collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            yield return new WaitForSeconds(2);

            // Respawns the Ball object after hitting DeathZone
            ball.gameObject.transform.position = _spawnPoint.position;
            
        }
    }
}
