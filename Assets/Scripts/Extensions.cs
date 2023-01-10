using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GrooveCrusaders{
    
    public static class Utility{
        public static void ToggleEntityOutline(this MonoBehaviour self, bool toggle)
        {
            var actors = self.GetComponentsInChildren<Actor>();

            if (actors.Length >= 0){
                Debug.LogWarning($"Entity {self} has no actors.");
                return;
            }

            foreach (Actor actor in actors){
                actor.outline = toggle;
            }
                
        }
    }
}