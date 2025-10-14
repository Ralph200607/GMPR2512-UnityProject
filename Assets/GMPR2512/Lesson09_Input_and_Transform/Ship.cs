using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour
{
    private InputAction _moveAction, _spinAction;


    [SerializeField] float _movementSpeed, _spinSpeed;

    void Awake()
    {
        //this creates an input method that is decoupled from the input device
        _moveAction = InputSystem.actions.FindAction("Ship/Move");
        _spinAction = InputSystem.actions.FindAction("Ship/Rotate");
        Debug.Log(_moveAction);
    }
    void Update()
    {
        #region Movement
        Vector2 moveDirection = _moveAction.ReadValue<Vector2>();
        Debug.Log(moveDirection);

        Vector2 moveVelocity = moveDirection * _movementSpeed * Time.deltaTime;

        transform.Translate(moveVelocity, Space.World);
        #endregion
        //Exercise: give the player the ability to spin the triangle in either direction by pressing "j" or "k"
        #region Rotation
        float spincValue = _spinAction.ReadValue<float>() * _spinSpeed * Time.deltaTime;
        transform.Rotate(0, 0, spincValue);
        #endregion
    }
}
