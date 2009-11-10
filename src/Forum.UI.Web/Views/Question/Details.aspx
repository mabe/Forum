<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Forum.UI.Web.Models.Question>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            Id:
            <%= Html.Encode(Model.Id) %>
        </p>
        <p>
            Viewed:
            <%= Html.Encode(Model.Viewed) %>
        </p>
        <p>
            Title:
            <%= Html.Encode(Model.Title) %>
        </p>
        <p>
            Entry:
            <%= Html.Encode(Model.Entry) %>
        </p>
        <p>
            Started:
            <%= Html.Encode(String.Format("{0:g}", Model.Started)) %>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { id = Model.Id })%> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

