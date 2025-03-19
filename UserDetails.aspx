<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="SMS.Web.UserDetails" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Details</title>
    <style>
        .details-table {
            width: 50%;
            margin: auto;
            border-collapse: collapse;
        }
        .details-table th, .details-table td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }
        .details-table th {
            background-color: #f4f4f4;
        }
        .back-button {
            display: block;
            width: 150px;
            margin: 20px auto;
            padding: 10px 20px;
            text-align: center;
            background-color: #007bff;
            color: white;
            text-decoration: none;
            border-radius: 5px;
        }
        .back-button:hover {
            background-color: #0056b3;
        }
        h2{
            margin-left:660px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>User Details</h2>
            <asp:Table ID="detailsTable" runat="server" CssClass="details-table">
                <asp:TableRow>
                    <asp:TableCell><b>User ID:</b></asp:TableCell>
                    <asp:TableCell><asp:Label ID="lblUserId" runat="server" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><b>First Name:</b></asp:TableCell>
                    <asp:TableCell><asp:Label ID="lblFirstName" runat="server" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><b>Last Name:</b></asp:TableCell>
                    <asp:TableCell><asp:Label ID="lblLastName" runat="server" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><b>Email:</b></asp:TableCell>
                    <asp:TableCell><asp:Label ID="lblEmail" runat="server" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><b>User Name:</b></asp:TableCell>
                    <asp:TableCell><asp:Label ID="lblUserName" runat="server" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><b>Gender:</b></asp:TableCell>
                    <asp:TableCell><asp:Label ID="lblGender" runat="server" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><b>Created On:</b></asp:TableCell>
                    <asp:TableCell><asp:Label ID="lblCreatedOn" runat="server" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><b>Updated On:</b></asp:TableCell>
                    <asp:TableCell><asp:Label ID="lblUpdatedOn" runat="server" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <a href="Users.aspx" class="back-button">Back to List</a>
        </div>
    </form>
</body>
</html>
