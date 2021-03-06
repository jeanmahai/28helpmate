﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="NoticesQuery.aspx.cs" Inherits="WebUI.Pages.NoticesQuery" %>
<%@ Import Namespace="WebUI.Utility" %>
<%@ Register Src="../UserControls/UCPager.ascx" TagName="UCPager" TagPrefix="uc1" %>

<asp:Content ID="conPage" ContentPlaceHolderID="cphContent" runat="server">
    <form id="frmPayCard" runat="server">
    <table class="no-border-all">
        <tbody>
            <tr>
                <td class="span1">
                    公告编号：
                </td>
                <td class="span2">
                    <div class="input-control select">
                       <input type="text" id="txtSysNo" value="<%=QueryFilter.SysNo%>"/>
                    </div>
                </td>
                <td class="span1">
                    状态：
                </td>
                <td class="span2">
                    <div class="input-control select">
                        <select id="sStatus">
                            <option value="">全部</option>
                            <option value="-1">关闭</option>
                            <option value="1">发布</option>
                        </select>
                    </div>
                </td>
                <td>
                    <a class="button bg-color-blueDark fg-color-blueLight" href="<%=UrlHelper.GetPageUrl(Request.Url.ToString()) %>" onclick="pageChange(this);return false;" >查询</a>
                </td>
            </tr>
            <tr>
                <td class="span1">
                    公告内容：
                </td>
                <td class="span4">
                      <div class="input-control text">
                        <input type="text" id="txtCon" value="<%=QueryFilter.Contents%>"/>
                    </div>
                </td>
                <td class="span1">
                </td>
                <td class="span4">
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
                    内容
                </th>
                <th>
                    状态
                </th>
                <th>
                    优先级
                </th>
                <th>
                    创建时间
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
                            <%#Eval("Contents")%>
                        </td>
                        <td>
                            <asp:Literal ID="litStatus" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <%#Eval("Rank")%>
                        </td>
                        <td>
                            <%#Eval("InDate")%>
                        </td>
                        <td>
                            <button class="bg-color-greenDark fg-color-blueLight" id="btnEnabled" runat="server" onserverclick="btnEnabled_ServerClick">
                                发布</button>
                            <button class="bg-color-purple fg-color-blueLight" id="btnDisabled" runat="server" onserverclick="btnDisabled_ServerClick">
                                禁用</button>
                            <button class="" id="btnDelete" runat="server" onserverclick="btnDelete_serverClick">
                                删除</button> 
                            <button class="" id="btnEdit" runat="server" onserverclick="btnEdit_serverClick">
                                编辑</button>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="8">
                    <uc1:UCPager ID="ucPager" runat="server" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
    <script type="text/javascript">
        $(function () {
            var cartStatus = '<%=QueryFilter.Status%>';
            $("#sStatus").find("option[value=" + cartStatus + "]").attr("selected", "selected");
        });

        function pageChange(tag) {
            var me = $(tag);
            var href = me.attr("href");
            var params = [];
            var sysNo = $("#txtSysNo").val();
            params.push("sysNo=" + sysNo);
            var contents = $("#txtCon").val();
            params.push("contents=" + contents);
            var status = $("#sStatus option:selected").attr("value");
            params.push("status=" + status);
            if (params.length > 0) href += "?" + params.join("&");
            window.location.href = href;
        }
    </script>
</asp:Content>
