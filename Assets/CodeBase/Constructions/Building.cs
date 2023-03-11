using System;
using UnityEngine;

namespace CodeBase.Constructions
{
    public class Building : MonoBehaviour
    {
        public bool Placed { get; private set; }
        public BoundsInt area;
    }
}