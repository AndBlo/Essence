<%--
    ====================================
    Version: 4.19.0.0 Modified: 20181010
    ====================================
--%>

<%@ Import Namespace="System.Web.Mvc" %>
<%@ Import Namespace="EPiServer.Forms.Implementation.Elements" %>
<%@ Control Language="C#" Inherits="ViewUserControl<ResetButtonElementBlock>" %>

<% var buttonText = Model.Label; %>

<input  
    <%--name="<%: formElement.ElementName %>" id="<%: formElement.Guid %>" --%>
    type="reset" form="<%: Model.FormElement.Form.FormGuid %>"
    class="Form__Element FormResetButton Form__Element--NonData" data-f-element-nondata <%= Model.AttributesString %> 
    value="<%: buttonText %>" data-f-type="resetbutton" >