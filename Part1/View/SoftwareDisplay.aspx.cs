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
    public partial class SoftwareDisplay : System.Web.UI.Page
    {

        private static ICollection CreateDataSource()
        {

            string MakeGenresList(int i)
            {
                string genres = string.Join(", ", ITunesSearch.JsonSoftware.Results[i].Genres);
                return genres;
            }

            string MakeSupportedDevicesList(int i)
            {
                string devices = string.Join(", ", ITunesSearch.JsonSoftware.Results[i].SupportedDevices);
                return devices;
            }

            DataTable table = new DataTable();
            DataRow row;

            table.Columns.Add(new DataColumn("ArtistName", typeof(string)));
            table.Columns.Add(new DataColumn("Price", typeof(double)));
            table.Columns.Add(new DataColumn("SupportedDevices", typeof(string)));
            table.Columns.Add(new DataColumn("Description", typeof(string)));
            table.Columns.Add(new DataColumn("Genres", typeof(string)));
            table.Columns.Add(new DataColumn("ArtworkURL1", typeof(string)));
            table.Columns.Add(new DataColumn("ArtworkURL2", typeof(string)));


            for (int i = 0; i < ITunesSearch.JsonSoftware.ResultCount; i++)
            {
                row = table.NewRow();

                row[0] = ITunesSearch.JsonSoftware.Results[i].ArtistName;
                row[1] = ITunesSearch.JsonSoftware.Results[i].Price;
                row[2] = MakeSupportedDevicesList(i);
                row[3] = ITunesSearch.JsonSoftware.Results[i].Description;
                row[4] = MakeGenresList(i);
                row[5] = ITunesSearch.JsonSoftware.Results[i].ScreenshotUrls[0];
                row[6] = ITunesSearch.JsonSoftware.Results[i].ScreenshotUrls[1];
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
            if (ITunesSearch.JsonSoftware == null) Response.Redirect("iTunesSearch.aspx");

            BindList();
        }
    }
}
