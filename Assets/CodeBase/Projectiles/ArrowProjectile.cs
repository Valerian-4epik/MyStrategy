using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using Utils = CodeBase.Services.Abstract.Utils;

namespace CodeBase.Projectiles
{
    public class ArrowProjectile : Projectile
    {
        private void Update()
        {
            Move();
            transform.eulerAngles = new Vector3(0, 0, Utils.GetAngleFromVector(MoveDirection));
        }
    }
}
