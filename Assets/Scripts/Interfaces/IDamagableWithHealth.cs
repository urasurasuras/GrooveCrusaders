using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpatooGame.Interfaces
{
    public interface IDamagableWithHealth : IDamagable
    {
        /// <summary>
        /// Current health points
        /// </summary>
        float currentHP { get; set; }
        /// <summary>
        /// Maximum health points
        /// </summary>
        float maxHP { get; }

        /// <summary>
        /// Show shield UI if true
        /// </summary>
        bool isSupposedToHaveShield { get; }

        /// <summary>
        /// Current shield points
        /// </summary>
        float currentSP { get; set; }
        /// <summary>
        /// Maximum shield points
        /// </summary>
        float maxSP { get; }
    }
}
