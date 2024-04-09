using System;
using UnityEngine;

namespace BallSystem
{
    [Serializable]
    public class BallsLaunchingData
    {
        [field:SerializeField] public float LaunchMaxTime { get; private set; }
        [field:SerializeField] public float LaunchMaxForce { get; private set; }
        [field:SerializeField] public float LaunchMinForce { get; private set; }
        [field:SerializeField] public Vector3 LaunchDirection { get; private set; }
    }
}