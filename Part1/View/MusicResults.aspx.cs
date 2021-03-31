using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Web.UI.WebControls;
using System.Data;
using Part1.Model;

namespace Part1.View
{
    public partial class MusicResults : System.Web.UI.Page
    {
        private static ICollection CreateDataSource()
        {
            DataTable table = new DataTable();
            DataRow row;

            table.Columns.Add(new DataColumn("TrackName", typeof(string)));
            table.Columns.Add(new DataColumn("ArtistName", typeof(string)));
            table.Columns.Add(new DataColumn("CollectionName", typeof(string)));
            table.Columns.Add(new DataColumn("TrackPrice", typeof(double)));
            table.Columns.Add(new DataColumn("CollectionPrice", typeof(double)));
            table.Columns.Add(new DataColumn("ArtworkURL", typeof(string)));

            for (int i = 0; i < ITunesSearch.JsonTrack.ResultCount; i++)
            {
                row = table.NewRow();

                row[0] = ITunesSearch.JsonTrack.Results[i].TrackName;
                row[1] = ITunesSearch.JsonTrack.Results[i].ArtistName;
                row[2] = ITunesSearch.JsonTrack.Results[i].CollectionName;
                row[3] = ITunesSearch.JsonTrack.Results[i].TrackPrice;
                row[4] = ITunesSearch.JsonTrack.Results[i].CollectionPrice;
                row[5] = ITunesSearch.JsonTrack.Results[i].ArtworkUrl60;

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
            if (ITunesSearch.JsonTrack == null) Response.Redirect("iTunesSearch.aspx");

            BindList();
        }
    }
}