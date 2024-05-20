using System.Text.RegularExpressions;

namespace RoutingDemo
{
    public class MonthsCustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, 
            RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.ContainsKey(routeKey))
            {
                return false;
            }
            else {
                Regex regex = new Regex("^(jan|feb|mar)$");
                string? monthValue = Convert.ToString(values[routeKey]);

                if (regex.IsMatch(monthValue))
                {
                    return true;
                }
                else { 
                    return false; 
                }
            
            }
        }
    }
}
