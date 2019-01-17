<%--
    ====================================
    Version: 4.22.0.0. Modified: 20181218
    ====================================
--%>

<%@ import namespace="System.Web.Mvc" %>
<%@ import namespace="EPiServer.Forms.Helpers.Internal" %>
<%@ import namespace="EPiServer.Forms.Implementation.Elements" %>
<%@ control language="C#" inherits="ViewUserControl<ChoiceElementBlock>" %>

<%
    var formElement = Model.FormElement;
    var labelText = Model.Label;
    var items = Model.GetItems();
%>

<% using(Html.BeginElement(Model, new { id=formElement.Guid, @class="FormChoice" + Model.GetValidationCssClasses(), data_f_type="choice" }, true)) { %>
<fieldset>
    <%  if(!string.IsNullOrEmpty(labelText)) { %>
    <legend class="Form__Element__Caption"><%: labelText %></legend>
    <% } 
        foreach (var item in items)
        {
            var defaultCheckedString = Model.GetDefaultSelectedString(item);
            var checkedString = string.IsNullOrEmpty(defaultCheckedString) ? string.Empty : "checked";
    %>

    <label>
        <% if(Model.AllowMultiSelect) { %>
        <input type="checkbox" name="<%: formElement.ElementName %>" value="<%: item.Value %>" class="FormChoice__Input FormChoice__Input--Checkbox" <%: checkedString %> <%: defaultCheckedString %> data-f-datainput />
        <% } else  { %>
        <input type="radio" name="<%: formElement.ElementName %>" value="<%: item.Value %>" class="FormChoice__Input FormChoice__Input--Radio" <%: checkedString %> <%: defaultCheckedString %> data-f-datainput />
        <% } %>
        <%: item.Caption %></label>

    <% } %>
    <%= Html.ValidationMessageFor(Model) %>
</fieldset>
<% } %>