<%--
    ====================================
    Version: 4.22.0.0 Modified: 20181218
    ====================================
--%>

<%@ Import Namespace="System.Web.Mvc" %>
<%@ Import Namespace="EPiServer.Shell.Web.Mvc.Html" %>
<%@ Import Namespace="EPiServer.Forms" %>
<%@ Import Namespace="EPiServer.Forms.Helpers.Internal" %>
<%@ Import Namespace="EPiServer.Forms.Implementation.Elements" %>
<%@ Control Language="C#" Inherits="ViewUserControl<CaptchaElementBlock>" %>

<%  var formElement = Model.FormElement; 
    var labelText = Model.Label; %>

<% using(Html.BeginElement(Model, new { @class="FormCaptcha", @data_f_type="captcha" })) { %>
<label class="Form__Element__Caption" for="<%: formElement.Guid %>">
    <%: labelText %>
</label>
<button name="submit" type="submit" data-f-captcha-image-handler="<%: formElement.Guid %>" value="<%: SubmitButtonType.RefreshCaptcha.ToString() %>"
    class="FormExcludeDataRebind FormCaptcha__Refresh" data-f-captcha-refresh>
    <%: Html.Translate("/episerver/forms/viewmode/refreshcaptcha")%>
</button>
<img src="<%: Model.CaptchaImageHandler %>" alt="<%: Html.Translate("/contenttypes/captchaelementblock/captchaimagealt") %>" class="FormCaptcha__Image" <%= Model.AttributesString %> data-f-captcha-image />
<input id="<%: formElement.Guid %>" name="<%: formElement.ElementName %>" type="text" class="FormTextbox__Input FormCaptcha__Input FormHideInSummarized" <%= Model.AttributesString %> data-f-datainput />

<%= Html.ValidationMessageFor(Model) %>
<% } %>
