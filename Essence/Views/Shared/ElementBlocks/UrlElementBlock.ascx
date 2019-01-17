﻿<%--
    ====================================
    Version: 4.19.0.0 Modified: 20181010
    ====================================
--%>

<%@ Import Namespace="System.Web.Mvc" %>
<%@ Import Namespace="EPiServer.Forms.Helpers.Internal" %>
<%@ Import Namespace="EPiServer.Forms.Implementation.Elements" %>

<%@ Control Language="C#" Inherits="ViewUserControl<UrlElementBlock>" %>

<%
    var formElement = Model.FormElement;
    var labelText = Model.Label;
%>

<% using(Html.BeginElement(Model, new { @class="FormTextbox FormTextbox--Url" + Model.GetValidationCssClasses(), data_f_type="textbox", data_f_modifier="url" })) { %>
    <label for="<%: formElement.Guid %>" class="Form__Element__Caption"><%: labelText %></label>
    <input name="<%: formElement.ElementName %>" id="<%: formElement.Guid %>" type="url" class="FormTextbox__Input FormUrl__Input"
           placeholder="<%: Model.PlaceHolder %>" value="<%: Model.GetDefaultValue() %>" <%= Model.AttributesString %>  data-f-datainput/>

    <%= Html.ValidationMessageFor(Model) %>
<% } %>
