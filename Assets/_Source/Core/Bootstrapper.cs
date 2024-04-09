using System;
using BallSystem;
using InputSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        private const string BALLS_DATA_PATH = "BallsData";
        
        [SerializeField] private ServiceUpdater _serviceUpdater;
        [SerializeField] private InputListener _inputListener;
        private BallLauncher _ballLauncher;
        private BallsContainer _ballContainer;

        private void Awake()
        {
            // SO
            BallsDataSO ballsData = Resources.Load<BallsDataSO>(BALLS_DATA_PATH);
            // BallsContainer
            BallsContainerData containerData = ballsData.BallsContainerData;
            _ballContainer = new BallsContainer(containerData);
            // BallsLaunching
            BallsLaunchingData launchingData = ballsData.BallsLaunchingData;
            UpdateTimer launcherTimer = new UpdateTimer(_serviceUpdater);
            _ballLauncher = new BallLauncher(_ballContainer, launcherTimer, launchingData);
            //Input
            _inputListener.Construct(_ballLauncher);
        }
    }
}
