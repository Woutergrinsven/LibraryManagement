using System;

namespace Bibliotheek.Models.DTO
{
    public class LendBookModel
    {
        public string Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
