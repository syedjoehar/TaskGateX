<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="TaskGateX.Forms.UserDetail" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>User Data</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            padding: 20px;
        }

        h2 {
            text-align: center;
        }

        form {
            max-width: 800px;
            margin: 0 auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
        }
        .grid-view {
            margin-top: 20px;
            width: 100%;
            border-collapse: collapse;
        }

        .grid-view th, .grid-view td {
            padding: 10px;
            border: 1px solid #ddd;
            text-align: left;
        }

        .grid-view th {
            background-color: #007bff;
            color: #fff;
        }

        .grid-view tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .grid-view tr:hover {
            background-color: #ddd;
        }

        /* Other styles for the DetailsView and Back button */
        .details-view {
            margin-top: 20px;
        }

        .back-button {
            margin-top: 20px;
            text-align: center;
        }

        input[type="text"],
        input[type="password"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
            font-size: 16px;
        }

        .btn {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
            border-radius: 3px;
        }

        .btn:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>User Data</h2>

        <!-- Display user data in a GridView -->
        <asp:GridView ID="userGridView" CssClass="grid-view" runat="server" AutoGenerateColumns="False" OnRowEditing="userGridView_RowEditing" OnRowUpdating="userGridView_RowUpdating" OnRowCancelingEdit="userGridView_RowCancelingEdit" OnRowDeleting="userGridView_RowDeleting">
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="User ID" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

        <!-- DetailsView for editing user data -->
        <asp:DetailsView ID="userDetailsView" CssClass="details-view" runat="server" AutoGenerateRows="False" OnItemUpdating="userDetailsView_ItemUpdating">
            <Fields>
                <asp:BoundField DataField="UserID" HeaderText="User ID" ReadOnly="True" />
                <asp:TemplateField HeaderText="First Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditFirstName" runat="server" Text='<%# Bind("FirstName") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblFirstName" runat="server" Text='<%# Bind("FirstName") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditLastName" runat="server" Text='<%# Bind("LastName") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblLastName" runat="server" Text='<%# Bind("LastName") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditEmail" runat="server" Text='<%# Bind("Email") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
            </Fields>
        </asp:DetailsView>

        <!-- Back button -->
        <div class="back-button">
            <asp:Button ID="backButton" CssClass="btn" Text="Back" OnClick="backButton_Click" runat="server" />
        </div>
    </form>
</body>
</html>
