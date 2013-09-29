<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true"
    CodeBehind="PayCard.aspx.cs" Inherits="WebUI.Pages.PayCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
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
                        <div class="input-control text datepicker" data-role="datepicker">
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
                <tr>
                    <td colspan="5" class="">
                        <button onclick="showDlgCreate()">
                            创建</button>
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
                </tr>
            </thead>
        </table>
    </div>
    <div id="dlgCreate">
        <h2>
            创建充值卡</h2>
        <div class="span6">
            <table>
                <tr>
                    <td class="span1">
                        卡类型
                    </td>
                    <td>
                        <div class="input-control select ">
                            <select>
                                <option>sdf</option>
                            </select>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="span1">
                        生成张数
                    </td>
                    <td>
                        <div class="input-control select ">
                            <select>
                                <option>sdf</option>
                            </select>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="span1">
                        有效期起
                    </td>
                    <td>
                        <div class="input-control text datepicker" data-role="datepicker">
                            <input type="text" />
                            <button class="btn-date">
                            </button>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="span1">
                        有效期止
                    </td>
                    <td>
                        <div class="input-control text datepicker" data-role="datepicker">
                            <input type="text" />
                            <button class="btn-date">
                            </button>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="span1">
                    </td>
                    <td>
                        <button>
                            保存</button>
                        <button>
                            取消</button>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    
    <script type="text/javascript">
        function showDlgCreate() {
            $("#dlgCreate").show();
            $("#dlgCreate").jposition();
        }
    </script>
</asp:Content>
