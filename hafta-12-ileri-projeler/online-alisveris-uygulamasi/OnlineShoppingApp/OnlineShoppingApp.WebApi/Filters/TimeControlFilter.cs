using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineShoppingApp.WebApi.Filters
{
    public class TimeControlFilter : ActionFilterAttribute
    {
        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            StartTime = "04:00"; 
            EndTime = "06:00";   

            var now = DateTime.Now.TimeOfDay;
            var start = TimeSpan.Parse(StartTime);
            var end = TimeSpan.Parse(EndTime);

            bool isBanned;

            if (start < end)
            {
                // Yasak aralık gün içinde bitiyor
                isBanned = now >= start && now <= end;
            }
            else
            {
                // Yasak aralık gün değişirse (ör: 23:00–06:00)
                isBanned = now >= start || now <= end;
            }

            if (isBanned)
            {
                context.Result = new ContentResult
                {
                    Content = $"{StartTime} ile {EndTime} saatleri arasında istek atılamaz",
                    StatusCode = 403
                };
            }
            else
            {
                base.OnActionExecuting(context); // izin ver
            }
        }
    }//  time control filter done
}
