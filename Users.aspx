<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="SMS.Web.Users" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Users List</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .gridview th {
            background-color: #333;
            color: white;
        }
        .gridview td {
            padding: 10px;
        }
        .edit-link, .delete-link {
            margin-right: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewUsers_RowCommand"
                DataKeyNames="Id" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="UserName" HeaderText="User Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:BoundField DataField="CreatedOn" HeaderText="CreatedOn" />
                    <asp:BoundField DataField="UpdatedOn" HeaderText="UpdatedOn" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEdit" runat="server" href='<%# "EditUser.aspx?id=" + Eval("Id") %>' CommandName="EditUser" CommandArgument='<%# Container.DataItemIndex %>' Text="Edit" CssClass="btn btn-success edit-link" />
                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteUser" CommandArgument='<%# Container.DataItemIndex %>' Text="Delete" CssClass="btn btn-danger delete-link" OnClientClick="return confirm('Are you sure you want to delete this user?');" />
                            <asp:LinkButton ID="btnDetails" runat="server" CommandName="DetailsUser" CommandArgument='<%# Container.DataItemIndex %>' Text="Details" CssClass="btn btn-info details-link" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
