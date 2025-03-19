<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="SMS.Web.EditUser" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit User</title>
    <style>
        .form-group {
            margin-bottom: 15px;
        }
        .form-label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }
        .form-control {
            width: 100%;
            padding: 10px;
            box-sizing: border-box;
        }
        .form-container {
            max-width: 600px;
            margin: auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            background-color: #f9f9f9;
        }
        .form-actions {
            text-align: right;
        }
        .btn {
            padding: 10px 20px;
            margin: 5px;
            border: none;
            cursor: pointer;
        }
        .btn-save {
            background-color: #28a745;
            color: white;
        }
        .btn-cancel {
            background-color: #dc3545;
            color: white;
        }
        .message {
            color: red;
            margin-top: 20px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <asp:HiddenField ID="hfUserId" runat="server" />
            <div class="form-group">
                <label class="form-label" for="txtFirstName">First Name</label>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label class="form-label" for="txtLastName">Last Name</label>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label class="form-label" for="txtEmail">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label class="form-label" for="txtPassword">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
            </div>
            <div class="form-group">
                <label class="form-label" for="txtUserName">Username</label>
                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label class="form-label" for="txtGender">Gender</label>
                <asp:TextBox ID="txtGender" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label class="form-label" for="txtCreatedOn">Created On</label>
                <asp:TextBox ID="txtCreatedOn" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label class="form-label" for="txtUpdatedOn">Updated On</label>
                <asp:TextBox ID="txtUpdatedOn" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:CheckBox ID="chkIsDeleted" runat="server" Text="Is Deleted" CssClass="form-control" />
            </div>
            <div class="form-actions">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-save" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-cancel" PostBackUrl="~/Users.aspx" />
            </div>
            <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
        </div>
    </form>
</body>
</html>
