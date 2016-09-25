using System.Collections.Generic;

namespace Confluence.Model
{
    public class AcronymsInfo
    {
        public string Title { get; set; }
        public int ABSTRACT_CODE { get; set; }
        public string Acronym { get; set; }
        public string Full_Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Link> Links { get; set; }
        public IEnumerable<string> Related { get; set; }
    }
}
