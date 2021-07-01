using System;

namespace Crates.Api.Features
{
    public class CssVariableDto
    {
        public Guid CssVariableId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
