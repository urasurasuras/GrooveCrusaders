using UnityEngine.Events;

namespace SpatooGame.Interfaces
{
    /// <summary>
    /// Entity that can take cease to exist
    /// </summary>
    public interface ICanDie : ITransform
    {
        /// <summary>
        /// Gets invoked when death is meant to happen for this entity
        /// </summary>
        UnityEvent Death { get; }
    }
}
