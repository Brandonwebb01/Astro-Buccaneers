using UnityEngine;

namespace ShipBattleScripts 
{
    public class AnimatorController : MonoBehaviour
    {
        public Animator Explosion1_Large_0;

        private void Start()
        {
            Explosion1_Large_0 = GetComponent<Animator>();
        }

        public void StopAnimation()
        {
            Explosion1_Large_0.enabled = false;
        }
    }
}