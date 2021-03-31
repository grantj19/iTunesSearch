using System;
using Part1.Model;

namespace Part1.View
{
    public partial class MusicResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<br />");
            Response.Write("<table>");

            for (int i = 0; i < ITunesSearch.JsonTrack.ResultCount; i++)
            {
                Response.Write("<tr>");

                Response.Write("<td>");

                Response.Write(ITunesSearch.JsonTrack.Results[i].TrackName);
                Response.Write(ITunesSearch.JsonTrack.Results[i].CollectionName);
                Response.Write(ITunesSearch.JsonTrack.Results[i].ArtworkUrl);

                Response.Write("</td>");

                Response.Write("</tr>");
            }

            Response.Write("</table>");
        }

    }
}