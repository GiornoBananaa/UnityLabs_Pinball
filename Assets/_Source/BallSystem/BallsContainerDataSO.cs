using System;
using UnityEngine;

namespace BallSystem
{
    [Serializable]
    public class BallsContainerData
    {
        [field: SerializeField] public int BallsCount { get; private set; }
        [field: SerializeField] public Ball BallPrefab { get; private set; }
    }
}