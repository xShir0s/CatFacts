using System.Net;
using System.Text.Json;

namespace CatFacts
{
    public class Facts
    {
        public string? fact { get; set; }
        public int? length { get; set; }
    }
    public partial class MainPage : ContentPage
    {




        public MainPage()
        {
            InitializeComponent();

        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            string json;
            string url = "https://catfact.ninja/fact?max_length=" + Int32.Parse(Limit.Text);

            using (var webClient = new WebClient())
            {
                json = webClient.DownloadString(url);
            }

            Facts catfacts = JsonSerializer.Deserialize<Facts>(json);

            Fact.Text = "Ciekawostka: " + catfacts.fact + "\n Ilosc znaków:  " + catfacts.length.ToString();

        }

    }

}
