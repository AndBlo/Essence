<%--
    ====================================
    Version: 4.9.1. Modified: 20171030
    ====================================
--%>

<%@ import namespace="System.Web.Mvc" %>
<%@ Import Namespace="EPiServer.Shell.Web.Mvc.Html" %>
<%@ import namespace="EPiServer.Forms.Helpers.Internal" %>
<%@ import namespace="EPiServer.Forms.Implementation.Elements" %>
<%@ control language="C#" inherits="ViewUserControl<FileUploadElementBlock>" %>

<%  var formElement = Model.FormElement; 
    var labelText = Model.Label;
    var allowMultiple = Model.AllowMultiple ? "multiple" : string.Empty;
%>

<% using(Html.BeginElement(Model, new { @class="FormFileUpload" + Model.GetValidationCssClasses(), data_f_type="fileupload" })) { %>
    <label for="<%: formElement.Guid %>" class="Form__Element__Caption"><%: labelText %></label>
    <input name="<%: formElement.ElementName %>" id="<%: formElement.Guid %>" type="file" class="FormFileUpload__Input" <%:allowMultiple%>
        <% if(!string.IsNullOrEmpty(Model.FileExtensions)) { %>
			accept="<%=Model.FileExtensions%>"
    	<%}%>     
        <%= Model.AttributesString %> data-f-datainput />
    <div class="FormFileUpload__PostedFile" data-f-postedFile></div>
    <%= Html.ValidationMessageFor(Model) %>
<% } %>
