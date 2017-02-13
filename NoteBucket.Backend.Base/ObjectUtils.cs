using System;

namespace NoteBucket.Backend.Base
{
    public class ObjectUtils
    {
        public static void SetPrivateProperty(object instance, string propertyName, object value)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }

            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("propertyName");
            }

            var property = instance.GetType().GetProperty(propertyName);
            if (property == null)
            {
                throw new Exception("Property not found");
            }
            property.SetValue(instance, value);
        }
    }
}
