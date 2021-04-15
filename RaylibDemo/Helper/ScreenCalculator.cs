using PointDefence.Core.Data;

namespace PointDefence.Helper
{
    /// <summary>
    /// Intended to get an integer value for a percentage of the screen Height or Width.
    /// </summary>
    public class ScreenCalculator
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="value">Percentage in float format</param>
        /// <returns>Returns integer value of the height * value</returns>
        public static int PercentageH(float value)
        {
            return Percentage(GameData.ScreenHeight, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value">Percentage in float format</param>
        /// <returns>Returns integer value of the width * value</returns>
        public static int PercentageW(float value)
        {
            return Percentage(GameData.ScreenWidth, value);
        }

        private static int Percentage(int hw, float value)
        {
            return (int)(hw * value);
        }
    }
}