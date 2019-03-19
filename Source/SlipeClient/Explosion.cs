﻿using Slipe.Shared;
using Slipe.Shared.Enums;
using Slipe.MTADefinitions;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Slipe.Client
{
    /// <summary>
    /// An explosion in the physical world
    /// </summary>
    public class Explosion
    {
        /// <summary>
        /// Create an explosion of a specific type at a certain position
        /// </summary>
        public static bool Create(Vector3 position, ExplosionType type, bool makeSound = true, float camShake = -1)
        {
            return MTAClient.CreateExplosion(position.X, position.Y, position.Z, (int) type, makeSound, camShake);
        }

        private Explosion()
        {

        }
    }
}
