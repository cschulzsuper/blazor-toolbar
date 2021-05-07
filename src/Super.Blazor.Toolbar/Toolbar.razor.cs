using System;
using System.Collections.Generic;
using Super.Blazor.Toolbar.Services;
using Microsoft.AspNetCore.Components;

namespace Super.Blazor.Toolbar
{
    public partial class Toolbar : IDisposable
    {
        [Parameter]
        public string CssClass { get; set; } = string.Empty;

        [CascadingParameter]
        public IToolbarService ToolbarService { get; set; } = null!;

        private readonly IList<RenderFragment> _toolbarComponents = new List<RenderFragment>();

        protected override void OnInitialized()
        {
            ToolbarService.Added += HandleToolbarComponentsAdded;
            ToolbarService.Reset += HandleToolbarComponentsReset;
        }
        void IDisposable.Dispose()
        {
            ToolbarService.Added -= HandleToolbarComponentsAdded;
            ToolbarService.Reset -= HandleToolbarComponentsReset;
            GC.SuppressFinalize(this);
        }

        private void HandleToolbarComponentsReset(Type? toolbarType)
        {
            if (toolbarType != null && toolbarType != GetType())
            {
                return;
            }

            _toolbarComponents.Clear();
            StateHasChanged();
        }

        private void HandleToolbarComponentsAdded(Type toolbarType, RenderFragment toolbarComponent)
        {
            if (toolbarType != GetType())
            {
                return;
            }

            _toolbarComponents.Add(toolbarComponent);
            StateHasChanged();
        }
    }
}
