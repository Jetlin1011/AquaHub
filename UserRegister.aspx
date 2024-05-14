<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="Aquahub.UserRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href='https://fonts.googleapis.com/css?family=Poppins:400,500,600,700&display=swap' rel='stylesheet' type='text/css'>
    
    <style>
    *{
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  font-family: 'Poppins', sans-serif;
}
body{
  min-height: 100vh;
  display: flex;
  align-items: center;
  justify-content: center;
  background: #4070f4;
}
.wrapper{
  position: relative;
  max-width: 80%;
  width: 100%;
  background: #fff;
  padding: 34px;
  border-radius: 6px;
  box-shadow: 0 5px 10px rgba(0,0,0,0.2);
}
.wrapper h2{
  position: relative;
  font-size: 22px;
  font-weight: 600;
  color: #333;
}
.wrapper h2::before{
  content: '';
  position: absolute;
  left: 0;
  bottom: 0;
  height: 3px;
  width: 28px;
  border-radius: 12px;
  background: #4070f4;
}
.wrapper form{
  margin-top: 30px;
}
.wrapper form .input-box{
  height: 52px;
  margin: 50px 0;
  margin-bottom:6px;
}
form .input-box input{
  height: 100%;
  width: 100%;

  outline: none;
  padding: 0 15px;
  font-size: 17px;
  font-weight: 400;
  color: #333;
  border: 1.5px solid #C7BEBE;
  border-bottom-width: 2.5px;
  border-radius: 6px;
  transition: all 0.3s ease;
}
.input-box input:focus,
.input-box input:valid{
  border-color: #4070f4;
}
form .policy{
  display: flex;
  align-items: center;
}
form h3{
  color: #707070;
  font-size: 14px;
  font-weight: 500;
  margin-left: 10px;
}
.input-box.button input{
  color: #fff;
  letter-spacing: 1px;
  border: none;
  background: #4070f4;
  cursor: pointer;
}
.input-box.button input:hover{
  background: #0e4bf1;
}
form .text h3{
 color: #333;
 width: 100%;
 text-align: center;
}
form .text h3 a{
  color: #4070f4;
  text-decoration: none;
}
form .text h3 a:hover{
  text-decoration: underline;
}
    </style>
</head>
<body>

      <div class="wrapper">
    <h2>Registration</h2>
        <div>    <form id="form1" runat="server">

                  <div class="input-box">

           
                        <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
                   
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                   
                        <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*Name is required"></asp:RequiredFieldValidator>
                  </div>

                  <div class="input-box">

                   
                        <asp:Label ID="Label2" runat="server" Text="Age:"></asp:Label>
                    
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="*Age is required"></asp:RequiredFieldValidator>
                    </div>
                  <div class="input-box">

                  
                  
                        <asp:Label ID="Label3" runat="server" Text="Address:"></asp:Label>
                   
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="*Enter your address"></asp:RequiredFieldValidator>
                   </div>
                  <div class="input-box">

              
                        <asp:Label ID="Label4" runat="server" Text="Email:"></asp:Label>
                   
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                  
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox4" ErrorMessage="*Enter your email id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
                  <div class="input-box">

                        <asp:Label ID="Label5" runat="server" Text="Phone:"></asp:Label>
               
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox5" ErrorMessage="*Enter a valid phone number" ValidationExpression="^[6-9]\d{9}$"></asp:RegularExpressionValidator>
                </div>
                       <div class="input-box">

                        <asp:Label ID="Label6" runat="server" Text="District:"></asp:Label>
                   
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                   
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox6" ErrorMessage="*Enetr your district"></asp:RequiredFieldValidator>
                </div>
                  <div class="input-box">

                   
                        <asp:Label ID="Label7" runat="server" Text="State:"></asp:Label>
                   
                        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox7" ErrorMessage="*Enter your State"></asp:RequiredFieldValidator>
              
                  </div>
                  <div class="input-box">

                        <asp:Label ID="Label8" runat="server" Text="PinCode:"></asp:Label>
              
                        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                   
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox8" ErrorMessage="*Enter the pincode" ValidationExpression="^[1-9]\d{2}\s?\d{3}$"></asp:RegularExpressionValidator>
              </div>
                  <div class="input-box">

             
                        <asp:Label ID="Label9" runat="server" Text="Password:"></asp:Label>
               
                        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                  
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox9" ErrorMessage="*enter a pasword"></asp:RequiredFieldValidator>
              </div>
                  <div class="input-box button">

                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign Up" />
                  </div>
            <div class="text">
        <h3>Already have an account? <a href="login.aspx">Login now</a></h3>
      </div>

                      </form>

        </div>
        </div>
    
  




</body>
</html>