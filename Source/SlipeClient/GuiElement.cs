﻿using Slipe.Shared;
using Slipe.MTADefinitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slipe.Client
{
    public abstract class GUIElement: Element
    {
        public bool Visible
        {
            get
            {
                return MTAClient.GuiGetVisible(element);
            }
            set
            {
                MTAClient.GuiSetVisible(element, value);
            }
        }

        public float Alpha
        {
            get
            {
                return MTAClient.GuiGetAlpha(element);
            }
            set
            {
                MTAClient.GuiSetAlpha(element, value);
            }
        }

        public GUIElement()
        {

        }

        public GUIElement(MTAElement element): base(element)
        {

        }
    }
}