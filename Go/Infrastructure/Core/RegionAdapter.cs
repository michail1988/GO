using System;
using System.Collections.Generic;
using System.Collections.Specialized;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Modularity;

using Microsoft.Practices.Unity;
//using System.ComponentModel.Composition.Hosting;

using Microsoft.Practices.Prism.Regions;


namespace Go.Infrastructure.Core
{
    class RegionAdapter : RegionAdapterBase<ContentControl>
    {
        private IServiceLocator serviceLocator;

        public RegionAdapter(IServiceLocator serviceLocator)
            : base(new RegionBehaviorFactory(serviceLocator))
        {
            this.serviceLocator = serviceLocator;

        }
        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }

        protected override void Adapt(IRegion region, ContentControl regionTarget)
        {
            bool contentIsSet = regionTarget.Content != null;

            contentIsSet = contentIsSet || (BindingOperations.GetBinding(regionTarget, ContentControl.ContentProperty) != null);

            if (contentIsSet)
            {
                throw new InvalidOperationException("Your custom exception message");
            }

            region.ActiveViews.CollectionChanged += delegate
            {
                regionTarget.Content = region.ActiveViews.FirstOrDefault();
            };

            region.Views.CollectionChanged +=
                (sender, e) =>
                {
                    if (e.Action == NotifyCollectionChangedAction.Add && region.ActiveViews.Count() == 0)
                    {
                        region.Activate(e.NewItems[0]);
                    }
                };
        }
    }
}
