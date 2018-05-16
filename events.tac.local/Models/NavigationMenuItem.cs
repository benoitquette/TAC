using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events.tac.local.Models
{
    public class NavigationMenuItem: NavigationItem
    {
        public NavigationMenuItem(string title, string uRL, IEnumerable<NavigationMenuItem> children) : base(title, uRL, false)
        {
            Children = children != null ? children : new List<NavigationMenuItem>();
        }

        public IEnumerable<NavigationMenuItem> Children { get; set; }
    }
}