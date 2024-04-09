using UnityEngine;

namespace BallSystem
{
    public class Ball : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    }
}
