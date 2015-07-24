using System;

namespace RayUtil
{
    public class ConvertHelper
    {
        public static int ConvertToInt32(object obj)
        {
            try
            {
                return Convert.ToInt32(obj);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static long ConvertToInt64(object obj)
        {
            try
            {
                return Convert.ToInt64(obj);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
