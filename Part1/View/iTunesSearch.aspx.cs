using System;
using System.Dynamic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Part1.Model;

namespace Part1.View
{
    // ReSharper disable once InconsistentNaming
    public partial class ITunesSearch : System.Web.UI.Page
    {
        public static MovieResults JsonMovie { get; set; }
        public static TrackResults JsonTrack { get; set; }
        public static SoftwareResults JsonSoftware { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            searchDdl.Items.Add("Music");
            searchDdl.Items.Add("Movie");
            searchDdl.Items.Add("Software");
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            string url;
            string[] termList;
            string term;
            string type;

            termList = searchTbx.Text.Split(' ');
            term = string.Join("+", termList);

            type = searchDdl.SelectedItem.Text.ToLower();

            url = "https://itunes.apple.com/search?term=" + term + "&media=" + type + "&limit=10";

            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";

            WebResponse webResponse = request.GetResponse();
            Stream webStream = webResponse.GetResponseStream();

            StreamReader reader = new StreamReader(webStream);
            var jsonString = reader.ReadToEnd();

            switch (type)
            {
                case "music":
                    JsonTrack = JsonConvert.DeserializeObject<TrackResults>(jsonString);
                    Response.Redirect("MusicResults.aspx");
                    break;
                case "movie":
                    JsonMovie = JsonConvert.DeserializeObject<MovieResults>(jsonString);
                    break;
                case "software":
                    JsonSoftware = JsonConvert.DeserializeObject<SoftwareResults>(jsonString);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}