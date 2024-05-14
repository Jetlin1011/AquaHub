<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usercart.aspx.cs" Inherits="Aquahub.usercart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Applight Template By W3 Template</title>
<link rel="stylesheet" href="https://cdn.jsdelivr.net/bxslider/4.2.12/jquery.bxslider.css">
<link rel="stylesheet" href="css/animate.css">
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" integrity="sha384-WskhaSGFgHYWDcbwN70/dfYBj47jz9qbsMId/iRN3ewGhXQFZCSftd1LZCfmhktB" crossorigin="anonymous">
<link rel="stylesheet" type="text/css" href="style.css"/>
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.1.0/css/all.css" integrity="sha384-lKuwvrZot6UHsBSfcMvOkWwlCMgc0TaWr+30HWe3a4ltaBwTZhyTEggF5tJv8tbt" crossorigin="anonymous">
<!-- Font Google -->
<link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700" rel="stylesheet">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 160px;
        }
        .auto-style3 {
            margin-left: 0px;
            margin-right: 5px;
        }
        .auto-style5 {
            width: 160px;
            height: 21px;
        }
        .auto-style6 {
            height: 21px;
        }
        .auto-style7 {
            width: 668px;
        }
        .auto-style8 {
            height: 21px;
            width: 668px;
        }
    </style>
</head>
<body>
        <form id="form1" runat="server">


    <nav class="navbar navbar-expand-lg"  style="background-color:#6f42c1">
  <div class="container"> <a class="navbar-brand navbar-logo" > <h3 class="logo-1 fa-italic fa-bold">AquaHub</h3> </a>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"> <span class="fas fa-bars"></span> </button>
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav ml-auto">
<li>
                          <asp:Button ID="Button7" runat="server" Text="Home" class="btn btn-lg" style="color:darkviolet;background-color:white" OnClick="Button7_Click"/>

</li>        
      </ul>
    </div>
  </div>
</nav>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="auto-style3" Height="243px" Width="650px">
                            <Columns>
                                <asp:BoundField DataField="cart_id" Visible="False" />
                                <asp:ImageField DataImageUrlField="p_image" HeaderText="Item Image">
                                    <ControlStyle Height="60px" Width="75px" />
                                </asp:ImageField>
                                <asp:BoundField DataField="p_name" HeaderText="Name" />
                                <asp:BoundField DataField="p_price" HeaderText="Item Price" />
                                <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                                <asp:BoundField DataField="totalprice" HeaderText="Total Cost" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="Button1" runat="server" CommandArgument='<%# Eval("cart_id") %>' Height="36px" OnCommand="Button1_Command" CssClass="btn-danger" Width="99px" Text="Remove" />
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="Button2" runat="server" CommandArgument='<%# Eval("cart_id") %>' CssClass="btn-success" OnCommand="Button2_Command" Text="+" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="Button3" runat="server" CommandArgument='<%# Eval("cart_id") %>' Height="34px" CssClass="btn-warning" OnCommand="Button3_Command" Text="-" Width="55px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField></asp:TemplateField>
                                <asp:TemplateField></asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5"></td>
                    <td class="auto-style8">&nbsp;Order Total :&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server"></asp:Label>
&nbsp;/-</td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td class="auto-style5"></td>
                    <td class="auto-style8"></td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>
                        <asp:Button ID="Button8" runat="server" BackColor="Blue" CssClass="text-light" OnClick="Button8_Click" Text="Continue" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>

    <section class="download section-padding" style="left: 0px; top: 2px">
  <div class="container">
    <div class="row">
      <div class="col-md-12">
        <div class="sectioner-header text-center white">
          <h3>Download Our App</h3>
          <span class="line"></span>
          <p class="white">Sed quis nisi nisi. Proin consectetur porttitor dui sit amet viverra. Fusce sit amet lorem faucibus, vestibulum ante in, pharetra ante.</p>
        </div>
      </div>
      <div class="col-md-12">
        <div class="section-content text-center">
          <ul>
            <li><a href="#"><img src="images/appstore.png" class="wow fadeInUp" data-wow-delay="0.4s"/></a></li>
            <li><a href="#"><img src="images/playstore.png" class="wow fadeInUp" data-wow-delay="0.7s"/></a></li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</section>

<!-------Download End------->

<footer class="footer-copy">
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-12">
        <p>2018 &copy; Applight. Website Designed by <a href="http://w3Template.com" target="_blank" rel="dofollow">W3 Template</a></p>
      </div>
    </div>
  </div>
</footer>


<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script> 
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js" integrity="sha384-smHYKdLADwkXOn1EmN1qk/HfnUcbVRZyYmZ4qpPea6sjB/pTJ0euyQp0Mk8ck+5T" crossorigin="anonymous"></script> 
<script src="https://cdn.jsdelivr.net/bxslider/4.2.12/jquery.bxslider.min.js"></script> 
<!-- scrollIt js --> 
<script src="js/scrollIt.min.js"></script> 
<script src="js/wow.min.js"></script> 
<script>
    wow = new WOW();
    wow.init();
    $(document).ready(function (e) {

        $('#video-icon').on('click', function (e) {
            e.preventDefault();
            $('.video-popup').css('display', 'flex');
            $('.iframe-src').slideDown();
        });
        $('.video-popup').on('click', function (e) {
            var $target = e.target.nodeName;
            var video_src = $(this).find('iframe').attr('src');
            if ($target != 'IFRAME') {
                $('.video-popup').fadeOut();
                $('.iframe-src').slideUp();
                $('.video-popup iframe').attr('src', " ");
                $('.video-popup iframe').attr('src', video_src);
            }
        });

        $('.slider').bxSlider({
            pager: false
        });
    });

    $(window).on("scroll", function () {

        var bodyScroll = $(window).scrollTop(),
            navbar = $(".navbar");

        if (bodyScroll > 50) {
            $('.navbar-logo img').attr('src', 'images/logo-black.png');
            navbar.addClass("nav-scroll");

        } else {
            $('.navbar-logo img').attr('src', 'images/logo.png');
            navbar.removeClass("nav-scroll");
        }

    });
    $(window).on("load", function () {
        var bodyScroll = $(window).scrollTop(),
            navbar = $(".navbar");

        if (bodyScroll > 50) {
            $('.navbar-logo img').attr('src', 'images/logo-black.png');
            navbar.addClass("nav-scroll");
        } else {
            $('.navbar-logo img').attr('src', 'images/logo-white.png');
            navbar.removeClass("nav-scroll");
        }

        $.scrollIt({

            easing: 'swing',      // the easing function for animation
            scrollTime: 900,       // how long (in ms) the animation takes
            activeClass: 'active', // class given to the active nav element
            onPageChange: null,    // function(pageIndex) that is called when page is changed
            topOffset: -63
        });
    });

</script>
        
</body>
</html>











