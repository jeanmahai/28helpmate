<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true"
    CodeBehind="PayCard.aspx.cs" Inherits="WebUI.Pages.PayCard" %>

<%@ Register Src="../UserControls/UCPager.ascx" TagName="UCPager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div>
        <form id="frmPayCard" runat="server" class="span12">
        <div>
            <h2>
                创建充值卡</h2>
            <div class="span12">
                <table class="border">
                    <tr>
                        <td class="span2">
                            卡类型
                        </td>
                        <td>
                            <div class="input-control select ">
                                <select runat="server" id="sCate">
                                    <option value="1">天</option>
                                    <option value="1">月</option>
                                </select>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="span2">
                            生成张数
                        </td>
                        <td>
                            <div class="input-control text ">
                                <input type="text" runat="server" id="numCount" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="span2">
                            有效期起
                        </td>
                        <td>
                            <div class="input-control text datepicker" data-role="datepicker">
                                <input type="text" runat="server" id="dateFrom" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="span2">
                            有效期止
                        </td>
                        <td>
                            <div class="input-control text datepicker" data-role="datepicker">
                                <input type="text" runat="server" id="dateTo" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="span2">
                        </td>
                        <td>
                            <button runat="server" id="btnSave">
                                保存</button>
                            <input type="reset" value="取消" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="span12">
            <table class="no-border-all">
                <tbody>
                    <tr>
                        <td class="span1">
                            卡类型
                        </td>
                        <td class="span2">
                            <div class="input-control select">
                                <select runat="server" id="sCate2">
                                    <option value="-1">全部</option>
                                    <option value="1">天</option>
                                    <option value="1">月</option>
                                </select>
                            </div>
                        </td>
                        <td class="span1">
                            状态
                        </td>
                        <td class="span2">
                            <div class="input-control select">
                                <select runat="server" id="sStatus">
                                    <option value="-1">全部</option>
                                    <option value="0">无效</option>
                                    <option value="1">有效</option>
                                </select>
                            </div>
                        </td>
                        <td>
                            <button runat="server" id="btnSearch">
                                查询</button>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td class="span1">
                            有效期起
                        </td>
                        <td class="span4">
                            <div class="input-control text datepicker" data-role="datepicker">
                                <input type="text" runat="server" id="dateFrom2" />
                            </div>
                        </td>
                        <td class="span1">
                            有效期止
                        </td>
                        <td class="span4">
                            <div class="input-control text datepicker" data-role="datepicker" data-param-init-date="<%=DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd") %>">
                                <input type="text" runat="server" id="dateTo2" />
                            </div>
                        </td>
                        <td class="span2 right">
                        </td>
                    </tr>
                </tbody>
            </table>
            <table class="hovered border mini">
                <thead>
                    <tr>
                        <th>
                            编号
                        </th>
                        <th>
                            卡号
                        </th>
                        <th>
                            类型
                        </th>
                        <th>
                            状态
                        </th>
                        <th>
                            生成时间
                        </th>
                        <th>
                            有效期起
                        </th>
                        <th>
                            有效期止
                        </th>
                        <th>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="rptData" OnItemDataBound="rptData_DataBound">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#Eval("SysNo")%>
                                </td>
                                <td>
                                    <%#Eval("PayCardID")%>
                                </td>
                                <td>
                                    <%#Eval("StrCategory")%>
                                </td>
                                <td>
                                    <%#Eval("StrStatus")%>
                                </td>
                                <td>
                                    <%#Eval("StrInDate")%>
                                </td>
                                <td>
                                    <%#Eval("StrBeginTime")%>
                                </td>
                                <td>
                                    <%#Eval("StrEndTime")%>
                                </td>
                                <td>
                                    <button class="mini" id="btnEnabled" runat="server" onserverclick="btnEnabled_ServerClick">
                                        启用</button>
                                    <button class="mini" id="btnDisabled" runat="server" onserverclick="btnDisabled_ServerClick">
                                        禁用</button>
                                    <button class="mini" id="btnDelete" runat="server" onserverclick="btnDelete_serverClick">
                                        删除</button>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="8">
                            <uc1:UCPager ID="UCPager1" runat="server" />
                        </td>
                    </tr>
                </tfoot>
            </table>
        </div>
        </form>
    </div>
</asp:Content>
