# Super Blazor Toolbar
A simple reusable toolbar for your Blazor application.

[![Build](https://img.shields.io/github/workflow/status/cschulzsuper/blazor-toolbar/Deploy%20Master)](https://github.com/cschulzsuper/blazor-toolbar/actions?query=workflow%3A"Deploy+Master")
[![Nuget](https://img.shields.io/github/v/release/cschulzsuper/blazor-toolbar?sort=semver)](https://github.com/cschulzsuper/blazor-toolbar/packages/)

## Getting Started
Once the first release is ready it will be available on [Nuget](https://www.nuget.org/).  
You can download a preview version [here](https://github.com/cschulzsuper/blazor-toolbar/packages/).

## Usage

### Add Imports

Add the following lines to your *_Imports.razor*.

```razor
@using Super.Blazor.Toolbar
@using Super.Blazor.Toolbar.Services
```

### Add the CascadingToolbarService

Add the `<CascadingToolbarService />` as component to your *App.razor*.

```razor
<CascadingToolbarService>
    <Router AppAssembly="@typeof(Program).Assembly">
        <Found Context="routeData">
            <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
        </Found>
        <NotFound>
            <LayoutView Layout="@typeof(MainLayout)">
                <p>Sorry, there's nothing at this address.</p>
            </LayoutView>
        </NotFound>
    </Router>
</CascadingToolbarService>
```

### Create a Toolbar

Add a typed Toolbar to your project by usage of the `Toolbar` base class.  
You don't need to add any code in the toolbar itself. The new type is later used as generic argument.

```csharp
    public class ActionToolbar : Toolbar
    {
    }
```

### Create a Toolbar Component

Add a new Razor component to your project, which is later used as element in the Toolbar.

```razor
<ToolbarComponent>
    <button class="oi oi-plus" title="Increment counter" @onclick="OnClick"></button>
</ToolbarComponent>

@code {
    private void OnClick() {
        // removed for brevity 
    }  
}
```

### Set the created Toolbar Component on a Page

In order to set a Toolbar Component you need to inject `IToolbarService` as cascading parameter.  
Set a Toolbar Component by calling `Set` with the type of your Toolbar and your Toolbar Component.

```razor
@code {
    [CascadingParameter]
    private IToolbarService ToolbarService { get; set; }

    protected override void OnAfterRender(bool _)
    {
        BreadcrumbService
            .Clear()
            .Set<ActionToolbar, IncrementCounterButton>();
    }
}
```

### Use your Toolbar in MainLayout

Add the your Toolbar in your *MainLayout*.

```razor
<div class="main">
    <div class="top-row px-4">
        <ActionToolbar />
    </div>

    <div class="content px-4">
        @Body
    </div>
</div>
```
