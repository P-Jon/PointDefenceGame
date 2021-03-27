using System;
using System.Collections.Generic;
using System.Text;

namespace PointDefence.UI.Components
{
    public abstract class UIComponent
    {
        public abstract void update();

        public abstract void draw();
    }
}