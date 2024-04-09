using System;
using Core;
using UnityEngine;

namespace BallSystem
{
    public class BallLauncher
    {
        private readonly BallsContainer _ballsContainer;
        private readonly UpdateTimer _launchingTimer;
        private readonly Vector3 _launchDirection;
        private readonly float _launchMaxTime;
        private readonly float _launchMaxForce;
        private readonly float _launchMinForce;
        
        public Action OnBallLaunch;

        public BallLauncher(BallsContainer ballsContainer, UpdateTimer launchingTimer, BallsLaunchingData ballsLaunchingData)
        {
            _ballsContainer = ballsContainer;
            _launchingTimer = launchingTimer;
            _launchMaxTime = ballsLaunchingData.LaunchMaxTime;
            _launchMaxForce = ballsLaunchingData.LaunchMaxForce;
            _launchMinForce = ballsLaunchingData.LaunchMinForce;
            _launchDirection = ballsLaunchingData.LaunchDirection;
        }
        
        public void StartSpringTension()
        {
            if (_ballsContainer.GetNewBall())
            {
                _launchingTimer.SetMaxTime(_launchMaxTime);
                _launchingTimer.Restart();
            }
        }
    
        public void LaunchBall()
        {
            if (_ballsContainer.CurrentBall != null && !_ballsContainer.BallIsPlaying)
            {
                _ballsContainer.CurrentBall.Rigidbody.AddForce(_launchDirection * Mathf.Lerp(_launchMinForce,_launchMaxForce,_launchingTimer.ElapsedTime/_launchMaxTime));
                OnBallLaunch?.Invoke();
                _launchingTimer.Stop();
                _ballsContainer.PlayBall();
            }
        }
    }
}
