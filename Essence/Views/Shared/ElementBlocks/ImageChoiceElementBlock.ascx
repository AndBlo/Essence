﻿<%--
    ====================================
    Version: 4.22.0.0. Modified: 20181218
    ====================================
--%>

<%@ import namespace="System.Web.Mvc" %>
<%@ import namespace="EPiServer.Forms.Helpers.Internal" %>
<%@ import namespace="EPiServer.Forms.Implementation.Elements" %>
<%@ control language="C#" inherits="ViewUserControl<ImageChoiceElementBlock>" %>

<%  
    var formElement = Model.FormElement; 
    var labelText = Model.Label;
    var urlResolver = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.Web.Routing.UrlResolver>();
    var sShouldBeVisible = Model.ShowSelectionInputControl ? "" : "hidden";
%>

<% using(Html.BeginElement(Model, new { id=formElement.Guid, @class="FormChoice FormChoice--Image" + Model.GetValidationCssClasses(), data_f_type="choice" }, true)) { %>
    <%  if(!string.IsNullOrEmpty(labelText)) { %>
    <div class="Form__Element__Caption"><%: labelText %></div>
    <% }
        var index = 0;
        foreach(var item in Model.Items)
        {
            var imageChoiceId = string.Format("{0}_{1}", formElement.Guid, index);
            var defaultCheckedString = Model.GetDefaultSelectedString(item);
            var checkedString = string.IsNullOrEmpty(defaultCheckedString) ? string.Empty : "checked";
    %>
     <label for="<%: imageChoiceId %>" class="FormChoice--Image__Item">
        <% if(Model.AllowMultiSelect) { %>
        <input type="checkbox" id="<%: imageChoiceId %>" name="<%: formElement.ElementName %>" value="<%: item.Text %>" <%: checkedString %>   <%: defaultCheckedString %> class="FormChoice__Input FormChoice__Input--Checkbox <%: sShouldBeVisible %>" data-f-datainput />
        <% } else { %>
        <input type="radio" id="<%: imageChoiceId %>" name="<%: formElement.ElementName %>" value="<%: item.Text %>" <%: checkedString %>   <%: defaultCheckedString %> class="FormChoice__Input FormChoice__Input--Radio <%: sShouldBeVisible %>" data-f-datainput />
        <% } %>
        <span class="FormChoice--Image__Item__Caption"><%: item.Text %></span>
        <img src="<%: urlResolver.GetUrl(item.GetMappedHref()) %>" title="<%: item.Title ?? item.Text %>" />
    </label>
    <%  index++;
    } %>
    <%= Html.ValidationMessageFor(Model) %>
<% } %>