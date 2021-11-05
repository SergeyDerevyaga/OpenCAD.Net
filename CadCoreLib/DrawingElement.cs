using System.Drawing;

namespace CadCoreLib
{
    public abstract class DrawingElement : CadObject
    {
        public abstract void Draw(Graphics g);
    }
}
