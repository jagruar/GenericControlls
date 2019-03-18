using PortalCore.Interfaces.Internal.DataAccess;
using PortalCore.Models.Internal.Entites;
using System.Collections.Generic;
using System.Linq;

namespace PortalCore.DataAccess.Internal
{
    public class ModelRepository : IModelRepository
    {
        private readonly PagesContext _context;

        public ModelRepository(PagesContext context)
        {
            _context = context;
        }

        public void SaveConditionals(IEnumerable<Conditional> conditionals)
        {
            foreach (var conditional in conditionals)
            {
                var existingConditional = _context.Conditionals.FirstOrDefault(m => m.ConditionalId == conditional.ConditionalId);
                if (existingConditional == null)
                {
                    _context.Conditionals.Add(conditional);
                }
                else
                {
                    existingConditional.DisplayName = conditional.DisplayName;
                }
                _context.SaveChanges();
            }
        }

        public void SaveEndpoint(Endpoint endpoint)
        {
            var existingEndpoint = _context.Endpoints.FirstOrDefault(e => e.EndpointId == endpoint.EndpointId);
            if (existingEndpoint == null)
            {
                _context.Endpoints.Add(endpoint);
            }
            else
            {
                existingEndpoint.DisplayName = endpoint.DisplayName;
                existingEndpoint.Description = endpoint.Description;
            }
            _context.SaveChanges();
        }

        public void SaveModel(Model model)
        {
            var existingModel = _context.Models.FirstOrDefault(m => m.ModelId == model.ModelId);
            if (existingModel == null)
            {
                _context.Models.Add(model);
            }
            else
            {
                existingModel.DisplayName = model.DisplayName;
                existingModel.Namespace = model.Namespace;
            }
            _context.SaveChanges();
        }

        public void SaveParameters(List<Parameter> parameters)
        {
            foreach (var parameter in parameters)
            {
                var existingParameter = _context.Parameters.FirstOrDefault(m => m.ParameterId == parameter.ParameterId);
                if (existingParameter == null)
                {
                    _context.Parameters.Add(parameter);
                }
                else
                {
                    existingParameter.DisplayName = parameter.DisplayName;
                }
                _context.SaveChanges();
            }
        }

        public void SaveProperties(IEnumerable<Property> properties)
        {
            foreach (var property in properties)
            {
                var existingProperty = _context.Properties.FirstOrDefault(m => m.PropertyId == property.PropertyId);
                if (existingProperty == null)
                {
                    _context.Properties.Add(property);
                }
                else
                {
                    existingProperty.DisplayName = property.DisplayName;
                }
                _context.SaveChanges();
            }
        }
    }
}
