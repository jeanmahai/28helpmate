
支持构建Table行的html
配置如下，需指定一个TABLE ID（一个模板上支持多个TABLE,但需保证ID的唯一性):

------------------------------------------------------------------------
<table>
	<tr><td>标题1</td><td>标题2</td><td>标题3</td></tr>
            
	<%TABLE_ROWS ID=tbl_1%>
		<tr>
			<td style="font-size:12px;color:red"> <%=id%> </td>
			<td style="font-size:12px;color:red"> <%=name%> </td>
			<td style="font-size:12px;color:blue"> <%=sex%> </td>
		</tr>
	<%TABLE_ROWS%>
                 
</table>


HTML style display关键Value:

#HTML_STYLE_DISPLAY#
#HTML_STYLE_DISPLAY_NONE#
------------------------------------------------------------------------
