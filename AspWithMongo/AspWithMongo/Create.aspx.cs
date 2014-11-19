using AspWithMongo.Utility;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspWithMongo
{
    public partial class Create : System.Web.UI.Page
    {
        private MongoDatabase mongo_db;


        string name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            mongo_db = MDDatabase.retreive_mongohq_db();
            if (!IsPostBack)
            {
                loadDataTable();
            }

        }

        private void loadDataTable()
        {
            var persons_collection = mongo_db.GetCollection("persons").FindAll().AsEnumerable();
            var personList = new List<PersonModel>();
            if (persons_collection.Count() > 0)
            {
                  personList.AddRange((from person in persons_collection
                                  select new PersonModel
                                  {
                                      id = person["_id"].AsObjectId,
                                      name = person["name"].AsString,
                                      languages = person["languages"].AsString,
                                      country = person["country"].AsString
                                  }).ToList());
            }

            GridView1.DataSource = personList;
            GridView1.DataBind();
        }

        protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            loadDataTable();
        }
        protected void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string stor_id = GridView1.DataKeys[e.RowIndex].Values["id"].ToString();
            TextBox stor_name = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtNameEdit");
            TextBox stor_address = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtLanguagesEdit");
            TextBox city = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtCountryEdit");


            MongoCollection<PersonModel> collection = mongo_db.GetCollection<PersonModel>("persons");
            IMongoQuery query = Query.EQ("_id", stor_id);
            IMongoUpdate update = MongoDB.Driver.Builders.Update.Set("name", stor_name.Text)
                                                                .Set("languages", stor_address.Text)
                                                                .Set("country", city.Text) ;
            collection.Update(query, update); 

           
            /*con.Open();
            SqlCommand cmd = new SqlCommand("update stores set stor_name='" + stor_name.Text + "', stor_address='" + stor_address.Text + "', city='" + city.Text + "', state='" + state.Text + "', zip='" + zip.Text + "' where stor_id=" + stor_id, con);
            cmd.ExecuteNonQuery();
            con.Close();
            lblmsg.BackColor = Color.Blue;
            lblmsg.ForeColor = Color.White;*/
            lblmsg.Text = stor_id + "        Updated successfully........    ";
            GridView1.EditIndex = -1;
            loadDataTable();
        }
        protected void gridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            loadDataTable();
        }
        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string stor_id = GridView1.DataKeys[e.RowIndex].Values["id"].ToString();

            MongoCollection<PersonModel> collection = mongo_db.GetCollection<PersonModel>("persons");
            IMongoQuery query = Query.EQ("_id", stor_id);
            collection.Remove(query);   
            /*con.Open();
            SqlCommand cmd = new SqlCommand("delete from stores where stor_id=" + stor_id, con);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result == 1)
            {
                loadStores();
                lblmsg.BackColor = Color.Red;
                lblmsg.ForeColor = Color.White;
                lblmsg.Text = stor_id + "      Deleted successfully.......    ";
            }*/
        }
        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string stor_id = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "id"));
                Button lnkbtnresult = (Button)e.Row.FindControl("ButtonDelete");
                if (lnkbtnresult != null)
                {
                    lnkbtnresult.Attributes.Add("onclick", "javascript:return deleteConfirm('" + stor_id + "')");
                }
            }
        }
        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            { 
                TextBox inname = (TextBox)GridView1.FooterRow.FindControl("txtNameAdd");
                TextBox inaddress = (TextBox)GridView1.FooterRow.FindControl("txtLanguagesAdd");
                TextBox incity = (TextBox)GridView1.FooterRow.FindControl("txtCountryAdd");


                try
                {
                    var persons_collection = mongo_db.GetCollection("persons");

                    BsonDocument person = new BsonDocument
         {  
               {"name",inname.Text},  
               {"languages",inname.Text},  
               {"country",inaddress.Text} 
         }; 
                    persons_collection.Insert(person);

                    lblmsg.Text = "      Added successfully......    ";
                }

                catch {
                    lblmsg.Text = "      Error while adding row......    ";
                };
                /*con.Open();
                SqlCommand cmd =
                    new SqlCommand(
                        "insert into stores(stor_id,stor_name,stor_address,city,state,zip) values('" + instorid.Text + "','" +
                        inname.Text + "','" + inaddress.Text + "','" + incity.Text + "','" + instate.Text + "','" + inzip.Text + "')", con);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result == 1)
                {
                    loadStores();
                    lblmsg.BackColor = Color.Green;
                    lblmsg.ForeColor = Color.White;
                    lblmsg.Text = instorid.Text + "      Added successfully......    ";
                }
                else
                {
                    lblmsg.BackColor = Color.Red;
                    lblmsg.ForeColor = Color.White;
                    lblmsg.Text = instorid.Text + " Error while adding row.....";
                }*/
            }
        }

        /*protected void showButton_Click(object sender, EventArgs e)
        {
            List<Info> names = new List<Info>();
            MongoServer server = MongoServer.Create(ConfigurationManager.AppSettings["connectionString"]);
            MongoDatabase myDB = server.GetDatabase("test");
            MongoCollection<Info> Persons = myDB.GetCollection<Info>("persons");
            foreach(Info Aperson in Persons.FindAll())
            {
                name = name+" "+Aperson.Name;
                names.Add(Aperson);
            }
            nameLabel.Text = name;
        }*/
    }
}