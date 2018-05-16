using events.tac.local.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TAC.Sitecore.Abstractions.Interfaces;
using TAC.Sitecore.Abstractions.SitecoreImplementation;

namespace events.tac.local.Business
{
    public class BreadcrumbBuilder
    {
        private readonly IRenderingContext renderingContext;
        public BreadcrumbBuilder() : this(SitecoreRenderingContext.Create()) { }
        public BreadcrumbBuilder(IRenderingContext renderingContext)
        {
            this.renderingContext = renderingContext;
        }

        public IEnumerable<NavigationItem> Build()
        {
            IEnumerable<NavigationItem> res = Enumerable.Empty<NavigationItem>();
            if (this.renderingContext?.HomeItem != null && this.renderingContext?.ContextItem != null)
            {
                return this.renderingContext
                    .ContextItem
                    .GetAncestors()
                    .Where(i => this.renderingContext.HomeItem.IsAncestorOrSelf(i))
                    .Select(i => new NavigationItem(
                        i.DisplayName,
                        i.Url,
                        false))
                    .Concat(new[]
                    {
                        new NavigationItem(
                            this.renderingContext.ContextItem.DisplayName,
                            this.renderingContext.ContextItem.Url,
                            true)
                    });
            }
            return res;
        }
    }
}