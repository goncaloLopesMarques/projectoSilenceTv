using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Silence
{
    public class SwipeableImage : Image
    {
        public event EventHandler SwipedLeft;
        public event EventHandler SwipedRight;

        public void RaiseSwipedLeft()
        {
            if (SwipedLeft != null)
                SwipedLeft(this, new EventArgs());
        }
        public void RaiseSwipedRight()
        {
            if (SwipedRight != null)
                SwipedRight(this, new EventArgs());
        }
    }
}
