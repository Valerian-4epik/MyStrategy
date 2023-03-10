using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using Utils = CodeBase.Services.Abstract.Utils;

namespace CodeBase.Projectiles
{
    public class ArrowProjectile : Projectile
    {
        protected override void Update()
        {
            base.Update();
            transform.eulerAngles = new Vector3(0, 0, Utils.GetAngleFromVector(MoveDirection));
        }
    }
}
