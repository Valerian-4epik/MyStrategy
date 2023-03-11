using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using Utils = CodeBase.Services.Abstract.Utils;

namespace CodeBase.Projectiles
{
    public class MageSphereProjectile : Projectile
    {
        private void Update()
        {
            Move();
        }
    }
}
