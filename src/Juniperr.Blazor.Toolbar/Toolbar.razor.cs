using System;
using System.Collections.Generic;
using System.Linq;
using Juniperr.Blazor.Toolbar.Services;
using Microsoft.AspNetCore.Components;

namespace Juniperr.Blazor.Toolbar
{
    public sealed partial class Toolbar : IDisposable
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
        }

        private void HandleToolbarComponentsReset(int? group)
        {
            if (group != null && group != Group)
            {
                return;
            }

            _toolbarComponents.Clear();
            StateHasChanged();
        }

        private void HandleToolbarComponentsAdded(int group, int position, RenderFragment toolbarComponent)
        {
            if (Group != group)
            {
                return;
            }

            while (_toolbarComponents.Count > position)
                _toolbarComponents.Remove(_toolbarComponents.Last());

            _toolbarComponents.Add(toolbarComponent);
            StateHasChanged();
        }
    }
}
