<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="NoticesQuery.aspx.cs" Inherits="WebUI.Pages.NoticesQuery" %>
<%@ Import Namespace="WebUI.Utility" %>
<%@ Register Src="../UserControls/UCPager.ascx" TagName="UCPager" TagPrefix="uc1" %>

<asp:Content ID="conPage" ContentPlaceHolderID="cphContent" runat="server">
    <table class="no-border-all">
        <tbody>
            <tr>
                <td class="span1">
                    卡类型
                </td>
                <td class="span2">
                    <div class="input-control select">
                        <select id="sCate2">
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
                        <select id="sStatus">
                            <option value="-1">全部</option>
                            <option value="0">无效</option>
                            <option value="1">有效</option>
                        </select>
                    </div>
                </td>
                <td>
                    <a class="button bg-color-blueDark fg-color-blueLight" href="<%=UrlHelper.GetPageUrl(Request.Url.ToString()) %>" onclick="pageChange(this);return false;" >
                        查询</a>
                </td>
            </tr>
            <tr>
                <td class="span1">
                    有效期起
                </td>
                <td class="span4">
                    <div class="input-control text ">
                        <input type="text" id="dateFrom2" data-role="datepicker" value="<%=From==null?"":From.Value.ToShortDateString() %>"/>
                    </div>
                </td>
                <td class="span1">
                    有效期止
                </td>
                <td class="span4">
                    <div class="input-control text">
                        <input type="text" id="dateTo2" data-role="datepicker" value="<%=To==null?"":To.Value.ToShortDateString() %>"/>
                    </div>
                </td>
                <td class="span2 right">
                </td>
            </tr>
        </tbody>
    </table>
    <table class="hovered border mini">
        <thead>
            <tr class="bg-color-teal">
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
                            <button class="bg-color-greenDark fg-color-blueLight" id="btnEnabled" runat="server" onserverclick="btnEnabled_ServerClick">
                                启用</button>
                            <button class="bg-color-purple fg-color-blueLight" id="btnDisabled" runat="server" onserverclick="btnDisabled_ServerClick">
                                禁用</button>
                            <button class="" id="btnDelete" runat="server" onserverclick="btnDelete_serverClick">
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
</asp:Content>
