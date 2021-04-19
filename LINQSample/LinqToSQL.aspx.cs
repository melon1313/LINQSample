using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LINQSample
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SampleDataContext dataContext = new SampleDataContext();
            GridView1.DataSource = from gamer in dataContext.Gamer
                                   where gamer.Gender == "Female"
                                   select gamer;
            
            //GridView1.DataSource = dataContext.Gamers.Where(gamer => gamer.Gender == "Female");
            GridView1.DataBind();
        }
    }

    public class GamerA
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
    }
}