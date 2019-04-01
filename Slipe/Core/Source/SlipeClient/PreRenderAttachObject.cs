﻿using System;
using System.Collections.Generic;
using System.Text;
using Slipe.Shared;
using Slipe.Shared.Interfaces;
using System.Numerics;

namespace Slipe.Client
{
    public abstract class PreRenderAttachObject : IAttachable
    {
        protected PhysicalElement toAttached;

        /// <summary>
        /// A matrix describing the offset with which this attachable is attached
        /// </summary>
        public Matrix4x4 Offset { get; set; }

        /// <summary>
        /// Get the Physical Element to which this attachable is attached
        /// </summary>
        public PhysicalElement ToAttached
        {
            get
            {
                return toAttached;
            }
        }

        /// <summary>
        /// Get if this attachable is attached to a ToAttachable
        /// </summary>
        public bool IsAttached
        {
            get
            {
                return toAttached != null;
            }
        }

        /// <summary>
        /// Attach this attachable to a toAttachable using a matrix to describe the positional and rotational offset
        /// </summary>
        public void AttachTo(PhysicalElement toElement, Matrix4x4 offsetMatrix)
        {
            toAttached = toElement;
            Offset = offsetMatrix;
            Client.Renderer.OnPreRender += Update;
        }

        /// <summary>
        /// Attach this attachable to a toAttachable with 2 vectors describing a position offset and a rotation offset
        /// </summary>
        public void AttachTo(PhysicalElement toElement, Vector3 positionOffset, Vector3 rotationOffset)
        {
            AttachTo(toElement, positionOffset, NumericHelper.EulerToQuaternion(rotationOffset));
        }

        /// <summary>
        /// Attach this attachable to a toAttachable with a vector describing the position offset and a quaternion describing the rotation offset
        /// </summary>
        public void AttachTo(PhysicalElement toElement, Vector3 positionOffset, Quaternion rotationOffset)
        {
            AttachTo(toElement, Matrix4x4.Transform(Matrix4x4.CreateTranslation(positionOffset), rotationOffset));
        }

        /// <summary>
        /// Attach this attachable to a toAttachable without any offset
        /// </summary>
        public void AttachTo(PhysicalElement toElement)
        {
            AttachTo(toElement, Matrix4x4.Identity);
        }

        /// <summary>
        /// Detach this attachable
        /// </summary>
        public void Detach()
        {
            Client.Renderer.OnPreRender -= Update;
        }

        /// <summary>
        /// Updates this element to the correct position and rotation
        /// </summary>
        protected abstract void Update();
    }
}