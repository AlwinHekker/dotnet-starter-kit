using FSH.Starter.Blazor.Client.Components.EntityTable;
using FSH.Starter.Blazor.Infrastructure.Api;
using FSH.Starter.Shared.Authorization;
using Mapster;
using Microsoft.AspNetCore.Components;

namespace FSH.Starter.Blazor.Client.Pages.Catalog;

public partial class Features
{
    [Inject]
    protected IApiClient _client { get; set; } = default!;

    protected EntityServerTableContext<FeatureResponse, Guid, FeatureViewModel> Context { get; set; } = default!;

    private EntityTable<FeatureResponse, Guid, FeatureViewModel> _table = default!;

    protected override void OnInitialized() =>
        Context = new(
            entityName: "Feature",
            entityNamePlural: "Features",
            entityResource: FshResources.Features,
            fields: new()
            {
                new(Feature => Feature.Id, "Id", "Id"),
                new(Feature => Feature.Name, "Name", "Name"),
                new(Feature => Feature.Description, "Description", "Description")
            },
            enableAdvancedSearch: true,
            idFunc: Feature => Feature.Id!.Value,
            searchFunc: async filter =>
            {
                var FeatureFilter = filter.Adapt<SearchFeaturesCommand>();
                var result = await _client.SearchFeaturesEndpointAsync("1", FeatureFilter);
                return result.Adapt<PaginationResponse<FeatureResponse>>();
            },
            createFunc: async Feature =>
            {
                await _client.CreateFeatureEndpointAsync("1", Feature.Adapt<CreateFeatureCommand>());
            },
            updateFunc: async (id, Feature) =>
            {
                await _client.UpdateFeatureEndpointAsync("1", id, Feature.Adapt<UpdateFeatureCommand>());
            },
            deleteFunc: async id => await _client.DeleteFeatureEndpointAsync("1", id));
}

public class FeatureViewModel : UpdateFeatureCommand
{
}
