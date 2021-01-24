using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Juniperr.Blazor.Toolbar.Services
{
    class ToolbarService : IToolbarService
    {
        public event Action<Type, int, RenderFragment>? Added;

        public event Action<Type?>? Reset;

        public IToolbarService Clear()
        {
            Reset?.Invoke(null);
            return this;
        } 

        public IToolbarService Clear<TToolbar>()
            where TToolbar : Toolbar
        {
            Reset?.Invoke(typeof(TToolbar));
            return this;
        }

    public IToolbarService Set<TToolbar, TComponent>(int position, IReadOnlyDictionary<string, object> parameters)
        where TToolbar : Toolbar
        where TComponent : IComponent
        {
            var renderFragment = new RenderFragment(builder =>
            {
                builder.OpenElement(0,"li");
                builder.OpenComponent<TComponent>(0);

                var i = 1;
                foreach (var (key, value) in parameters)
                {
                    builder.AddAttribute(i++, key, value);
                }

                builder.CloseComponent();
                builder.CloseElement();
            });

            Added?.Invoke(typeof(TToolbar), position, renderFragment);

            return this;
        }
    }
}
