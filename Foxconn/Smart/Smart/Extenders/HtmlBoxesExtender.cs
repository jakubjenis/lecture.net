using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Smart.Extenders
{
    /// <summary>
    ///     Extender of HtmlHelper
    /// </summary>
    public static class HtmlBoxesExtender
    {
        /// <summary>
        ///     Returns content surrounded with fieldset
        /// </summary>
        /// <param name="html">The HTML helper instance that this method extends.</param>
        /// <param name="legend">Fieldset legend</param>
        /// <returns>Content surrounded with fieldset</returns>
        public static ThemedBox FieldSet(this HtmlHelper html, string legend)
        {
            html.ViewContext.Writer.Write("<fieldset><legend>{0}</legend>", legend);
            return new ThemedBox(html.ViewContext, 1, "</fieldset>");
        }

        /// <summary>
        ///     Returns Field set with title <paramref name="title" /> and html content <paramref name="content" />
        /// </summary>
        /// <param name="html">The HTML helper instance that this method extends.</param>
        /// <param name="title">Title for field set</param>
        /// <param name="content">Html content of field set</param>
        /// <returns>
        ///     The HTML markup that represents a link for language switch
        /// </returns>
        public static IHtmlString FieldSet(this HtmlHelper html, IHtmlString content, string title)
        {
            return MvcHtmlString.Create(string.Format("<fieldset><legend>{0}</legend>{1}</fieldset>", title, content));
        }

        /// <summary>
        ///     Returns field set which contains with view for <paramref name="expression" />
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property</typeparam>
        /// <param name="html">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the property to edit.</param>
        /// <returns></returns>
        public static IHtmlString FieldSetDisplayFor<TModel, TProperty>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression)
            where TModel : class
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            return html.FieldSet(html.DisplayFor(expression), metadata.DisplayName);
        }

        /// <summary>
        ///     Returns field set which contains with editor for <paramref name="expression" />
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property</typeparam>
        /// <param name="html">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the property to edit.</param>
        /// <returns></returns>
        public static IHtmlString FieldSetEditFor<TModel, TProperty>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression)
            where TModel : class
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            return html.FieldSet(html.EditorFor(expression), metadata.DisplayName);
        }
    }
}