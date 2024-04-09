using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BallSystem
{
    public class BallsContainer
    {
        private Stack<Ball> _availableBalls;
        private Stack<Ball> _unavailableBalls;
        private Ball _ballPrefab;
        
        public Ball CurrentBall { get; private set; }
        public bool BallIsPlaying { get; private set; }
        
        public Action<int> OnBallsCountChanged;
        
        
        public BallsContainer(BallsContainerData containerData)
        {
            _availableBalls = new Stack<Ball>();
            _unavailableBalls = new Stack<Ball>();
            _ballPrefab = containerData.BallPrefab;
            InstantiateBalls(containerData.BallsCount);
        }
        
        public Ball GetNewBall()
        {
            if (_availableBalls.Count == 0 || CurrentBall != null)
                return null;
            CurrentBall = _availableBalls.Pop();
            CurrentBall.gameObject.SetActive(true);
            OnBallsCountChanged?.Invoke(_availableBalls.Count);
            return CurrentBall;
        }

        public void PlayBall()
        {
            BallIsPlaying = true;
        }
        
        public void ReturnBall()
        {
            if (CurrentBall == null)
                return;
            _unavailableBalls.Push(CurrentBall);
            CurrentBall = null;
            BallIsPlaying = false;
        }
        
        private void InstantiateBalls(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Ball ball =  Object.Instantiate(_ballPrefab);
                ball.gameObject.SetActive(false);
                _availableBalls.Push(ball);
            }
            OnBallsCountChanged?.Invoke(_availableBalls.Count);
        }
    }
}