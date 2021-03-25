using Raylib_cs;

namespace RaylibDemo.Helper
{
    public class TextAlignment
    {
        public static int MiddleYAlignmentRect(Rectangle rect, int fontSize, bool isInside = false)
        {
            // Janky but it'll do
            if (isInside)
                return (int)rect.y + (((int)rect.height / 2) - (int)(fontSize * 0.5));
            else
                return (int)rect.y + (((int)rect.height / 2));
        }
    }
}