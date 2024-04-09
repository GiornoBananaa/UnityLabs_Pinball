using BallSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private GameInputAction _inputAction;
        private BallLauncher _ballLauncher;
        
        public void Construct(BallLauncher ballLauncher)
        {
            _ballLauncher = ballLauncher;
        }

        private void Awake()
        {
            _inputAction = new();
            EnableReadingInput();
        }

        private void EnableReadingInput()
        {
            _inputAction.GlobalActionMap.LaunchBall.started += StartLaunchingBall;
            _inputAction.GlobalActionMap.LaunchBall.canceled += LaunchBall;
            _inputAction.Enable();
        }
        
        private void DisableReadingInput()
        {
            _inputAction.GlobalActionMap.LaunchBall.started -= StartLaunchingBall;
            _inputAction.GlobalActionMap.LaunchBall.canceled -= LaunchBall;
            _inputAction.Disable();
        }
        
        private void StartLaunchingBall(InputAction.CallbackContext context)
        {
            _ballLauncher.StartSpringTension();
        }
        
        private void LaunchBall(InputAction.CallbackContext context)
        {
            _ballLauncher.LaunchBall();
        }
        
        private void OnDestroy()
        {
            DisableReadingInput();
        }
    }
}
