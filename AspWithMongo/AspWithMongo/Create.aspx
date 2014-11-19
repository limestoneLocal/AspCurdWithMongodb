<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="AspWithMongo.Create" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASP.NET with Mongo</title>
    <script type="text/javascript">
        function deleteConfirm(pubid) {
            var result = confirm('Do you want to delete ' + pubid + ' ?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <asp:GridView ID="GridView1" DataKeyNames="id" runat="server"
            AutoGenerateColumns="false" ShowFooter="true" HeaderStyle-Font-Bold="true"
            OnRowCancelingEdit="gridView_RowCancelingEdit"
            OnRowDeleting="gridView_RowDeleting"
            OnRowEditing="gridView_RowEditing"
            OnRowUpdating="gridView_RowUpdating"
            OnRowCommand="gridView_RowCommand"
            OnRowDataBound="gridView_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lblstorid1" runat="server" Text='<%#Eval("id") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblstorid" runat="server" Width="40px" Text='<%#Eval("id") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblname" runat="server" Text='<%#Eval("name") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNameEdit" Width="70px" runat="server" Text='<%#Eval("name") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtNameAdd" Width="120px" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="stor_address">
                    <ItemTemplate>
                        <asp:Label ID="lblLanguages" runat="server" Text='<%#Eval("languages") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtLanguagesEdit" Width="70px" runat="server" Text='<%#Eval("languages") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtLanguagesAdd" Width="110px" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country">
                    <ItemTemplate>
                        <asp:Label ID="lblCountry" runat="server" Text='<%#Eval("country") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCountryEdit" Width="50px" runat="server" Text='<%#Eval("country") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtCountryAdd" Width="60px" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="ButtonAdd" runat="server" CommandName="AddNew" Text="Add New Row" ValidationGroup="validaiton" />
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>


        <div>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblmsg" runat="server"></asp:Label>
        </div>



















    </form>
</body>
</html>
