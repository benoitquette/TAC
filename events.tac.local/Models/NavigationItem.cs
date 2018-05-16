using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events.tac.local.Models
{
    public class NavigationItem
    {
        public NavigationItem(string title, string uRL, bool active = false)
        {
            Title = title;
            URL = uRL;
            Active = active;
        }

        public string Title { get; set; }
        public string URL { get; set; }
        public bool Active { get; set; }
    }
}