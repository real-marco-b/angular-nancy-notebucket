using System;

namespace NoteBucket.Backend.Base.Security
{
    /// <summary>
    /// Helper class to handle Unix Timestamps
    /// </summary>
    public static class UnixTime
    {
        /// <summary>
        /// Creates a unix timestamp from the given point in time.
        /// </summary>
        /// <param name="dateTime">The point in time the timestamp is calculated from.</param>
        /// <returns>The number of passed seconds since January 1st 1970.</returns>
        public static long FromDateTime(DateTime dateTime)
        {
            return (int)(dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}
