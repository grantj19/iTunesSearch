using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Part1.View
{
    public partial class MovieDisplay : System.Web.UI.Page
    {
        private static ICollection CreateDataSource()
        {
            DataTable table = new DataTable();
            DataRow row;

            table.Columns.Add(new DataColumn("TrackName", typeof(string)));
            table.Columns.Add(new DataColumn("ContentRating", typeof(string)));
            table.Columns.Add(new DataColumn("ArtworkURL", typeof(string)));
            table.Columns.Add(new DataColumn("LongDescription", typeof(string)));
            table.Columns.Add(new DataColumn("PrimaryGenreName", typeof(string)));
            table.Columns.Add(new DataColumn("TrackHdPrice", typeof(string)));


            for (int i = 0; i < ITunesSearch.JsonMovie.ResultCount; i++)
            {
                row = table.NewRow();

                row[0] = ITunesSearch.JsonMovie.Results[i].TrackName;
                row[1] = ITunesSearch.JsonMovie.Results[i].ContentAdvisoryRating;
                row[2] = ITunesSearch.JsonMovie.Results[i].ArtworkUrl60;
                row[3] = ITunesSearch.JsonMovie.Results[i].LongDescription;
                row[4] = ITunesSearch.JsonMovie.Results[i].PrimaryGenreName;
                row[5] = ITunesSearch.JsonMovie.Results[i].TrackHdPrice;

                table.Rows.Add(row);
            }

            DataView view = new DataView(table);
            return view;
        }
        public void DataList_ItemCommand(Object sender, DataListCommandEventArgs e)
        {
            musicDl.SelectedIndex = e.Item.ItemIndex;
            BindList();
        }

        protected void BindList()
        {
            musicDl.DataSource = CreateDataSource();
            musicDl.DataBind();
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("iTunesSearch.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (ITunesSearch.JsonMovie == null) Response.Redirect("iTunesSearch.aspx");

            BindList();
        }
    }
}
