namespace FA.JustBlog.Helpers
{
    public static class DateTimeHelper
    {
        public static string FriendlyDateTimeFormat(this DateTime time)
        {
            var span = DateTime.Now.Subtract(time);
            if(span.TotalDays == 1)
            {
                return $"Yesterday at {time:h:mm tt}";
            }
            if (span.TotalSeconds < 0)
            {
                return "Just now";
            }
            if (span.TotalSeconds < 60)
            {
                return $"{Math.Floor(span.TotalSeconds)} seconds ago";
            }
            if (span.TotalMinutes < 60)
            {
                return $"{Math.Floor(span.TotalMinutes)} minutes ago";
            }
            if (span.TotalHours < 24)
            {
                return $"{Math.Floor(span.TotalHours)} hours ago";
            }
            if (span.TotalDays < 7)
            {
                return $"{Math.Floor(span.TotalDays)} days ago at {time:h:mm tt}";
            }
            if (span.TotalDays < 30)
            {
                return $"{Math.Floor(span.TotalDays / 7)} weeks ago at {time:h:mm tt}";
            }
            if (span.TotalDays < 365)
            {
                return $"{Math.Floor(span.TotalDays / 12)} months ago at {time:h:mm tt}";
            }
            else
            {
                return $"{Math.Floor(span.TotalDays / 365)} years ago at {time:h:mm tt}";
            }
        }
    }
}
