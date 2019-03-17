using PortalCore.Models.Internal.Attributes;
using PortalCore.Models.Internal.Entites;
using PortalCore.Models.Internal.Types.Identification;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalCore.Interfaces.Internal
{
    public interface IEntityBuilder
    {
        Model BuildModel(ModelAttribute attribute);
        Conditional BuildConditional(ModelId modelId, ConditionalAttribute attribute);
        Property BuildProperty(ModelId modelId, PropertyAttribute attribute);
        Endpoint BuildEndpoint(ModelId modelId, string methodName, EndpointAttribute attribute);
    }
}
