<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="TaskGateX.Forms.Registration" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Registration Form</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
        }
        
        h2 {
            text-align: center;
        }
        
        form {
            max-width: 400px;
            margin: 0 auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
        }
        
        label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
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
        
        .form-group {
            margin-bottom: 20px;
        }
        
        .error-message {
            color: red;
        }
        
        input[type="submit"] {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
            border-radius: 3px;
        }
        
        input[type="submit"]:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <h2>Registration Form</h2>
    <form id="registrationForm" runat="server">
        <div class="form-group">
            <label for="firstName">First Name:</label>
            <asp:TextBox ID="firstName" runat="server" />
        </div>
        <div class="form-group">
            <label for="lastName">Last Name:</label>
            <asp:TextBox ID="lastName" runat="server" />
        </div>
        <div class="form-group">
            <label for="email">Email:</label>
            <asp:TextBox ID="email" runat="server" />
            <asp:RegularExpressionValidator ID="emailValidator" runat="server"
                ControlToValidate="email"
                ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$"
                ErrorMessage="Please enter a valid email address."
                ForeColor="Red"
                Display="Dynamic" />
        </div>
        <div class="form-group">
            <label for="password">Password:</label>
            <asp:TextBox ID="password" TextMode="Password" runat="server" />
        </div>
        <div>
            <asp:Button ID="registerButton" Text="Register" OnClick="registerButton_Click" runat="server" />
        </div>
        <div>
            <asp:Label ID="errorMessage" CssClass="error-message" runat="server" />
        </div>
    </form>
</body>
</html>
