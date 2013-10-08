<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true"
    CodeBehind="Users.aspx.cs" Inherits="WebUI.Pages.Users" %>
<%@ Import Namespace="DataEntity" %>
<%@ Import Namespace="WebUI.Utility" %>

<%@ Register TagPrefix="uc1" TagName="UCPager" Src="~/UserControls/UCPager.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <form id="frmUsers" runat="server">
    <div>
        <h2>
            用户查询管理</h2>
        <table>
            <tr>
                <td>
                    UserID
                </td>
                <td>
                    <div class="input-control text">
                        <input type="text" id="txtUserId" value="<%=UserId %>"/>
                        <button class="btn-clear">
                        </button>
                    </div>
                </td>
                <td>
                    状态
                </td>
                <td>
                    <div class="input-control text">
                        <select id="sState">
                            <option value="-1">全部</option>
                            <option value="0">无效</option>
                            <option value="1">有效</option>
                        </select>
                    </div>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    充值时间起
                </td>
                <td>
                    <div class="input-control text">
                        <input type="text" id="dateFrom" data-role="datepicker" value="<%=From.HasValue?From.Value.ToString("yyyy-MM-dd"):"" %>" />
                        <button class="btn-clear">
                        </button>
                    </div>
                </td>
                <td>
                    充值时间止
                </td>
                <td>
                    <div class="input-control text">
                        <input type="text" id="dateTo" data-role="datepicker" value="<%=To.HasValue?To.Value.ToString("yyyy-MM-dd"):"" %>"/>
                        <button class="btn-clear">
                        </button>
                    </div>
                </td>
                <td>
                    <a href="<%=UrlHelper.GetPageUrl(Request.Url.ToString()) %>" onclick="queryUser(this);return false;" class="button bg-color-blueDark fg-color-blueLight">查询</a>
                </td>
            </tr>
        </table>
        <table class="striped hovered bordered">
            <thead>
                <tr class="bg-color-teal">
                    <th style="width: 40px;">
                        编号
                    </th>
                    <th>
                        登录名
                    </th>
                    <th>
                        名称
                    </th>
                    <th>
                        电话
                    </th>
                    <th>
                        QQ
                    </th>
                    <th>
                        状态
                    </th>
                    <th>
                        注册IP
                    </th>
                    <th>
                        注册时间
                    </th>
                    <th>
                        充值使用时间起
                    </th>
                    <th>
                        充值使用时间止
                    </th>
                    <th style="width: 60px;">
                        操作
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="rptData">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("SysNo")%>
                            </td>
                            <td>
                                用户登录名<%#Eval("UserID")%>
                            </td>
                            <td>
                                用户名称<%#Eval("UserName")%>
                            </td>
                            <td>
                                电话<%#Eval("Phone")%>
                            </td>
                            <td>
                                QQ<%#Eval("QQ")%>
                            </td>
                            <td>
                                状态<%#Eval("StrStatus")%>
                            </td>
                            <td>
                                注册IP<%#Eval("RegIP")%>
                            </td>
                            <td>
                                注册时间<%#Eval("StrRegDate")%>
                            </td>
                            <td>
                                充值使用时间起<%#Eval("StrPayUseBeginTime")%>
                            </td>
                            <td>
                                充值使用时间止<%#Eval("StrPayUseEndTime")%>
                            </td>
                            <td>
                                <a class="button bg-color-greenDark fg-color-blueLight" style="display:<%#(Container.DataItem as User).Status==UserStatus.Valid?"none":"" %>" href="/Pages/Users.aspx?action=enabled&sysno=<%#Eval("SysNo") %>" onclick=" return enabledUser(this);">启用</a>
                                <a class="button bg-color-purple fg-color-blueLight" style="display:<%#(Container.DataItem as User).Status==UserStatus.Valid?"":"none" %>" href="/Pages/Users.aspx?action=disabled&sysno=<%#Eval("SysNo") %>" onclick="return disabledUser(this);">禁用</a>
                                <a class="button" href="/Pages/Users.aspx?action=delete&sysno=<%#Eval("SysNo") %>" onclick="return deleteUser(this);">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <uc1:UCPager ID="UCPager1" runat="server" />
    </div>
    </form>
    <script type="text/javascript">
        function disabledUser(tag) {
            if (!confirm("是否要禁用此用户?")) return false;
            var me = $(tag);
            var url = me.attr("href");
            $.get(url, function (res) {
                if (res == "") {
                    alert("禁用成功");
                    window.location.href = window.location.href;
                }
                else {
                    alert(res);
                }
            });
            return false;
        }
        function enabledUser(tag) {
            if (!confirm("是否要启用此用户?")) return false;
            var me = $(tag);
            var url = me.attr("href");
            $.get(url, function (res) {
                if (res == "") {
                    alert("启用成功");
                    window.location.href = window.location.href;
                }
                else {
                    alert(res);
                }
            });
            return false;
        }
        function deleteUser(tag) {
            if (!confirm("是否要删除此用户?")) return false;
            var me = $(tag);
            var url = me.attr("href");
            $.get(url, function (res) {
                if (res == "") {
                    alert("删除成功");
                    window.location.href = window.location.href;
                }
                else {
                    alert(res);
                }
            });
            return false;
        }
        function queryUser(tag) {
            var me = $(tag);
            var href = me.attr("href")+"?";
            var params = [];
            params.push("state=" + $("#sState").find("option:selected").attr("value"));
            params.push("id=" + $("#txtUserId").val());
            params.push("from=" + $("#dateFrom").val());
            params.push("to=" + $("#dateTo").val());
            href += params.join("&");
            window.location.href = href;
        }

        $(function () {
            var state = "<%=UserState %>";
            $("#sState").find("option[value=" + state + "]").attr("selected", "selected");
        });
    </script>
</asp:Content>
