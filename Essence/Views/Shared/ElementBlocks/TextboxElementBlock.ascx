<%--
    ====================================
    Version: 4.19.0.0 Modified: 20181010
    ====================================
--%>

<%@ import namespace="System.Web.Mvc" %>
<%@ Import Namespace="EPiServer.Forms.Helpers.Internal" %>
<%@ import namespace="EPiServer.Forms.Implementation.Elements" %>
<%@ control language="C#" inherits="ViewUserControl<TextboxElementBlock>" %>

<%
    var formElement = Model.FormElement; 
    var labelText = Model.Label;
%>

<% using(Html.BeginElement(Model, new { @class="FormTextbox" + " form-group" + Model.GetValidationCssClasses(), data_f_type="textbox" })) { %>
    <label for="<%: formElement.Guid %>" class="Form__Element__Caption"><%: labelText %></label>
    <input name="<%: formElement.ElementName %>" id="<%: formElement.Guid %>" type="text" class="FormTextbox__Input form-control"
        placeholder="<%: Model.PlaceHolder %>" value="<%: Model.GetDefaultValue() %>" <%= Model.AttributesString %> data-f-datainput />

<span class="form-text text-danger" data-f-linked-name="<%: formElement.ElementName %>" data-f-validationerror class="Form__Element__ValidationError" style="display: none;">*</span>
    <%--<%= Html.ValidationMessageFor(Model) %>--%>
    <%= Model.RenderDataList() %>
<% } %>
