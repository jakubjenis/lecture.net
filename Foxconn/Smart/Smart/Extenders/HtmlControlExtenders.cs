using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Smart.Attributes;

namespace Smart.Extenders
{
    public static class HtmlControlExtender
    {
        /// <summary>
        ///     Creates labeled display for column in <paramref name="expression" />
        /// </summary>
        /// <param name="html">The HTML html instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the property of label</param>
        /// <param name="template">Editor template</param>
        /// <returns>
        ///     Label and control for column in <paramref name="expression" />
        /// </returns>
        public static MvcHtmlString LabeledDisplay(this HtmlHelper html, string expression,
            ControlTemplate? template = null)
        {
            // ReSharper disable once Mvc.TemplateNotResolved
            return html.Display(expression, "LabeledDisplay", new {Template = template.ToString()});
        }

        /// <summary>
        ///     Creates labeled display for column in <paramref name="expression" />
        /// </summary>
        /// <param name="html">The HTML html instance that this method extends</param>
        /// <param name="expression">An expression that identifies the property of label</param>
        /// <param name="template">Editor template</param>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value</typeparam>
        /// <returns>
        ///     Label and control for column in <paramref name="expression" />
        /// </returns>
        public static MvcHtmlString LabeledDisplayFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, ControlTemplate? template = null)
        {
            // ReSharper disable once Mvc.TemplateNotResolved
            return html.DisplayFor(expression, "LabeledDisplay", new {Template = template.ToString()});
        }

        /// <summary>
        ///     Creates labeled editor for column in <paramref name="expression" />
        /// </summary>
        /// <param name="html">The HTML html instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the property of label.</param>
        /// <param name="template">Editor template</param>
        /// <returns>
        ///     Label and control for column in <paramref name="expression" />
        /// </returns>
        public static MvcHtmlString LabeledEditor(this HtmlHelper html, string expression,
            ControlTemplate? template = null)
        {
            // ReSharper disable once Mvc.TemplateNotResolved
            return html.Editor(expression, "LabeledEditor", new {Template = template.ToString()});
        }

        /// <summary>
        ///     Creates labeled editor for column in <paramref name="expression" />
        /// </summary>
        /// <param name="html">The HTML html instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the property of label.</param>
        /// <param name="template">Editor template</param>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <returns>
        ///     Label and control for column in <paramref name="expression" />
        /// </returns>
        public static MvcHtmlString LabeledEditorFor<TModel, TValue>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, ControlTemplate? template = null)
            where TModel : class
        {
            // ReSharper disable once Mvc.TemplateNotResolved
            return html.EditorFor(expression, "LabeledEditor", new {Template = template.ToString()});
        }
    }
}