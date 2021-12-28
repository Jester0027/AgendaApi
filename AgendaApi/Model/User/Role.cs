using System.ComponentModel;

namespace AgendaApi.Model.User
{

    public enum Role
    {
        [Description("Doctor")]
        Doctor = 0,
        [Description("Secretary")]
        Secretary = 1
        
    }

    public static class RoleUtils
    {
        public static string ToStringValue(this Role value)
        {
            var attributes =  (DescriptionAttribute[]) value.GetType().GetField(value.ToString())
                ?.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes is {Length: > 0} ? attributes[0].Description : "";
        }
    }
}