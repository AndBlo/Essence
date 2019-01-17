<%--
    ====================================
    Version: 4.19.0.0 Modified: 20181010
    ====================================
--%>

<%@ Import Namespace="System.Web.Mvc" %>
<%@ Import Namespace="EPiServer.Forms.Helpers.Internal" %>
<%@ Import Namespace="EPiServer.Forms.Implementation.Elements" %>

<%@ Control Language="C#" Inherits="ViewUserControl<RangeElementBlock>" %>

<%
    var formElement = Model.FormElement;
    var labelText = Model.Label;
%>

<% using(Html.BeginElement(Model, new { @class="FormRange", data_f_type="range" })) { %>
    <label for="<%: formElement.Guid %>" class="Form__Element__Caption"><%:labelText %></label>
    <span>
        <span class="FormRange__Min"><%: Model.Min %></span>
        <input name="<%: formElement.ElementName %>" id="<%: formElement.Guid %>" type="range" class="FormRange__Input"
               value="<%: Model.GetRangeValue() %>" data-f-datainput
               min="<%: Model.Min %>" max="<%: Model.Max %>" step="<%: Model.Step %>" <%= Model.AttributesString %> />
        <span class="FormRange__Max"><%: Model.Max %></span>
    </span>
    <span data-f-linked-name="<%: formElement.ElementName %>" data-f-validationerror class="Form__Element__ValidationError" style="display: none;">*</span>
<% } %>