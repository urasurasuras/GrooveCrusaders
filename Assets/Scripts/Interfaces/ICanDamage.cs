using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpatooGame.Interfaces
{    
    /// <summary>
    /// What kind of damage is this ICanDamage is doing? Used of Spatoo taking impact damage vs getting shot etc
    /// </summary>
    public enum DamageSourceType{
        NULL,
        Projectile,
        Kinematic,
        ElectricBlast
    }
    /// <summary>
    /// Interface for entities that can do damage
    /// </summary>
    public interface ICanDamage : ITransform
    {
        DamageSourceType DamageSourceType { get; }
    }
}