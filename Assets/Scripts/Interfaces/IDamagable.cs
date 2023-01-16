using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpatooGame.Interfaces
{
    /// <summary>
    /// Entity that can take damage
    /// </summary>
    public interface IDamagable : ICanDie, ITransform
    {
        List<Collider2D> Colliders { get; }

        /// <summary>
        /// Take damaga by an <see cref="ICanDamage"></see> which will have a <see cref="DamageSourceType"/>
        /// Situational damage taking calculations will be done by each object
        /// </summary>
        /// <param name="damageAmount">Amount of damage</param>
        /// <param name="DamageSource">Source of damage entity</param>
        // void TakeDamage(float damageAmount, Transform damageSource, DamageSourceType damageSourceType);
        void TakeDamage(float damageAmount, Transform damageSource);
    }
}
