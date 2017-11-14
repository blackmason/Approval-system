
using System.Collections.Generic;

namespace Approval.Models
{
    public class Preform
    {
        public string Seq { get; set; }
        public string FormId { get; set; }
        public string FormGroup { get; set; }
        public string Subject { get; set; }
        public string Explain { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Enabled { get; set; }
        public string Modified { get; set; }
        public string Created { get; set; }

        public List<Preform> PreformList { get; set; }
    }
}