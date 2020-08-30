using System;

namespace eintech_people_lib
{
    /// <summary>A person entity.</summary>
    public interface IPerson {
        /// <summary>A guid for person.</summary>
        public Guid PersonId { get; set; }

        /// <summary>The person's name.</summary>
        public string Name { get; set; }

        /// <summary>Date/time this entry was updated.</summary>
        public DateTime LastUpdatedOn { get; set; }
    }
}
