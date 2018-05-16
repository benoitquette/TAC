using events.tac.local.Models;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TAC.Sitecore.Abstractions.Interfaces;
using TAC.Sitecore.Abstractions.SitecoreImplementation;

namespace events.tac.local.Business
{
    public class NavigationBuilder
    {
        private readonly IRenderingContext renderingContext;
        public NavigationBuilder() : this(SitecoreRenderingContext.Create()) { }
        public NavigationBuilder(IRenderingContext renderingContext)
        {
            this.renderingContext = renderingContext;
        }

        public NavigationMenuItem Build()
        {
            var root = this.renderingContext?.DatasourceOrContextItem;
            var context = this.renderingContext?.ContextItem;
            return new NavigationMenuItem
                (
                    title: root?.DisplayName,
                    uRL: root?.Url,
                    children: root != null && context != null ? GetChildren(root, context) : null
                );
        }

        private IEnumerable<NavigationMenuItem> GetChildren(IItem item, IItem currentItem)
        {
            return item
                .GetChildren()
                .Select(i => new NavigationMenuItem
                (
                    title: i.DisplayName,
                    uRL: i.Url,
                    children: i.IsAncestorOrSelf(currentItem) ? GetChildren(i, currentItem) : null
                    ));

            //if (item != null)
            //{
            //    IEnumerable<IItem> children = item.GetChildren();
            //    List<NavigationMenuItem> childItems = new List<NavigationMenuItem>();
            //    if (children != null)
            //    {

            //        foreach (IItem child in children)
            //        {
            //            if (child.IsAncestorOrSelf(currentItem))
            //            {
            //                childItems.Add(this.GetChildren(child, currentItem));
            //            }
            //        }
            //    }
            //    return new NavigationMenuItem(item?.DisplayName, item?.Url, childItems);
            //}
            //else
            //{
            //    return new NavigationMenuItem(item?.DisplayName, item?.Url, null);
            //}
        }
    }
}