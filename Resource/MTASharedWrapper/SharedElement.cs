﻿using System;
using System.Collections.Generic;
using System.Text;
using MultiTheftAuto;

namespace MTASharedWrapper
{
    public class SharedElement
    {
        protected MultiTheftAuto.Element element;

        public bool Destroy()
        {
            return Shared.DestroyElement(element);
        }

        public Vector3 Position
        {
            get
            {
                Tuple<float, float, float> position = Shared.GetElementPosition(element);
                return new Vector3(position.Item1, position.Item2, position.Item3);
            }
            set
            {
                Shared.SetElementPosition(element, value.x, value.y, value.z, false);
            }
        }

        public Vector3 Rotation
        {
            get
            {
                Tuple<float, float, float> rotation = Shared.GetElementRotation(element, "default");
                return new Vector3(rotation.Item1, rotation.Item2, rotation.Item3);
            }
            set
            {
                Shared.SetElementRotation(element, value.x, value.y, value.z, "default", false);
            }
        }

        public int Dimension
        {
            get
            {
                return Shared.GetElementDimension(element);
            }
            set
            {
                Shared.SetElementDimension(element, value);
            }
        }

        public int Interior
        {
            get
            {
                return Shared.GetElementInterior(element);
            }
            set
            {
                Vector3 position = Position;
                Shared.SetElementInterior(element, value, position.x, position.y, position.z);
            }
        }

        public bool Frozen
        {
            get
            {
                return Shared.IsElementFrozen(element);
            }
            set
            {
                Shared.SetElementFrozen(element, value);
            }
        }

        public int Alpha
        {
            get
            {
                return Shared.GetElementAlpha(element);
            }
            set
            {
                Shared.SetElementAlpha(element, value);
            }
        }

        public float Health
        {
            get
            {
                return Shared.GetElementHealth(element);
            }
            set
            {
                Shared.SetElementHealth(element, value);
            }
        }

        public Vector3 Velocity
        {
            get
            {
                Tuple<float, float, float> velocity = Shared.GetElementVelocity(element);
                return new Vector3(velocity.Item1, velocity.Item2, velocity.Item3);
            }
            set
            {
                Shared.SetElementVelocity(element, value.x, value.y, value.z);
            }
        }
        
        public int Model
        {
            get
            {
                return Shared.GetElementModel(element);
            }
            set
            {
                Shared.SetElementModel(element, value);
            }
        }
    }
}
