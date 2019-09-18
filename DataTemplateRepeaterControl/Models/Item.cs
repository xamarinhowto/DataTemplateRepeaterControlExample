using System;
using System.IO;
using System.Net;
using Xamarin.Forms;

namespace DataTemplateRepeaterControl.Models
{
    public enum ItemType
    {
        TypeA,
        TypeB,
        TypeC
    }

    public abstract class Item
    {
        public string Id { get; set; }

        protected abstract ItemType Type { get; }

        public string Text { get; set; }

        public string Description { get; set; }

        // This is obviously much simpler than below
        //public ImageSource Image => ImageSource.FromUri(new Uri($"https://picsum.photos/200?{Guid.NewGuid().ToString()}"));

        public ImageSource Image
        {
            get
            {
                // HACK: At the time of writing this, XF 4.2 ImageSource.FromUri() is throwing exceptions on Android and there doesn't appear
                // to be a fix in any of the previews. Just reading this in this way to finish off this project. This obviously is NOT the
                // best way to get an image from a Uri but hey, that's not what this project is about.
                var uri = new Uri($"https://picsum.photos/200?{Guid.NewGuid().ToString()}");
                byte[] imageData = null;

                using (var webClient = new WebClient())
                {
                    imageData = webClient.DownloadData(uri);
                }

                return ImageSource.FromStream(() => new MemoryStream(imageData));
            }
        }
    }

    public class ItemA : Item
    {
        protected override ItemType Type => ItemType.TypeA;
    }

    public class ItemB : Item
    {
        protected override ItemType Type => ItemType.TypeB;
    }

    public class ItemC : Item
    {
        protected override ItemType Type => ItemType.TypeC;
    }
}