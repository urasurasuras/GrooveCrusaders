using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpatooGame.Interfaces
{
    public interface IElectrocutable : IDamagable
    {
        void Electrocute();
    }
}
