using PlasticGui.WorkspaceWindow.History;
using UnityEngine;

namespace GMPR2512.Lesson07_Flipper
{
    public class Flipper : MonoBehaviour
    {
     private HingeJoint2D _joint2D;
        private JointMotor2D _motor;

        [SerializeField] private bool _rightFlipper;
        
        void Awake()
        {
            _joint2D = GetComponent<HingeJoint2D>();
        }

        void Update()
        {


            if (_rightFlipper)
            {
                _joint2D.useMotor = Input.GetKey(KeyCode.D);
            }
            else
            {
                _joint2D.useMotor = Input.GetKey(KeyCode.A);
            }


           

        }
    }
}