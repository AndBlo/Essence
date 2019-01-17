<%--
    ====================================
    Version: 4.22.0.0 Modified: 20181218
    ====================================
--%>

<%@ Import Namespace="System.Web.Mvc" %>
<%@ Import Namespace="EPiServer.Forms.Helpers.Internal" %>
<%@ Import Namespace="EPiServer.Forms.Implementation.Elements" %>

<%@ Control Language="C#" Inherits="ViewUserControl<ParagraphTextElementBlock>" %>

<%
    var formElement = Model.FormElement;
    var paragraphText = Model.ParagraphText;
    var originalParagraphText = Model.OriginalParagraphText;
%>

<% using(Html.BeginElement(Model, new { @class="FormParagraphText Form__Element--NonData", @data_f_element_nondata="" })) { %>
    <% if (EPiServer.Editor.PageEditing.PageIsInEditMode)
    { %>
        <div id="<%: formElement.Guid %>" <%= Model.AttributesString %>><%= Model.EditViewFriendlyTitle %></div>
    <% }
    else
    {  %>
        <div id="<%: formElement.Guid %>" <%= Model.AttributesString %>><%= paragraphText %></div>
        <script type="text/javascript">
            if (typeof $$epiforms !== 'undefined') {
                $$epiforms(document).ready(function () {
                    $$epiforms('.EPiServerForms, [data-f-type="form"]').on("formsNavigationNextStep formsSetupCompleted", function (event) {
                        (function ($) {
                            var text = <%= originalParagraphText %>, 
                                workingFormInfo = event.workingFormInfo,
                                searchPattern = null,
                                $workingForm = workingFormInfo.$workingForm,
                                $currentElement = $("#<%: formElement.Guid %>", $workingForm);

                            // if cannot find the element in form, do nothing
                            if (!$currentElement || $currentElement.length == 0) {
                                return;
                            }

                            var data = epi.EPiServer.Forms.Data.loadFormDataFromStorage(workingFormInfo.Id);
                            
                            // replace placeholder with real field value
                            for (var fieldName in workingFormInfo.ElementsInfo) {
                                if (workingFormInfo.FieldsExcludedInSubmissionSummary.indexOf(fieldName) != -1) {
                                    continue;
                                }
                                var elementInfo = workingFormInfo.ElementsInfo[fieldName],
                                    friendlyName = elementInfo.friendlyName;
                                if (!friendlyName) {
                                    continue;
                                }
                                var value = elementInfo && elementInfo.customBinding == true ?
                                    epi.EPiServer.Forms.CustomBindingElements[elementInfo.type](elementInfo, data[fieldName])
                                    :data[fieldName];
                                if(value == null || value === undefined) {
                                    value = "";
                                }

                                // If the element is inactive (hidden due to dependency rules), set its value to empty
                                if (workingFormInfo.DependencyInactiveElements && workingFormInfo.DependencyInactiveElements.indexOf(fieldName) !== -1) {
                                    value = "";
                                }

                                //We have to encode the friendlyName before replacing it with placeholders in the paragraph text because the paragraph text is already encoded.
                                var encodedFriendlyName =  $('<div></div>').text(friendlyName).html();

                                //https://developer.mozilla.org/en/JavaScript/Reference/Global_Objects/String/replace
                                //https://msdn.microsoft.com/en-us/library/ewy2t5e0.aspx
                                var escapeSpecialCharacterFromEncodedFriendlyName = encodedFriendlyName.replace(/[-\/\\^$*+?.()|[\]{}]/g, '\\$&');
                                searchPattern = new RegExp("#" + escapeSpecialCharacterFromEncodedFriendlyName + "#", 'g');
                                text = text.replace(searchPattern, $('<div></div>').text(value).html());
                            }

                            $currentElement.html(text);

                        })($$epiforms);
                    });
                });
            }
        </script>
    <% } %>
<% } %>