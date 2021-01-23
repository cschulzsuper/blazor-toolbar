using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Juniperr.Blazor.Toolbar.Services
{
    class ToolbarService : IToolbarService
    {
        public event Action<int, int, RenderFragment>? Added;

        public event Action<int?>? Reset;

        public IToolbarService Clear()
        {
            Reset?.Invoke(null);
            return this;
        } 

        public IToolbarService Clear(int group)
        {
            Reset?.Invoke(group);
            return this;
        }

    public IToolbarService Set<TComponent>(int group, int position, IReadOnlyDictionary<string, object> parameters)
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

            Added?.Invoke(group, position, renderFragment);

            return this;
        }
    }
}
