Xamarin-Azure
===========


<br />

## XAMARIN FORMS
1.	Start Visual Studio > File > New Project > Visual C# > Cross-Platform >Xamarin.Forms XAML App(Portable) > Give a name to the Project (Demo) >Ok.

 
## Nugets: 
-	Right click on the solution > select Manage nugget packages. Under Nuget solution manager, go to Browse. Search and install each of the following nugget packages.
newtonsoft.json
Xamarin.forms
Microsoft.Bcl
Microsoft.Bcl.Build
Microsoft.Net.Http

##Add a new Class named Session

````csharp
public class Session

    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Images { get; set; }      
    }

```

## PageOne.xaml
<br/>

###1. Creating Absolute Layouts : Under  <ContentPage.Content> tag, add the following

````XML
<AbsoluteLayout HorizontalOptions="FillAndExpand" VerticalOptions="FillAndExpand">
</AbsoluteLayout>
```

<br/>

 
###2. Under the AbsoluteLayout node, add a StackLayout:

````XML
      <StackLayout AbsoluteLayout.LayoutFlags="All" AbsoluteLayout.LayoutBounds="0,0,1,1">
      </StackLayout>
```

<br/>

###3. Add a ListView under the StackLayout tag:
````XML
        <ListView ItemsSource="{Binding Sessions}"
	
	                  VerticalOptions="FillAndExpand"
	
	                  HasUnevenRows="False"                 
	
	                  CachingStrategy="RecycleElement"
	
	                  x:Name="myList">
	
	          <ListView.ItemTemplate>
	
	            <DataTemplate>
	             
	              <ImageCell ImageSource="{Binding Images}" Text="{Binding Desc}" />
	
	            </DataTemplate>
	
	          </ListView.ItemTemplate>
	
    </ListView>
```
    
    


 
### PageOne.xaml.cs

In PageOne.xaml.cs, add the following libraries:

````csharp
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.Web.Http;
using Xamarin.Forms;
```


###In class PageOne, declare these Class variables:

````csharp
public ObservableCollection<Session> Sessions { get; set; }
public ICommand GetSessionsCommand { get; set; }
```

###In the constructor, initialize the class variable:

```csharp
Sessions = new ObservableCollection<Session>();
```

###Set the title of the page as “Sessions”
```csharp
Title = "Sessions";
```

###Add event handler for ItemSelected event on the ListView. Type the below mentioned code and hit tab. It will create the definition of the event handler.

````csharp
myList.ItemSelected += MyList_ItemSelected;
```

###In the event handler, paste this code:

````csharp
var details = e.SelectedItem as Session;
            if (details == null)
                return;

            await Navigation.PushAsync(new DetailsPage(details));

            myList.SelectedItem = null;

 ```

##DetailsPage.Xaml
####Add a new Page to the app and name it as DetailsPage.xaml

#### Add the following under DetailsPage.Xaml.cs
````XML
<ScrollView Padding="10">

    <StackLayout Spacing="100">

      
      <Label Text="{Binding Name}" TextColor="Green" Font="30"/>
      <Label Text="{Binding Desc}" TextColor="Purple" Font="20"/>

    
    </StackLayout>    

  </ScrollView>
```

##DetailsPage.xaml.cs
####Replace the constructor with the below code

````csharp
         Session session;
        public DetailsPage(Session item)
        {
            InitializeComponent();
            this.session = item;

            BindingContext = session;
            CrossTextToSpeech.Current.Speak(this.session.Desc);
        }
```

####Add the TextToSpeech nuget at the SOLUTION level for all the projects.
Link: [TextToSpeech nuget](https://www.nuget.org/packages/Xam.Plugins.TextToSpeech/)

##Run your Application to see a list of Pokemons :)
