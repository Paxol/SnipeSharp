using System;
using System.Collections.Generic;
using SnipeSharp.Common;
using SnipeSharp.Endpoints;
using SnipeSharp.Endpoints.ExtendedManagers;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Endpoints.SearchFilters;

namespace SnipeSharp
{
    public class SnipeItApi
    {
        private static readonly List<TypeInfo> TypeInfos = new List<TypeInfo>
        {
            new TypeInfo (typeof(Asset), "hardware", typeof(AssetSearchFilter)),
            new TypeInfo (typeof(Category), "categories", typeof(SearchFilter)),
            new TypeInfo (typeof(Company), "companies", null),
            new TypeInfo (typeof(Location), "locations", typeof(SearchFilter)),
            new TypeInfo (typeof(Accessory), "accessories", typeof(AccessoriesSearchFilter)),
            new TypeInfo (typeof(Consumable), "consumables", typeof(ConsumablesSearchFilter)),
            new TypeInfo (typeof(Component), "components", typeof(ComponentsSearchFilter)),
            new TypeInfo (typeof(User), "users", typeof(SearchFilter)),
            new TypeInfo (typeof(StatusLabel), "statuslabels", typeof(SearchFilter)),
            new TypeInfo (typeof(Model), "models", typeof(SearchFilter)),
            new TypeInfo (typeof(License), "licenses", typeof(LicensesSearchFilter)),
            new TypeInfo (typeof(Manufacturer), "manufacturers", null),
            new TypeInfo (typeof(FieldSet), "fieldsets", null),
            new TypeInfo (typeof(Supplier), "suppliers", null),
            new TypeInfo (typeof(Depreciation), "deprecations", null),
            new TypeInfo (typeof(Department), "departments", null)
        };
        
        // Test 
        private readonly IRequestManager _reqManager;

        public SnipeItApi()
        {
            this._reqManager = new RequestManagerRestSharp(ApiSettings);
            
            this.AssetManager = new AssetEndpointManager(this._reqManager);
            this.UserManager = new UserEndpointManager(this._reqManager);
            this.StatusLabelManager = new StatusLabelEndpointManager(this._reqManager);
        }

        public ApiSettings ApiSettings { get; } = new ApiSettings();

        public AssetEndpointManager AssetManager { get; }
        
        public IEndpointManager<Company> CompanyManager => this.GetEndpointManager<Company>();
        
        public IEndpointManager<Location> LocationManager => this.GetEndpointManager<Location>();
        
        public IEndpointManager<Accessory> AccessoryManager => this.GetEndpointManager<Accessory>();
        
        public IEndpointManager<Consumable> ConsumableManager => this.GetEndpointManager<Consumable>();
        
        public IEndpointManager<Component> ComponentManager => this.GetEndpointManager<Component>();

        public UserEndpointManager UserManager { get; }

        public StatusLabelEndpointManager StatusLabelManager { get; }
        
        public IEndpointManager<Model> ModelManager => this.GetEndpointManager<Model>();
        
        public IEndpointManager<License> LicenseManager => this.GetEndpointManager<License>();
        
        public IEndpointManager<Category> CategoryManager => this.GetEndpointManager<Category>();
        
        public IEndpointManager<Manufacturer> ManufacturerManager => this.GetEndpointManager<Manufacturer>();
        
        public IEndpointManager<FieldSet> FieldSetManager => this.GetEndpointManager<FieldSet>();

        public IEndpointManager<Supplier> SupplierManager => this.GetEndpointManager<Supplier>();
        
        public IEndpointManager<Depreciation> DepreciationManager => this.GetEndpointManager<Depreciation>();
        
        public IEndpointManager<Department> DepartmentManager => this.GetEndpointManager<Department>();

        public IEndpointManager<T> GetEndpointManager<T>()
            where T : CommonEndpointModel
        {
            var type = typeof(T);

            foreach (var typeInfo in TypeInfos)
            {
                if (!type.IsAssignableFrom(typeInfo.ItemType))
                {
                    continue;
                }

                return typeInfo.SearchFilterType == null
                    ? new SimpleEndpointManager<T>(this._reqManager, typeInfo.Endpoint)
                    : new EndpointManager<T>(this._reqManager, typeInfo.Endpoint);
            }
            
            // FIXME - error message
            throw new NotSupportedException();
        }

        private class TypeInfo
        {
            public TypeInfo(Type itemType, string endpoint, Type searchFilterType)
            {
                ItemType = itemType;
                Endpoint = endpoint;
                SearchFilterType = searchFilterType;
            }
            
            public Type ItemType { get; set; }

            public string Endpoint { get; set; }

            public Type SearchFilterType { get; set; }
        }
    }
}
