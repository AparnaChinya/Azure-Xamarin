using Plugin.TextToSpeech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Demos
{
    public partial class DetailsPage : ContentPage
    {
        Session session;
        public DetailsPage(Session item)
        {
            InitializeComponent();
            this.session = item;

            BindingContext = session;
            CrossTextToSpeech.Current.Speak(this.session.Desc);
        }
    }
}
