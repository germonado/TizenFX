using System;
using Tizen.NUI;

namespace NUITizenGallery
{
    internal class ButtonTest5 : IExample
    {
        private Window window;
        private ButtonTest5Page page;
        public void Activate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Activate()");

            window = NUIApplication.GetDefaultWindow();
            page = new ButtonTest5Page();
            page.PositionUsesPivotPoint = true;
            page.ParentOrigin = ParentOrigin.Center;
            page.PivotPoint = PivotPoint.Center;
            page.HeightResizePolicy = ResizePolicyType.FillToParent;
            page.WidthResizePolicy = ResizePolicyType.FillToParent;
            window.Add(page);

        }
        public void Deactivate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Deactivate()");
            page.Unparent();
            page.Dispose();
        }
    }
}
