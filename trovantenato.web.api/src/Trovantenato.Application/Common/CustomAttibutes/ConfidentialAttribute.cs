using System.Reflection;
using Trovantenato.Application.Services.Immigrant.Queries.GetImmigrants;

namespace Trovantenato.Application.Common.CustomAttibutes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    sealed class ConfidentialAttribute : Attribute
    {
        public bool IsConfidential { get; set; }
        public string DefaultString { get; set; } = "Lugar conhecido";

        public ConfidentialAttribute(bool isConfidential = true)
        {
            IsConfidential = isConfidential;
        }

        public static string? GetPropertyConfidential(string propertyName)
        {
            PropertyInfo propertyInfo = typeof(ImmigrantDto).GetProperty(propertyName);
            ConfidentialAttribute confidentialAttribute = (ConfidentialAttribute)GetCustomAttribute(propertyInfo, typeof(ConfidentialAttribute));

            if (confidentialAttribute != null)
            {
                if (confidentialAttribute.IsConfidential) return confidentialAttribute.DefaultString;
            }

            return null;
        }
    }
}
