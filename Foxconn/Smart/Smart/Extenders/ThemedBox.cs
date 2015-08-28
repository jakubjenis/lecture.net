using System;
using System.IO;
using System.Web.Mvc;

namespace Smart.Extenders
{
    public class ThemedBox : IDisposable
    {
        private bool _disposed;
        private readonly ViewContext _viewContext;
        private readonly TextWriter _writer;
        private readonly int _numberOfClosingTags = 1;
        private readonly string _closingTag;

        public ThemedBox(ViewContext viewContext, int numberOfClosingTags = 1, string closingTag = "</div>")
        {
            if (viewContext == null)
            {
                throw new ArgumentNullException("viewContext");
            }
            _numberOfClosingTags = numberOfClosingTags;
            _closingTag = closingTag;
            _viewContext = viewContext;
            _writer = viewContext.Writer;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            for (var i = 1; i <= _numberOfClosingTags; i++)
            {
                _writer.Write(_closingTag);
            }

            if (_viewContext != null)
            {
                _viewContext.OutputClientValidation();
            }
            GC.SuppressFinalize(this);
        }
    }
}