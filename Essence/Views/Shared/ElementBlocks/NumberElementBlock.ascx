<%--
    ====================================
    Version: 4.19.0.0 Modified: 20181010
    ====================================
--%>

<%@ Import Namespace="System.Web.Mvc" %>
<%@ Import Namespace="EPiServer.Forms.Helpers.Internal" %>
<%@ Import Namespace="EPiServer.Forms.Implementation.Elements" %>
<%@ Control Language="C#" Inherits="ViewUserControl<NumberElementBlock>" %>

<%  var formElement = Model.FormElement; 
    var labelText = Model.Label;
%>

<% using(Html.BeginElement(Model, new { @class="FormTextbox FormTextbox--Number" + Model.GetValidationCssClasses(), @data_f_type="textbox", data_f_modifier="number" })) { %>
    <label for="<%: formElement.Guid %>" class="Form__Element__Caption"><%: labelText %></label>
    <input name="<%: formElement.ElementName %>" id="<%: formElement.Guid %>" type="number" placeholder="<%: Model.PlaceHolder %>"
        class="FormTextbox__Input" <%= Model.AttributesString %> data-f-datainput
        value="<%: Model.GetDefaultValue() %>" />
    <%= Html.ValidationMessageFor(Model) %>
    <%= Model.RenderDataList() %>
<% } %>
