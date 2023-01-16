using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpatooGame.Interfaces
{    
    /// <summary>
    /// Interface for entities that are able to be locked on by the targeting system
    /// </summary>
    public interface ITargetable : IDamagableWithHealth, IDamagable
    {
        /// <summary>
        /// Name to be displayed on the target UI
        /// </summary>
        string Name { get; }

        
        Rigidbody Rigidbody { get; }

        /// <summary>
        /// Largest dimension of collider bounds
        /// </summary>
        float max_size { get; }

        /// <summary>
        /// Pretty self explanatory
        /// </summary>
        bool allowSoftTargeting { get; }
        bool allowMissileHome { get; }       
    }
}