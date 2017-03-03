using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Web.Http;
using Xamarin.Forms;

namespace Demos
{
    public class Session

    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Images { get; set; }
        
    }
    public partial class PageOne : ContentPage
    {
        
        public PageOne()
        {
            InitializeComponent();

            Sessions = new ObservableCollection<Session>();

            Title = "Sessions";

            GetSessions();

            myList.ItemSelected += MyList_ItemSelected;

        }

        private async void MyList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var details = e.SelectedItem as Session;
            if (details == null)
                return;

            await Navigation.PushAsync(new DetailsPage(details));

            myList.SelectedItem = null;
        }

        public ObservableCollection<Session> Sessions { get; set; }
        public ICommand GetSessionsCommand { get; set; }

        
        async Task GetSessions()

        {

            
                using (var client = new System.Net.Http.HttpClient())

                {

                    var json = await client.GetStringAsync("https://apchin-mobileapp.azurewebsites.net/api/Poki");
                    
                    //Deserialize json

                    var items = JsonConvert.DeserializeObject<List<Session>>(json);

                    myList.ItemsSource = items;

                    //Load sessions into list


                }

                             

        }

    }
}

