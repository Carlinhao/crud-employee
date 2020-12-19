using employers.domain.Entities;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace employers.domain.Responses
{
    public class DepartamentResponse
    {
        [JsonPropertyName("departments")]
        public List<DepartmentEntity> Departaments { get; set; }
    }
}
