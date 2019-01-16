using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Framework.Web;
using EPiServer.Web;

namespace Essence.Business.DisplayChannels
{
    public class MobileDisplayChannel : DisplayChannel
    {
        public override string ChannelName => RenderingTags.Mobile;
        public override string ResolutionId => "iphone5";

        public override bool IsActive(HttpContextBase context)
        {
            return context.Request.Browser.IsMobileDevice;
        }
    }

    public class IPhone5 : IDisplayResolution
    {
        public string Id => "iphone5";
        public string Name => "iPhone 5 (320 x 568)";
        public int Width => 320;
        public int Height => 568;
    }

    public class IPhone4 : IDisplayResolution
    {
        public string Id => "iphone4";
        public string Name => "iPhone 4 (320 x 480)";
        public int Width => 320;
        public int Height => 480;
    }
}
