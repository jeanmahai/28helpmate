<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true"
    CodeBehind="PayCard.aspx.cs" Inherits="WebUI.Pages.PayCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <form id="frmPayCard" runat="server">
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
                        <div class="input-control text datepicker" data-role="datepicker" >
                            <input type="text" runat="server" id="dateFrom" />
                            <button class="btn-date">
                            </button>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="span2">
                        有效期止
                    </td>
                    <td>
                        <div class="input-control text datepicker" data-role="datepicker" >
                            <input type="text" runat="server" id="dateTo" />
                            <button class="btn-date">
                            </button>
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
                            <select>
                                <option>sdf</option>
                            </select>
                        </div>
                    </td>
                    <td class="span1">
                        生成张数
                    </td>
                    <td class="span2">
                        <div class="input-control number">
                            <input class="border" type="number" placeholder="请输入生成卡的张数" />
                        </div>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="span1">
                        有效期起
                    </td>
                    <td class="span4">
                        <div class="input-control text datepicker" data-role="datepicker" data-param-lang="cn">
                            <input type="text" />
                            <button class="btn-date">
                            </button>
                        </div>
                    </td>
                    <td class="span1">
                        有效期止
                    </td>
                    <td class="span4">
                        <div class="input-control text datepicker" data-role="datepicker">
                            <input type="text" />
                            <button class="btn-date">
                            </button>
                        </div>
                    </td>
                    <td class="span2 right">
                        <button>
                            查询</button>
                    </td>
                </tr>
            </tbody>
        </table>
        <table class="hovered border">
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
                <asp:Repeater runat="server" ID="rptData">
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
                                <button class="mini" runat="server" OnServerClick="btnEnabled_ServerClick" title="<%#Eval("SysNo")%>">启用</button>
                                <button class="mini" runat="server" OnServerClick="btnDisabled_ServerClick" title="<%#Eval("SysNo")%>">禁用</button>
                                <button class="mini" runat="server" OnServerClick="btnDelete_serverClick" title="<%#Eval("SysNo")%>">删除</button>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
    </form>
</asp:Content>
