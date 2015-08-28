﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="construction.aspx.cs" Inherits="construction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Styles/Page.css" rel="stylesheet" type="text/css" />
   
    <style type="text/css">
        .style1
        {
            width: 183px;
        }
        .style4
        {
            width: 587px;
        }
        .style5
        {
            width: 262px;
        }
        .style6
        {
            width: 539px;
            height: 83px;
        }
        .style7
        {
            width: 162px;
            height: 62px;
        }
        .style8
        {
            width: 265px;
            height: 87px;
        }
        .style9
        {
            height: 87px;
            width: 183px;
        }
        .style10
        {
            width: 262px;
            height: 87px;
        }
        .style11
        {
            height: 87px;
            width: 171px;
        }
        .style12
        {
            width: 217px;
            height: 87px;
        }
        .style14
        {
            width: 889px;
            height: 530px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <div class="page">
        <div class="header">
            <div class="title">
            </div>
            <div class="loginDisplay">
                <table style="width:100%; margin-right: 6px;">
                    <tr>
                        <td class="style1" align="center">
                            <img alt="" class="style7" src="Images/login_Logo.JPG" /><br />
                            <hr style="color:White;width:142px;"  />
                           <center> <asp:Label ID="Label1" runat="server" Text="DateTime"></asp:Label> </center>
                        </td>
                        <td align="center">
                            <img alt="" class="style6" src="Images/Header5.jpg" /><br />
                            ABC E-Recruitment Portal</td>
                            <td align="center" valign="top">
                            
                            <table>
                            <tr>
                                <td>
                                <a href="Home_TestAdministrator.aspx">  
                                    <img src="Images/HomeSmall.jpg" 
                                            style="border-color: #000000; height: 64px; width: 95px" /> </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   <a href="mailto:e.recruitment@abc.com?Subject=Hello%20again">
Mail Us</a>
 
                                </td>
                            </tr>
                            </table></td>
                    </tr>
                </table>
            </div>
            <div class="clear hideSkiplink">
                <table style="width:100%;">
                    <tr>
                        <td class="style4">
              <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="false" 
                                IncludeStyleBlock="false" Orientation="Horizontal" 
                             >
                    <Items>
                        <asp:MenuItem NavigateUrl="Home_PlacementConsultant.aspx" Text="Home"/>
                        <asp:MenuItem NavigateUrl="~/About.aspx" Text="About Us"/>
                        <asp:MenuItem NavigateUrl="" Text="Services">
                       
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="" Text="Contact Us" />
                    </Items>
                    </asp:Menu>
               </td>
               <td style="color: #FFFFFF" class="style5">
            &nbsp;&nbsp;&nbsp;You are currently logged in as: &nbsp;&nbsp;
                   <asp:Label ID="ID" runat="server" ForeColor="White">gfgfgfg</asp:Label>
                   </td>
                   <td>
                   <asp:Menu ID="Menu1" runat="server" CssClass="menu" EnableViewState="false" 
                                IncludeStyleBlock="false" Orientation="Horizontal" >
                    <Items>
                        <asp:MenuItem NavigateUrl="~/Login.aspx" Text="Logout"/>
                    </Items>
                </asp:Menu>
            </td>
            </tr>
            </table>
            </div>
        </div>
        <div class="main">
            <img alt="" class="style14" src="Images/website-under-construction.gif" /></div>
    
        <div class="footer">
        <div style="background-color: #666666; color: #FFFFFF"><table>
                <tr>
                    <td style="color:White" align="center" class="style2">
                        <center>
                          
                                    <div id="footer_left" style="color:White; height: 135px; width: 953px;">
                                        <table style="width:94%; height: 122px; margin-bottom: 48px;">
                                            <tr>
                                                <td align="center" class="style8" style="color: #FFFFFF; font-size: small;">
                                                    <strong><a style="color:White" href="">Services</a></strong><br>
                                                    <a style="color:White" href="construction.aspx">Assurance Services</a><br>
                                                    <a style="color:White" href="construction.aspx">BI & Performance Management</a><br>
                                                    <a style="color:White" href="construction.aspx">Business Process Outsourcing</a></td>
                                                <td align="center" class="style11" style="color: #FFFFFF; font-size: small;">
                                                    <strong><a style="color:White" href="">Industries</a></strong><br>
                                                    <a style="color:White" href="construction.aspx">Banking&nbsp; Services</a><br>
                                                    <a style="color:White" href="construction.aspx">Energy, Resources</a><br>
                                                    <a style="color:White" href="construction.aspx">Government</a></td>
                                                <td align="center" class="style12" style="color: #FFFFFF; font-size: small;">
                                                    <strong><a style="color:White" href="">Services</a></strong><br>
                                                    <a style="color:White" href="">Assurance Services</a><br>
                                                    <a style="color:White" href="">BI Management</a><br>
                                                    <a style="color:White" href="">Business Process Outsourcing</a><br>
                                                </td>
                                               <td align="center" class="style9" style="color: #FFFFFF; font-size: small;">
                                                    <strong><a style="color:White" href="">Industries</a></strong><br>
                                                    <a style="color:White" href="">Banking&nbsp; Services</a><br>
                                                    <a style="color:White" href="">Energy, Resources</a><br>
                                                    <a style="color:White" href="">Government</a><br>
                                                    </td>
                                                <td align="center" class="style10" style="color: #FFFFFF; font-size: small;">
                                                    <strong><a style="color:White" href="">Services</a></strong><br>
                                                    <a style="color:White" href="">Assurance Services</a><br>
                                                    <a style="color:White" href="">BI & Performance Management</a><br>
                                                    <a style="color:White" href="">Business Process Outsourcing</a><br>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </div>
                                
                        </center>
                    </td>
                </tr>
            </table></div>
        Copyright © 2012 ABC E-Recruitment Team. 
            All Rights Reserved.</div>
    </div>
    </form>
</body>
</html>

