using System;
using System.Collections.Generic;

namespace CrewModel.Entities
{
    public partial class Logbook
    {
        public int LogId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int AuthorMemberId { get; set; }

        public virtual Crew AuthorMember { get; set; } = null!;
    }
}
