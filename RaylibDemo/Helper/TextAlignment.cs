using Raylib_cs;

namespace PointDefence.Helper
{
    public class TextAlignment
    {
        public static int MiddleYAlignmentRect(Rectangle rect, int fontSize)
        {
            return (int)rect.y + (((int)rect.height / 2) - (int)(fontSize * 0.5));
        }
    }
}