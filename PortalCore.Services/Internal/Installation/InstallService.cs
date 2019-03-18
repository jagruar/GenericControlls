using PortalCore.Interfaces.Internal;
using PortalCore.Interfaces.Internal.DataAccess;
using PortalCore.Interfaces.Portal;
using PortalCore.Models.Internal.Attributes;
using PortalCore.Models.Internal.Entites;
using PortalCore.Models.Internal.Types.Identification;
using PortalCore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PortalCore.Services.Internal.Installation
{
    public class InstallService : IInstallService
    {
        private readonly IEnumerable<IViewModel> _viewModels;
        private readonly IEnumerable<IViewModelService> _services;
        private readonly IEntityBuilder _entityBuilder;
        private readonly IModelRepository _modelRepository;

        private List<Model> _models { get; set; }

        public InstallService(
            IEnumerable<IViewModel> models,
            IEnumerable<IViewModelService> services,
            IEntityBuilder entityBuilder,
            IModelRepository modelRepository)
        {
            _viewModels = models;
            _services = services;
            _entityBuilder = entityBuilder;
            _modelRepository = modelRepository;
            _models = new List<Model>();
        }

        public void InstallModels()
        {
            // install or update models
            foreach (IViewModel viewModel in _viewModels)
            {
                ModelAttribute modelAttribute = GetAttribute<ModelAttribute>(viewModel);
                Model model = _entityBuilder.BuildModel(modelAttribute);
                model.Namespace = viewModel.GetType().Namespace;
                _modelRepository.SaveModel(model);
            }

            foreach (IViewModel viewModel in _viewModels)
            {
                ModelId modelId = GetAttribute<ModelAttribute>(viewModel).ModelId;
                _modelRepository.SaveConditionals(GetConditionals(modelId, viewModel));
                _modelRepository.SaveProperties(GetProperties(modelId, viewModel));
            }

            foreach (IViewModelService service in _services)
            {
                MethodInfo[] methods = service.GetType().GetMethods();
                foreach (MethodInfo method in methods)
                {
                    if (TryGetAttribute(method, out EndpointAttribute attribute))
                    {
                        Endpoint endpoint = _entityBuilder.BuildEndpoint(method.Name, attribute);
                        endpoint.ModelId = service.ModelId;
                        _modelRepository.SaveEndpoint(endpoint);

                        List<Parameter> parameters = GetAttributes<ParameterAttribute>(method)
                            .Select(p => _entityBuilder.BuildParameter(endpoint.EndpointId, p)).ToList();
                        _modelRepository.SaveParameters(parameters);
                    }
                }
            }
        }

        private IEnumerable<Conditional> GetConditionals(ModelId modelId, IViewModel viewModel)
        {
            var conditionals = new List<Conditional>();
            MethodInfo[] methods = viewModel.GetType().GetMethods();
            foreach (MethodInfo method in methods)
            {
                if (TryGetAttribute(method, out ConditionalAttribute attribute))
                {
                    conditionals.Add(_entityBuilder.BuildConditional(modelId,  attribute));
                }
            }
            return conditionals;
        }

        private IEnumerable<Property> GetProperties(ModelId modelId, IViewModel viewModel)
        {
            var properties = new List<Property>();

            IEnumerable<MemberInfo> memberInfos = viewModel
                .GetType()
                .GetMembers()
                .Where(m => m.MemberType == MemberTypes.Property);

            foreach (MemberInfo memberInfo in memberInfos)
            {
                if (TryGetAttribute(memberInfo, out PropertyAttribute attribute))
                {
                    properties.Add(_entityBuilder.BuildProperty(modelId, attribute, memberInfo.Name));
                }
            }
            return properties;
        }

        private bool TryGetAttribute<T>(MemberInfo method, out T attribute) where T : Attribute
        {
            attribute = (T)Attribute.GetCustomAttribute(method, typeof(T));
            return attribute != null;          
        }

        private T GetAttribute<T>(object o) where T : Attribute
        {
            return (T)(Attribute.GetCustomAttribute(o.GetType(), typeof(T)));
        }

        private IEnumerable<T> GetAttributes<T>(object o) where T : Attribute
        {
            var attributes = Attribute.GetCustomAttributes(o.GetType(), typeof(T));
            return attributes.Select(a => (T)a);        
        }

        private IEnumerable<T> GetAttributes<T>(MemberInfo m) where T : Attribute
        {
            var attributes = Attribute.GetCustomAttributes(m.GetType(), typeof(T));
            return attributes.Select(a => (T)a);
        }
    }
}
