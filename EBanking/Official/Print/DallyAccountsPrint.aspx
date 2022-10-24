<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DallyAccountsPrint.aspx.vb" Inherits="TWEB.DallyAccountsPrint" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v21.2, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v21.2, Version=21.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <!-- Required meta tags -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <link href="../Resour/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Resour/css/customStyleSheet.css" rel="stylesheet" />
    <link href="../Resour/fontawesome/css/all.css" rel="stylesheet" />
    <link href="../Resour/datatable/css/jquery.dataTables.min.css" rel="stylesheet" />

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>

    <script src="../Resour/css/js/myjs.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnl1.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>E Banking</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
</head>
<body>
   <form id="form1" runat="server">
        <asp:Panel ID="pnl1" runat="server">
            <br />
            <div class="row">
                <h4 style="left:50%">Daily Account</h4>
                <div class="col">

                    <hr />
                </div>
            </div>
            <table class="w-100">
                <tr>
                    <td>
                        <centre>
                            <asp:Label ID="Label1" runat="server" Text="Account Holder Name : "></asp:Label>
                            <asp:Label ID="lbacname" runat="server" Text="xyzanything"></asp:Label>
                        </centre>
                    </td>
                </tr>
            </table>
            <div class="row">
                <div class="col">
                    <hr />
                </div>
            </div>
            <table class="w-100">
                <tr>
                    <td class="w-50">
                        <asp:Label ID="Label37" runat="server" Text="Account Number :  "></asp:Label>
                        <asp:Label ID="lbacno" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="w-50">
                        <asp:Label ID="Label43" runat="server" Text="CIF :  "></asp:Label>
                        <asp:Label ID="lbcif" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="w-50">
                        <asp:Label ID="Label39" runat="server" Text="Refference Number :  "></asp:Label>
                        <asp:Label ID="lbreffno" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="w-50">
                        <asp:Label ID="Label45" runat="server" Text="PR Number :  "></asp:Label>
                        <asp:Label ID="lbprno" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="w-50">
                        <asp:Label ID="Label41" runat="server" Text="Date Of Opening :  "></asp:Label>
                        <asp:Label ID="lbdoo" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="w-50">
                        <asp:Label ID="Label47" runat="server" Text="Status :  "></asp:Label>
                        <asp:Label ID="lbstatus" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>

            <div class="row">
                <div class="col">
                    <hr />
                </div>
            </div>
            <table class="w-100">
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Date Of Birth : "></asp:Label>
                        <asp:Label ID="lbdob" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Gender : "></asp:Label>
                        <asp:Label ID="lbgender" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="w-50">
                        <asp:Label ID="Label6" runat="server" Text="Mobile Number : "></asp:Label>
                        <asp:Label ID="lbmobile" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="w-50">
                        <asp:Label ID="Label7" runat="server" Text="Email Id : "></asp:Label>
                        <asp:Label ID="lbemail" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="w-50 ">
                        <asp:Label ID="Label10" runat="server" Text="Aadhaar Card Number : "></asp:Label>
                        <asp:Label ID="lbadhar" runat="server" Text=" "></asp:Label>
                    </td>
                    <td class="w-50 ">
                        <asp:Label ID="Label12" runat="server" Text="PAN Number : "></asp:Label>
                        <asp:Label ID="lbpan" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="Address : "></asp:Label>
                        <asp:Label ID="lbaddress" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <div class="row">
                <div class="col">
                    <hr />
                </div>
            </div>

            <table class="w-100">
                <tr>
                    <td class="w-50 ">
                        <asp:Label ID="Label15" runat="server" Text="Product : "></asp:Label>
                        <asp:Label ID="lbproduct" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="w-50 ">
                        <asp:Label ID="Label17" runat="server" Text="Term : "></asp:Label>
                        <asp:Label ID="lbterm" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label19" runat="server" Text="Value : "></asp:Label>
                        <asp:Label ID="lbValue" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <div class="row">
                <div class="col">
                    <hr />
                </div>
            </div>

            <table class="w-100">
                <tr>
                    <td class="w-50">
                        <asp:Label ID="Label20" runat="server" Text="Operating Mode : "></asp:Label>
                        <asp:Label ID="lbmop" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="w-50">
                        <asp:Label ID="Label22" runat="server" Text="Guardian Name : "></asp:Label>
                        <asp:Label ID="lbGuardian" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="w-50">
                        <asp:Label ID="Label24" runat="server" Text="Second Account Holder : "></asp:Label>
                        <asp:Label ID="lbname2" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="w-50">
                        <asp:Label ID="Label26" runat="server" Text="Relation : "></asp:Label>
                        <asp:Label ID="lbrelation" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>

            <div class="row">
                <div class="col">
                    <hr />
                </div>
            </div>

            <table class="w-100">
                <tr>
                    <td class="w-50">
                        <asp:Label ID="Label27" runat="server" Text="Nomini Register : "></asp:Label>
                        <asp:Label ID="lbnominireg" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="w-50">
                        <asp:Label ID="Label29" runat="server" Text="Nomini Name : "></asp:Label>
                        <asp:Label ID="lbnomininame" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="w-50">
                        <asp:Label ID="Label31" runat="server" Text="Nomini relation : "></asp:Label>
                        <asp:Label ID="lbnominirelation" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="w-50">
                        <asp:Label ID="Label33" runat="server" Text="Nomini Date Of Birth : "></asp:Label>
                        <asp:Label ID="lbnominidob" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label35" runat="server" Text="Nomini Address : "></asp:Label>
                        <asp:Label ID="lbnominiaddress" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <div class="row">
                <div class="col">
                    <hr />
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <hr />
                </div>
            </div>
        </asp:Panel>
        <table class="w-100">
            <tr>
                <td class="w-50">
                    <asp:Label ID="Label36" runat="server" Text="Balance : "></asp:Label>
                    <asp:Label ID="lbbalance" runat="server" Text=""></asp:Label>
                </td>
                <td class="w-50">
                    <asp:Label ID="lb101" runat="server" Text="Transction Id : "></asp:Label>
                    <asp:Label ID="lbtrid" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
