<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true"
    CodeBehind="PayLog.aspx.cs" Inherits="WebUI.Pages.PayLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <form runat="server">
    <div>
        <h2>
            充值记录查询</h2>
        <div class="span12">
            <table class="border">
                <tr>
                    <td class="span1">
                        充值开始时间
                    </td>
                    <td>
                        <div class="input-control text" >
                            <input type="text" data-role="datepicker"/>
                        </div>
                    </td>
                    <td class="span1">
                        充值结束时间
                    </td>
                    <td>
                        <div class="input-control text" >
                            <input type="text" data-role="datepicker"/>
                        </div>
                    </td>
                    <td class="span1">
                        <button>
                            查询</button>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</asp:Content>
