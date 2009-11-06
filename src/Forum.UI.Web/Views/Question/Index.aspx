<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.IEnumerable<Forum.UI.Web.Models.Question>>" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
<ul>
<% foreach (var question in Model)
   { %>
	<li>
		<div class="question">
			<div>
				<div class="status">
					<span><%= question.Answers %></span><br />
					<span>answer</span>
				</div>
				<div class="views">
					<span><%= question.Viewed %></span><br />
					<span>views</span>
				</div>
			</div>
			<div class="summary">
				<h3><a><%= question.Title %></a></h3>
				<div class"tags"></div><div class="started"><%= question.Started %></div>
			</div>
		</div>
	</li>
<% } %>
</ul>
</asp:Content>
