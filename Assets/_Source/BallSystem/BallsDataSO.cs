using UnityEngine;

namespace BallSystem
{
    [CreateAssetMenu(fileName = "BallsData", menuName = "BallsData")]
    public class BallsDataSO : ScriptableObject
    {
        [field: SerializeField] public BallsContainerData BallsContainerData { get; private set; }
        [field: SerializeField] public BallsLaunchingData BallsLaunchingData { get; private set; }
    }
}